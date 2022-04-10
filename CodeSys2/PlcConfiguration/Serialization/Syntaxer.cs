using CodeSys2.PlcConfiguration.Models;
using CodeSys2.PlcConfiguration.Serialization.EntityReaders;
using CodeSys2.PlcConfiguration.Serialization.Enums;
using System.ComponentModel;
using System.Reflection;
using Module = CodeSys2.PlcConfiguration.Models.Module;

namespace CodeSys2.PlcConfiguration.Serialization
{
    /// <summary>
    /// Синтаксический анализатор файла конфигурации ПЛК.
    /// </summary>
    internal sealed class Syntaxer
    {
        private readonly IReadOnlyList<Lexem> _lexems;
        private int _lexemIndex;

        private Lexem CurrentLexem => _lexems[_lexemIndex];


        public Syntaxer(IReadOnlyList<Lexem> lexems)
        {
            _lexems = lexems;
        }

        private Lexem? Match(params LexemKind[] expected)
        {
            if (expected.Length == 0)
                throw new ArgumentException("Список проверяемых лексем пуст", nameof(expected));

            if (InBounds())
            {
                var currentLexem = CurrentLexem;
                if (expected.Any(t => t == currentLexem.Kind))
                {
                    Skip();
                    return currentLexem;
                }
            }

            return null;
        }

        private void Skip(int count = 1) => _lexemIndex = Math.Min(_lexemIndex + count, _lexems.Count - 1);

        private bool InBounds() => _lexemIndex >= 0 && _lexemIndex < _lexems.Count;

        private Lexem Require(params LexemKind[] expected)
        {
            if (expected.Length == 0)
                throw new ArgumentException("Список ожидаемых лексем пуст", nameof(expected));

            var lexem = Match(expected);

            if (lexem is null)
                throw new InvalidOperationException($"На позиции {CurrentLexem.Offset + CurrentLexem.Length} ожидается {expected[0]}");

            return lexem;
        }

        private static T? TryGetValue<T>(Lexem lexem, PropertyInfo? propertyInfo = default)
        {
            if (lexem.Value is not null)
            {
                var value = lexem.Value;

                if (lexem.Kind == LexemKind.String)
                {
                    value = value[1..^1];
                }

                // Type Converter
                var converter = TypeDescriptor.GetConverter(typeof(T));

                // PropertyConverter
                var converterTypeNameStr = propertyInfo?.GetCustomAttribute<TypeConverterAttribute>()?.ConverterTypeName;
                if (converterTypeNameStr is not null)
                {
                    var converterTypeName = Type.GetType(converterTypeNameStr);
                    if (converterTypeName is not null)
                    {
                        var obj = Activator.CreateInstance(converterTypeName);
                        if (obj is not null)
                        {
                            converter = (TypeConverter)obj;
                        }
                    }
                }

                if (converter.CanConvertFrom(value.GetType()))
                {
                    var convertedValue = converter.ConvertFrom(value);
                    if (convertedValue is not null)
                        return (T?)convertedValue;
                }
            }
            throw new InvalidOperationException($"На позиции {lexem.Offset} недопустимое значение \"{lexem.Value}\" свойства");
        }

        // TODO связь LexemKind с текстом лексемы для отображения ошибок

        public PlcConfiguration? ParseConfiguration()
        {
            Require(LexemKind.ConfigurationBegin);

            var reader = EntityReaderProvider.GetReader(typeof(PlcConfiguration));
            var obj = reader.Read();
            if (obj is not PlcConfiguration config)
                throw new Exception();

            //var configuration = new PlcConfiguration();
            //ParseGlobalOptions(configuration);
            //
            //var rootEntity = ParseEntity();
            //if (rootEntity is not null || rootEntity is not Module rootModule)
            //    throw new InvalidOperationException("Конфигурация ПЛК должна иметь корневой модуль");
            //configuration.RootModule = rootModule;
            //
            //Require(LexemKind.ConfigurationEnd);
            return config;
        }

        private void ParseGlobalOptions(PlcConfiguration plcConfiguration)
        {
            Require(LexemKind.GlobalOptionsBegin);
            var proLexems = new LexemKind[] { LexemKind.Version, LexemKind.AutoAddress, LexemKind.CheckAddress, LexemKind.SaveConfigFilesInProject };
            Lexem? propertyLexem;
            while ((propertyLexem = Match(proLexems)) is not null)
            {
                Require(LexemKind.Colon);
                var valueLexem = Require(LexemKind.Number);
                switch (propertyLexem.Kind)
                {
                    case LexemKind.Version:
                        plcConfiguration.Version = TryGetValue<int>(valueLexem,
                            plcConfiguration.GetType().GetProperty(nameof(plcConfiguration.Version)));
                        break;
                    case LexemKind.AutoAddress:
                        plcConfiguration.AutoAdress = TryGetValue<bool>(valueLexem,
                            plcConfiguration.GetType().GetProperty(nameof(plcConfiguration.AutoAdress)));
                        break;
                    case LexemKind.CheckAddress:
                        plcConfiguration.CheckAddress = TryGetValue<bool>(valueLexem,
                            plcConfiguration.GetType().GetProperty(nameof(plcConfiguration.CheckAddress)));
                        break;
                    case LexemKind.SaveConfigFilesInProject:
                        plcConfiguration.SaveConfigInProject = TryGetValue<bool>(valueLexem,
                            plcConfiguration.GetType().GetProperty(nameof(plcConfiguration.SaveConfigInProject)));
                        break;
                    default:
                        throw new InvalidOperationException($"На позиции {propertyLexem.Offset} недопустимое свойство {valueLexem.Kind}");
                }
            }
            Require(LexemKind.GlobalOptionsEnd);
        }

        private Entity? ParseEntity()
        {
            Entity? entity = null;
            var proLexems = new LexemKind[] { LexemKind.ModuleBegin, LexemKind.ChannelBegin, LexemKind.BitChannel };
            Lexem? propertyLexem;
            while ((propertyLexem = Match(proLexems)) is not null)
            {
                entity = propertyLexem.Kind switch
                {
                    LexemKind.ModuleBegin => ParseModule(),
                    //LexemKind.ChannelBegin => ParseChannel(),
                    //LexemKind.BitChannel => throw new NotImplementedException(),
                    _ => throw new InvalidOperationException($"На позиции {propertyLexem.Offset} недопустимое свойство"),
                };
            }
            return entity;
        }

        private Module? ParseModule()
        {
            var module = new Module();
            Require(LexemKind.Colon);
            var valueLexem = Require(LexemKind.String);
            module.Name = TryGetValue<string>(valueLexem) ?? string.Empty;
            var proLexems = new LexemKind[] {
                LexemKind.SectionName, LexemKind.IndexInParent, LexemKind.ModuleName, LexemKind.NodeId,
                LexemKind.IECIn, LexemKind.IECOut, LexemKind.IECDiag, LexemKind.Download,
                LexemKind.ExcludeFromAutoAddress, LexemKind.Comment
            };
            Lexem? propertyLexem;
            while ((propertyLexem = Match(proLexems)) is not null)
            {
                Require(LexemKind.Colon);
                switch (propertyLexem.Kind)
                {
                    case LexemKind.SectionName:
                        valueLexem = Require(LexemKind.String);
                        module.SectionName = TryGetValue<string>(valueLexem,
                            module.GetType().GetProperty(nameof(module.SectionName))) ?? string.Empty;
                        break;
                    case LexemKind.IndexInParent:
                        valueLexem = Require(LexemKind.String);
                        module.IndexInParent = TryGetValue<int>(valueLexem,
                            module.GetType().GetProperty(nameof(module.IndexInParent)));
                        break;
                    case LexemKind.ModuleName:
                        valueLexem = Require(LexemKind.String);
                        module.ModuleName = TryGetValue<string>(valueLexem,
                            module.GetType().GetProperty(nameof(module.ModuleName))) ?? string.Empty;
                        break;
                    case LexemKind.NodeId:
                        valueLexem = Require(LexemKind.Number);
                        module.NodeId = TryGetValue<int>(valueLexem,
                            module.GetType().GetProperty(nameof(module.NodeId)));
                        break;
                    case LexemKind.IECIn:
                        valueLexem = Require(LexemKind.IECAddress);
                        module.AddressIn = TryGetValue<IECAddress>(valueLexem,
                            module.GetType().GetProperty(nameof(module.AddressIn)));
                        break;
                    case LexemKind.IECOut:
                        valueLexem = Require(LexemKind.IECAddress);
                        module.AddressOut = TryGetValue<IECAddress>(valueLexem,
                            module.GetType().GetProperty(nameof(module.AddressOut)));
                        break;
                    case LexemKind.IECDiag:
                        valueLexem = Require(LexemKind.IECAddress);
                        module.AddressDiag = TryGetValue<IECAddress>(valueLexem,
                            module.GetType().GetProperty(nameof(module.AddressDiag)));
                        break;
                    case LexemKind.Download:
                        valueLexem = Require(LexemKind.Number);
                        module.IsDownload = TryGetValue<bool>(valueLexem,
                            module.GetType().GetProperty(nameof(module.IsDownload)));
                        break;
                    case LexemKind.ExcludeFromAutoAddress:
                        valueLexem = Require(LexemKind.Number);
                        module.IsExcludeFromAutoAddress = TryGetValue<bool>(valueLexem,
                            module.GetType().GetProperty(nameof(module.IsExcludeFromAutoAddress)));
                        break;
                    case LexemKind.Comment:
                        valueLexem = Require(LexemKind.String);
                        module.Comment = TryGetValue<string>(valueLexem,
                            module.GetType().GetProperty(nameof(module.Comment))) ?? string.Empty;
                        break;
                    default:
                        throw new InvalidOperationException($"На позиции {propertyLexem.Offset} недопустимое свойство {valueLexem.Kind}");
                }
            };
            //ParseParameters();
            Require(LexemKind.ModuleEnd);
            return module;
        }

        //private Channel? ParseChannel()
        //{
        //
        //    return null;
        //}
        //
        //private BitChannel? ParseBitChannel()
        //{
        //
        //    return null;
        //}

        //private object? ParseParameters()
        //{
        //    Require(LexemKind.ParametersBegin);
        //    while (InBounds())
        //    {
        //        ParseParameter();
        //    }
        //    Require(LexemKind.ParametersEnd);
        //    return null;
        //}

        //private object? ParseParameter()
        //{
        //    Require(LexemKind.Parameter);
        //    Require(LexemKind.Number);
        //    Require(LexemKind.Colon);
        //    Require(LexemKind.Number);
        //    Require(LexemKind.Comma);
        //    Require(LexemKind.String);
        //    return null;
        //}

        //private T? Attempt<T>(Func<T> getter) where T : Lexem
        //{
        //    var backup = _lexemIndex;
        //
        //    var result = getter();
        //    if (result is null)
        //        _lexemIndex = backup;
        //
        //    return result;
        //}

        //private T Ensure<T>(Func<T> getter, string msg) where T : Lexem =>
        //    Bind(getter) ?? throw new InvalidOperationException(msg);

        //private T? Bind<T>(Func<T> getter) where T : Lexem
        //{
        //    var startId = _lexemIndex;
        //    var lexemStart = _lexems[_lexemIndex];

        //    var result = getter();
        //    if (result is not null)
        //    {
        //        result.StartLocation = start.StartLocation;

        //        var endId = _lexemIndex;
        //        if (endId > startId && endId > 0)
        //            result.EndLocation = _lexems[_lexemIndex - 1].EndLocation;
        //    }

        //    return result;
        //}
    }
}

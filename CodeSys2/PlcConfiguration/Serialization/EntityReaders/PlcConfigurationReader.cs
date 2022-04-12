using CodeSys2.PlcConfiguration.Models;
using CodeSys2.PlcConfiguration.Serialization.Enums;

namespace CodeSys2.PlcConfiguration.Serialization.EntityReaders
{
    internal class PlcConfigurationReader : EntityReader
    {
        public PlcConfigurationReader(EntityReaderContext context) : base(context)
        {
        }

        public override object? Read()
        {
            _context.Require(LexemKind.ConfigurationBegin);

            var config = new PlcConfiguration();

            ReadGlobalOptions(config);

            // Check Module
            if (!_context.AnyOf(LexemKind.ModuleBegin))
                throw new InvalidOperationException("Конфигурация ПЛК должна иметь корневой модуль");

            // Reader
            var reader = EntityReaderProvider.GetReader(_context.Current.Kind, _context);
            if (reader is null)
                throw new InvalidOperationException();

            var rootEntity = reader.Read();
            if (rootEntity is null || rootEntity is not Module rootModule)
                throw new InvalidOperationException("Конфигурация ПЛК должна иметь корневой модуль");

            config.RootModule = rootModule;

            if (!_context.IsEnd)
                throw new Exception($"На позиции {_context.Current.Offset} ожидался конец файла конфигурации ПКЛ");

            return config;
        }

        private void ReadGlobalOptions(PlcConfiguration config)
        {
            _context.Require(LexemKind.GlobalOptionsBegin);

            var lexems = new LexemKind[] {
                LexemKind.Version,
                LexemKind.AutoAddress,
                LexemKind.CheckAddress,
                LexemKind.SaveConfigFilesInProject
            };

            Lexem? propertyLexem;
            while ((propertyLexem = _context.Match(lexems)) is not null)
            {
                _context.Require(LexemKind.Colon);
                var valueLexem = _context.Require(LexemKind.Number);
                switch (propertyLexem.Kind)
                {
                    case LexemKind.Version:
                        config.Version = _context.TryGetValue<int>(valueLexem);
                        break;

                    case LexemKind.AutoAddress:
                        config.AutoAddress = _context.TryGetValue<bool>(valueLexem);
                        break;

                    case LexemKind.CheckAddress:
                        config.CheckAddress = _context.TryGetValue<bool>(valueLexem);
                        break;

                    case LexemKind.SaveConfigFilesInProject:
                        config.SaveConfigInProject = _context.TryGetValue<bool>(valueLexem);
                        break;

                    default:
                        throw new InvalidOperationException($"На позиции {propertyLexem.Offset} недопустимое свойство {valueLexem.Kind}");
                }
            }

            _context.Require(LexemKind.GlobalOptionsEnd);
        }
    }
}

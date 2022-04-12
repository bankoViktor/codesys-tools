using CodeSys2.PlcConfiguration.Models;
using CodeSys2.PlcConfiguration.Serialization.Enums;

namespace CodeSys2.PlcConfiguration.Serialization.EntityReaders
{
    internal class ModuleReader : EntityReader
    {
        public ModuleReader(EntityReaderContext context) : base(context)
        {
        }

        public override object? Read()
        {
            _context.Require(LexemKind.ModuleBegin);

            var module = new Module();

            _context.Require(LexemKind.Colon);
            var valueLexem = _context.Require(LexemKind.String);
            module.Name = _context.TryGetValue<string>(valueLexem);

            ReadProperties(module);

            ReadChildren(module);

            _context.Require(LexemKind.ModuleEnd);
            return module;
        }

        private void ReadProperties(Module module)
        {
            var lexems = new LexemKind[]
            {
                LexemKind.SectionName,
                LexemKind.IndexInParent,
                LexemKind.ModuleName,
                LexemKind.NodeId,
                LexemKind.IECIn,
                LexemKind.IECOut,
                LexemKind.IECDiag,
                LexemKind.Download,
                LexemKind.ExcludeFromAutoAddress,
                LexemKind.Comment
            };

            Lexem? valueLexem;
            Lexem? propertyLexem;
            while ((propertyLexem = _context.Match(lexems)) is not null)
            {
                _context.Require(LexemKind.Colon);
                switch (propertyLexem.Kind)
                {
                    case LexemKind.SectionName:
                        valueLexem = _context.Require(LexemKind.String);
                        module.SectionName = _context.TryGetValue<string>(valueLexem);
                        break;

                    case LexemKind.IndexInParent:
                        valueLexem = _context.Require(LexemKind.String);
                        module.IndexInParent = _context.TryGetValue<int>(valueLexem);
                        break;

                    case LexemKind.ModuleName:
                        valueLexem = _context.Require(LexemKind.String);
                        module.ModuleName = _context.TryGetValue<string>(valueLexem);
                        break;

                    case LexemKind.NodeId:
                        valueLexem = _context.Require(LexemKind.Number);
                        module.NodeId = _context.TryGetValue<int>(valueLexem);
                        break;

                    case LexemKind.IECIn:
                        valueLexem = _context.Require(LexemKind.IECAddress);
                        module.AddressIn = _context.TryGetValue<IECAddress>(valueLexem);
                        break;

                    case LexemKind.IECOut:
                        valueLexem = _context.Require(LexemKind.IECAddress);
                        module.AddressOut = _context.TryGetValue<IECAddress>(valueLexem);
                        break;

                    case LexemKind.IECDiag:
                        valueLexem = _context.Require(LexemKind.IECAddress);
                        module.AddressDiag = _context.TryGetValue<IECAddress>(valueLexem);
                        break;

                    case LexemKind.Download:
                        valueLexem = _context.Require(LexemKind.Number);
                        module.IsDownload = _context.TryGetValue<bool>(valueLexem);
                        break;

                    case LexemKind.ExcludeFromAutoAddress:
                        valueLexem = _context.Require(LexemKind.Number);
                        module.IsExcludeFromAutoAddress = _context.TryGetValue<bool>(valueLexem);
                        break;

                    case LexemKind.Comment:
                        valueLexem = _context.Require(LexemKind.String);
                        module.Comment = _context.TryGetValue<string>(valueLexem);
                        break;

                    default:
                        throw new InvalidOperationException($"На позиции {propertyLexem.Offset} недопустимое свойство");
                }
            };
        }

        private void ReadChildren(Module module)
        {
            while (_context.AnyOf(LexemKind.ModuleBegin, LexemKind.ParametersBegin, LexemKind.ChannelBegin))
            {
                var reader = EntityReaderProvider.GetReader(_context.Current.Kind, _context);
                if (reader is null)
                    throw new InvalidOperationException();

                var obj = reader.Read();
                if (obj is null)
                    throw new InvalidOperationException($"На позиции {_context.Current.Offset} обнаружена ошибка");

                if (obj is Entity entity)
                {
                    module.Children.Add(entity);
                }
                else if (obj is List<Parameter> parameters)
                {
                    module.Parameters = parameters;
                }
                else
                {
                    throw new InvalidOperationException($"На позиции {_context.Current.Offset} недопустимое значение");
                }
            }
        }
    }
}

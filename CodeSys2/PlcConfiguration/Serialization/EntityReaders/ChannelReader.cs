using CodeSys2.PlcConfiguration.Models;
using CodeSys2.PlcConfiguration.Models.Enums;
using CodeSys2.PlcConfiguration.Serialization.Enums;

namespace CodeSys2.PlcConfiguration.Serialization.EntityReaders
{
    internal class ChannelReader : EntityReader
    {
        public ChannelReader(EntityReaderContext context) : base(context)
        {
        }

        public override object? Read()
        {
            _context.Require(LexemKind.ChannelBegin);

            var channel = new Channel();

            ReadProperties(channel);

            ReadChildren(channel);

            _context.Require(LexemKind.ChannelEnd);

            return channel;
        }

        private void ReadProperties(Channel channel)
        {
            var lexems = new LexemKind[] {
                LexemKind.SectionName,
                LexemKind.IndexInParent,
                LexemKind.SymbolicName,
                LexemKind.Comment,
                LexemKind.ChannelMode,
                LexemKind.IECAddress,
            };

            Lexem? propertyLexem;
            while ((propertyLexem = _context.Match(lexems)) is not null)
            {
                Lexem? valueLexem;
                _context.Require(expected: LexemKind.Colon);
                switch (propertyLexem.Kind)
                {
                    case LexemKind.SectionName:
                        valueLexem = _context.Require(expected: LexemKind.String);
                        channel.SectionName = _context.TryGetValue<string>(valueLexem);
                        break;

                    case LexemKind.IndexInParent:
                        valueLexem = _context.Require(expected: LexemKind.String);
                        channel.IndexInParent = _context.TryGetValue<int>(valueLexem);
                        break;

                    case LexemKind.SymbolicName:
                        valueLexem = _context.Require(expected: LexemKind.String);
                        channel.SymbolicName = _context.TryGetValue<string>(valueLexem);
                        break;

                    case LexemKind.Comment:
                        valueLexem = _context.Require(expected: LexemKind.String);
                        channel.Comment = _context.TryGetValue<string>(valueLexem);
                        break;

                    case LexemKind.ChannelMode:
                        valueLexem = _context.Require(expected: LexemKind.String);
                        channel.Mode = _context.TryGetValue<ChannelMode>(valueLexem);
                        break;

                    case LexemKind.IECAddress:
                        valueLexem = _context.Require(expected: LexemKind.IECAddress);
                        channel.Address = _context.TryGetValue<IECAddress>(valueLexem);
                        break;

                    default:
                        throw new InvalidOperationException($"На позиции {propertyLexem.Offset} недопустимое свойство");
                }
            };
        }

        private void ReadChildren(Channel channel)
        {
            while (_context.AnyOf(LexemKind.ParametersBegin, LexemKind.BitChannel))
            {
                var reader = EntityReaderProvider.GetReader(_context.Current.Kind, _context);
                if (reader is null)
                    throw new InvalidOperationException();

                var obj = reader.Read();
                if (obj is not null)
                {
                    if (obj is List<Parameter> parameters)
                        channel.Parameters = parameters;
                    else if (obj is BitChannel bitChannel)
                        channel.BitChannels.Add(bitChannel);
                    else
                        throw new NotSupportedException();
                }
            }
        }
    }
}

using CodeSys2.PlcConfiguration.Models;
using CodeSys2.PlcConfiguration.Serialization.Enums;

namespace CodeSys2.PlcConfiguration.Serialization.EntityReaders
{
    internal class BitChannelReader : EntityReader
    {
        public BitChannelReader(EntityReaderContext context) : base(context)
        {
        }

        public override object? Read()
        {
            _context.Require(LexemKind.BitChannel);

            var bitChannel = new BitChannel();

            Lexem lexem;

            lexem = _context.Require(LexemKind.Number);
            bitChannel.Index = _context.TryGetValue<int>(lexem);

            _context.Require(LexemKind.Colon);

            lexem = _context.Require(LexemKind.IECAddress);
            bitChannel.Address = _context.TryGetValue<IECAddress>(lexem);

            lexem = _context.Require(LexemKind.String);
            bitChannel.SymbolicName = _context.TryGetValue<string>(lexem) ?? string.Empty;

            lexem = _context.Require(LexemKind.String);
            bitChannel.Comment = _context.TryGetValue<string>(lexem) ?? string.Empty;

            return bitChannel;
        }
    }
}

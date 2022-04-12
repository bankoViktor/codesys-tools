using CodeSys2.PlcConfiguration.Models;
using CodeSys2.PlcConfiguration.Serialization.Enums;

namespace CodeSys2.PlcConfiguration.Serialization.EntityReaders
{
    internal class ParameterReader : EntityReader
    {
        public ParameterReader(EntityReaderContext context) : base(context)
        {
        }

        public override object? Read()
        {
            _context.Require(LexemKind.Parameter);

            var parameter = new Parameter();

            Lexem lexem;

            lexem = _context.Require(LexemKind.Number);
            parameter.Index = _context.TryGetValue<int>(lexem);

            _context.Require(LexemKind.Colon);

            lexem = _context.Require(LexemKind.Number);
            parameter.Unk = _context.TryGetValue<int>(lexem);

            _context.Require(LexemKind.Comma);

            lexem = _context.Require(LexemKind.String);
            parameter.Value = _context.TryGetValue<string>(lexem);

            return parameter;
        }
    }
}

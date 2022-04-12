using CodeSys2.PlcConfiguration.Models;
using CodeSys2.PlcConfiguration.Serialization.Enums;

namespace CodeSys2.PlcConfiguration.Serialization.EntityReaders
{
    internal class ParametersReader : EntityReader
    {
        public ParametersReader(EntityReaderContext context) : base(context)
        {
        }

        public override object? Read()
        {
            _context.Require(LexemKind.ParametersBegin);

            var parameters = new List<Parameter>();

            while (_context.AnyOf(LexemKind.Parameter))
            {
                var reader = EntityReaderProvider.GetReader(_context.Current.Kind, _context);
                if (reader is null)
                    throw new InvalidOperationException();

                var obj = reader.Read();
                if (obj is null || obj is not Parameter parameter)
                    throw new InvalidOperationException($"На позиции {_context.Current.Offset} неверно задан параметр");

                parameters.Add(parameter);
            }

            _context.Require(LexemKind.ParametersEnd);
            return parameters;
        }
    }
}

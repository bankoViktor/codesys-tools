using CodeSys2.PlcConfiguration.Serialization.EntityReaders;

namespace CodeSys2.PlcConfiguration.Serialization
{
    /// <summary>
    /// Синтаксический анализатор файла конфигурации ПЛК.
    /// </summary>
    internal sealed class Syntaxer
    {
        private readonly EntityReaderContext _context;


        public Syntaxer(IReadOnlyList<Lexem> lexems)
        {
            _context = new EntityReaderContext(lexems);
        }

        public PlcConfiguration? ParseConfiguration()
        {
            var reader = EntityReaderProvider.GetReader(_context.Current.Kind, _context);

            var obj = reader.Read();
            if (obj is not PlcConfiguration config)
                throw new Exception();

            return config;
        }
    }
}

namespace CodeSys2.PlcConfiguration.Serialization.EntityReaders
{
    internal abstract class EntityReader
    {
        protected readonly EntityReaderContext _context;


        public EntityReader(EntityReaderContext context)
        {
            _context = context;
        }

        public abstract object? Read();
    }
}

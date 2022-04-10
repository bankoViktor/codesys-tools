using CodeSys2.PlcConfiguration.Models;

namespace CodeSys2.PlcConfiguration.Serialization.EntityReaders
{
    internal static class EntityReaderProvider
    {
        private static readonly IDictionary<Type, Type> _entityReaders = new Dictionary<Type, Type>()
        {
            { typeof(PlcConfiguration), typeof(PlcConfigurationReader) },
            { typeof(Module), typeof(ModuleReader) },
            { typeof(Channel), typeof(ChannelReader) },
        };

        public static EntityReader GetReader(Type entityType)
        {
            if (entityType is null)
                throw new ArgumentNullException(nameof(entityType));

            if (!_entityReaders.ContainsKey(entityType))
                throw new KeyNotFoundException($"Тип {typeof(EntityReader).FullName} не задан для типа {entityType.FullName}");

            var entityReaderType = _entityReaders[entityType];
            if (entityReaderType is not null)
            {
                var obj = Activator.CreateInstance(entityType);
                if (obj is not null)
                {
                    return (EntityReader)obj;
                }
            }

            throw new InvalidOperationException("Не удалось определить экземпляр ридера для чтения элемента из конфигурации ПЛК");
        }
    }
}

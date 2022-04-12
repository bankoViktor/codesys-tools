using CodeSys2.PlcConfiguration.Serialization.Enums;

namespace CodeSys2.PlcConfiguration.Serialization.EntityReaders
{
    internal static class EntityReaderProvider
    {
        private static readonly IDictionary<LexemKind, Type> _entityReaders = new Dictionary<LexemKind, Type>()
        {
            { LexemKind.ConfigurationBegin, typeof(PlcConfigurationReader) },
            { LexemKind.ModuleBegin, typeof(ModuleReader) },
            { LexemKind.ParametersBegin, typeof(ParametersReader) },
            { LexemKind.Parameter, typeof(ParameterReader) },
            { LexemKind.ChannelBegin, typeof(ChannelReader) },
            { LexemKind.BitChannel, typeof(BitChannelReader) },
        };

        public static EntityReader GetReader(LexemKind lexemKind, EntityReaderContext context)
        {
            if (!_entityReaders.ContainsKey(lexemKind))
                throw new KeyNotFoundException($"Дочерний тип от {typeof(EntityReader).FullName} не задан для {lexemKind}");

            var entityReaderType = _entityReaders[lexemKind];
            if (entityReaderType is not null)
            {
                var obj = Activator.CreateInstance(entityReaderType, context);
                if (obj is not null)
                {
                    return (EntityReader)obj;
                }
            }

            throw new InvalidOperationException("Не удалось определить экземпляр ридера для чтения элемента из конфигурации ПЛК");
        }
    }
}

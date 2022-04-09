namespace CodeSys2.PlcConfiguration.Models
{
    /// <summary>
    /// Базовый класс элементов ПЛК конфигурации.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Название секции.
        /// </summary>
        public string SectionName { get; set; } = string.Empty;

        /// <summary>
        /// Индекс в родительском элементе.
        /// </summary>
        public int IndexInParent { get; set; } = -1;
        // TODO тип IndexInParent

        /// <summary>
        /// Комментарий.
        /// </summary>
        public string Comment { get; set; } = string.Empty;

        /// <summary>
        /// Параметры.
        /// </summary>
        public List<Parameter> Parameters { get; set; } = new();
    }
}

namespace CodeSys2.PlcConfiguration.Models
{
    /// <summary>
    /// Параметр модуля или канала в конфигурации ПЛК.
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Иднекс параметра в target-файле.
        /// </summary>
        public int Index { get; set; }

        // TODO неизвестное свойство
        public int Unk { get; set; }

        /// <summary>
        /// Значение параметра.
        /// </summary>
        public string Value { get; set; } = string.Empty;
    }
}

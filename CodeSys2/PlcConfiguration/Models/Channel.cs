using CodeSys2.PlcConfiguration.Models.Enums;

namespace CodeSys2.PlcConfiguration.Models
{
    /// <summary>
    /// Канал конфигурации ПЛК.
    /// </summary>
    public class Channel : Entity
    {
        /// <summary>
        /// Символическое имя (имя переменной) канала.
        /// </summary>
        public string SymbolicName { get; set; } = string.Empty;

        /// <summary>
        /// Режим канала.
        /// </summary>
        public ChannelMode Mode { get; set; } = ChannelMode.Input;

        /// <summary>
        /// IEC адрес канала.
        /// </summary>
        public IECAddress? Address { get; set; }
    }
}

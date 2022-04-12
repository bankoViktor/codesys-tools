using CodeSys2.PlcConfiguration.Models.Enums;
using System.Diagnostics;

namespace CodeSys2.PlcConfiguration.Models
{
    /// <summary>
    /// Канал конфигурации ПЛК.
    /// </summary>
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
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

        /// <summary>
        /// Битовые каналы.
        /// </summary>
        public List<BitChannel> BitChannels { get; set; } = new();

        private string GetDebuggerDisplay() => $"{{Channel: {Address} '{SymbolicName}' '{Comment}'}}";
    }
}

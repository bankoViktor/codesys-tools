using System.Diagnostics;

namespace CodeSys2.PlcConfiguration.Models
{
    /// <summary>
    /// Битовый канал конфигурации ПЛК.
    /// </summary>
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class BitChannel
    {
        /// <summary>
        /// Индекс канала.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// IEC адрес канала.
        /// </summary>
        public IECAddress? Address { get; set; }

        /// <summary>
        /// Символическое имя (имя переменной) канала.
        /// </summary>
        public string SymbolicName { get; set; } = string.Empty;

        /// <summary>
        /// Комментарий.
        /// </summary>
        public string Comment { get; set; } = string.Empty;

        private string GetDebuggerDisplay() => $"{{Bit {Index}: {Address} '{SymbolicName}' '{Comment}'}}";
    }
}

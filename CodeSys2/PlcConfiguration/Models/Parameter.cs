using System.Diagnostics;

namespace CodeSys2.PlcConfiguration.Models
{
    /// <summary>
    /// Параметр модуля или канала в конфигурации ПЛК.
    /// </summary>
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class Parameter
    {
        /// <summary>
        /// Иднекс параметра в target-файле.
        /// </summary>
        public int Index { get; set; }

        // TODO неизвестное свойство Parameter.Unk
        public int Unk { get; set; }

        /// <summary>
        /// Значение параметра.
        /// </summary>
        public string Value { get; set; } = string.Empty;

        private string GetDebuggerDisplay() => $"{{Param {Index}: {Unk}, '{Value}'}}";
    }
}

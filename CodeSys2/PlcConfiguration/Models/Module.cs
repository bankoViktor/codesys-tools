using System.Diagnostics;

namespace CodeSys2.PlcConfiguration.Models
{
    /// <summary>
    /// Модуль конфигурации ПЛК.
    /// </summary>
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class Module : Entity
    {
        /// <summary>
        /// Id модуля.
        /// </summary>
        public int NodeId { get; set; } = -1;

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Название модуля.
        /// </summary>
        public string ModuleName { get; set; } = string.Empty;

        /// <summary>
        /// Адрес в памяти входов.
        /// </summary>
        public IECAddress? AddressIn { get; set; }

        /// <summary>
        /// Адрес в памяти выходов.
        /// </summary>
        public IECAddress? AddressOut { get; set; }

        /// <summary>
        /// Адрес в памяти.
        /// </summary>
        public IECAddress? AddressDiag { get; set; }

        // TODO аннотация Module.IsDownload
        public bool IsDownload { get; set; } = false;

        /// <summary>
        /// Исключение модуля из авто вычисления IEC адреса.
        /// </summary>
        public bool IsExcludeFromAutoAddress { get; set; } = false;

        /// <summary>
        /// Дочерние модули и каналы.
        /// </summary>
        public List<Entity> Children { get; set; } = new();

        private string GetDebuggerDisplay() => $"{{Module: '{ModuleName}' {AddressIn} '{Comment}'}}";
    }
}

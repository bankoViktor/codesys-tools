using System.Diagnostics;

namespace CodeSys2.PlcTarget.Models
{
    /// <summary>
    /// Целевая платформа.
    /// </summary>
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class PlcTarget
    {
        /// <summary>
        /// Id целевой платформы.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Путь до таргет файла (*.TRG).
        /// </summary>
        public string Location { get; }

        /// <summary>
        /// Название целевой платформы.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Производитель.
        /// </summary>
        public string Vendor { get; }

        /// <summary>
        /// Версия целевой платформы.
        /// </summary>
        public string Version { get; }



        public PlcTarget(int id, string location, string name, string vendor, string version)
        {
            Id = id;
            Location = location;
            Name = name;
            Vendor = vendor;
            Version = version;
        }

        private string GetDebuggerDisplay() => $"{{{Name} - v{Version}}}";
    }
}

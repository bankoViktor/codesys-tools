using CodeSys2.PlcConfiguration.Models;

namespace CodeSys2.PlcConfiguration
{
    /// <summary>
    /// Конфигурация ПЛК в <b>CodeSys 2</b>.
    /// </summary>
    public class PlcConfiguration
    {
        /// <summary>
        /// Версия конфигурации.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Автоматическое вычисление адреса.
        /// </summary>
        public bool AutoAdress { get; set; }

        /// <summary>
        /// Проверка пересечения адресов.
        /// </summary>
        public bool CheckAddress { get; set; }

        /// <summary>
        /// Сохранять конфигурацию в файл проекта.
        /// </summary>
        public bool SaveConfigInProject { get; set; }

        /// <summary>
        /// Корневой модуль конфигурации.
        /// </summary>
        public Module? RootModule { get; set; }
    }
}

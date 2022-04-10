using CodeSys2.PlcConfiguration.Models;
using CodeSys2.PlcConfiguration.TypeConverters;
using System.ComponentModel;

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
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool AutoAdress { get; set; } = false;

        /// <summary>
        /// Проверка пересечения адресов.
        /// </summary>
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool CheckAddress { get; set; } = false;

        /// <summary>
        /// Сохранять конфигурацию в файл проекта.
        /// </summary>
        [TypeConverter(typeof(BooleanTypeConverter))]
        public bool SaveConfigInProject { get; set; } = false;

        /// <summary>
        /// Корневой модуль конфигурации.
        /// </summary>
        public Module? RootModule { get; set; }
    }
}

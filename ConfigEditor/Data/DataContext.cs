using CodeSys2.PlcConfiguration;
using CodeSys2.PlcConfiguration.Models;

namespace ConfigEditor.Data
{
    /// <summary>
    /// Контекст данных приложения.
    /// </summary>
    public class DataContext
    {
        /// <summary>
        /// Имя файла.
        /// </summary>
        public string? SourceFilename { get; set; }

        /// <summary>
        /// Проект был изменен.
        /// </summary>
        public bool IsModified { get; set; }

        /// <summary>
        /// Открытия конфигурация ПЛК.
        /// </summary>
        public PlcConfiguration Configuration { get; set; }


        public DataContext(string filename)
        {
            SourceFilename = filename;

            var text = File.ReadAllText(filename);
            Configuration = PlcConfigurationSerializer.Deserialize(text);
        }

        public DataContext()
        {
            Configuration = new PlcConfiguration
            {
                RootModule = new Module()
                {
                    SectionName = "Root",
                }
            };
            IsModified = false;
        }
    }
}

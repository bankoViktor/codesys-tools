using ConfigEditor.Data;
using ConfigEditor.Forms;

namespace ConfigEditor
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var dataContext = new DataContext()
            {
                SourceFilename = args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]) ? args[0] : null,
            };

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(dataContext));
        }
    }
}
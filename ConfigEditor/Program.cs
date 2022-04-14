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
            DataContext dataContext;

            if (args.Length == 1 && !string.IsNullOrWhiteSpace(args[0]))
            {
                dataContext = new DataContext(args[0]);
            }
            else
            {
                dataContext = new DataContext();
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(dataContext));
        }
    }
}
using CodeSys2.PlcConfiguration;
using ConfigEditor.Data;

namespace ConfigEditor.Forms
{
    public partial class MainForm : Form
    {
        private readonly DataContext _dataContext;


        public MainForm(DataContext dataContext)
        {
            InitializeComponent();

            _dataContext = dataContext;

            var text = File.ReadAllText(@"E:\PLC\Projects\test_2\PLC CONFIGURATION.EXP");
            var config = PlcConfigurationSerializer.Deserialize(text);
        }
    }
}
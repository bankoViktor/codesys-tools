using CodeSys2.PlcConfiguration;
using CodeSys2.PlcConfiguration.Models;
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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var text = File.ReadAllText(@"E:\PLC\Projects\test_2\PLC CONFIGURATION.EXP");
            var config = PlcConfigurationSerializer.Deserialize(text);

            var rootNode = CreateTreeNode(config.RootModule);
            treeView1.Nodes.Add(rootNode);
        }

        private TreeNode CreateTreeNode(object obj)
        {
            var node = new TreeNode()
            {
                Tag = obj,
            };

            if (obj is Module module)
            {
                node.Text = module.ModuleName;
                node.Nodes.AddRange(module.Children
                    .Select(child => CreateTreeNode(child))
                    .ToArray());
            }
            else if (obj is Channel channel)
            {
                node.Text = $"AT {channel.Address}: {channel.Address?.Size.ToString().ToUpper()}";
            }
            else if (obj is BitChannel bitChannel)
            {
                node.Text = $"AT {bitChannel.Address}: {bitChannel.Address?.Size.ToString().ToUpper()}";
            }
            else
            {
                throw new Exception();
            }

            return node;
        }
    }
}
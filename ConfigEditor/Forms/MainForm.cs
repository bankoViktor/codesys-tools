using CodeSys2.PlcConfiguration.Models;
using ConfigEditor.Data;
using ConfigEditor.ViewModels;
using System.Xml.Linq;

namespace ConfigEditor.Forms
{
    public partial class MainForm : Form
    {
        private readonly DataContext _dataContext;


        public MainForm(DataContext dataContext)
        {
            InitializeComponent();

            _dataContext = dataContext;

            Text = GetCaption();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TreeView.Nodes.Clear();

            if (_dataContext.Configuration.RootModule is not null)
            {
                var rootNode = CreateTreeNode(_dataContext.Configuration.RootModule);
                TreeView.Nodes.Add(rootNode);
            }
        }

        private TreeNode CreateTreeNode(object obj)
        {
            var node = new TreeNode();

            if (obj is Module module)
            {
                var vm = new ModuleViewModel(module);
                vm.Changed += ViewModel_Changed;
                node.Tag = vm;
                node.Text = vm.DisplayText;
                node.Nodes.AddRange(module.Children
                    .Select(child => CreateTreeNode(child))
                    .ToArray());
                node.ImageIndex = 0;
            }
            else if (obj is Channel channel)
            {
                var vm = new ChannelViewModel(channel);
                vm.Changed += ViewModel_Changed;
                node.Tag = vm;
                node.Text = vm.DisplayText;
                node.ImageIndex = 1;
            }
            else if (obj is BitChannel bitChannel)
            {
                var vm = new BitChannelViewModel(bitChannel);
                vm.Changed += ViewModel_Changed;
                node.Tag = vm;
                node.Text = vm.DisplayText;
                node.ImageIndex = 2;
            }
            else
            {
                throw new Exception();
            }

            return node;
        }

        private string GetCaption() => string.Format("{0}{1} - {2}",
            _dataContext.SourceFilename ?? "безыменный",
            _dataContext.IsModified ? "*" : string.Empty,
            Application.ProductName
        );

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is ModuleViewModel moduleViewModel)
            {
                PropertyGrid.SelectedObject = moduleViewModel;
            }
            else if (e.Node?.Tag is ChannelViewModel channelViewModel)
            {
                PropertyGrid.SelectedObject = channelViewModel;
            }
            else if (e.Node?.Tag is BitChannelViewModel bitChannelViewModel)
            {
                PropertyGrid.SelectedObject = bitChannelViewModel;
            }
            else
            {
                PropertyGrid.SelectedObject = null;
            }

            UpdateStateButton();
        }

        private void ViewModel_Changed(object? sender, ChangedEventArgs e)
        {
            if (sender is ModuleViewModel moduleViewModel)
            {
                TreeView.SelectedNode.Text = moduleViewModel.DisplayText;
            }
            else if (sender is ChannelViewModel channelViewModel)
            {
                TreeView.SelectedNode.Text = channelViewModel.DisplayText;
            }
            else if (sender is BitChannelViewModel bitChannelViewModel)
            {
                TreeView.SelectedNode.Text = bitChannelViewModel.DisplayText;
            }
            else
            {
                throw new Exception();
            }
        }

        private void UpdateStateButton()
        {
            var isSelected = TreeView.SelectedNode is not null;

            // File

            FileSaveToolStripMenuItem.Enabled = _dataContext.IsModified;

            // Edit

            EditCutToolStripMenuItem.Enabled = isSelected;
            EditCopyToolStripMenuItem.Enabled = isSelected;
            EditPasteToolStripMenuItem.Enabled = isSelected;
            EditDuplicateToolStripMenuItem.Enabled = isSelected;
            EditExpandToggleSegmentToolStripMenuItem.Enabled = isSelected;

            // Context

            CutToolStripMenuItem.Enabled = isSelected;
            CopyToolStripMenuItem.Enabled = isSelected;
            PasteToolStripMenuItem.Enabled = isSelected;
            DuplicateToolStripMenuItem.Enabled = isSelected;
            ExpandToggleSegmentToolStripMenuItem.Enabled = isSelected;
        }

        private TreeNode CreateModule()
        {
            var module = new Module();
            var moduleViewModel = new ModuleViewModel(module);
            moduleViewModel.Changed += ViewModel_Changed;
            return new TreeNode()
            {
                Tag = moduleViewModel,
                Text = moduleViewModel.DisplayText,
                ImageIndex = 0,
            };
        }

        #region StripMenuItem - File

        private void FileExitToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        #endregion

        #region StripMenuItem - Edit

        private void EditCutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EditCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EditPasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EditDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TreeView.SelectedNode is not null)
            {
                if (MessageBox.Show("Удалить узел и все его дочерние элементы?",
                    Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    TreeView.SelectedNode.Remove();
                }
            }
        }

        private void EditDuplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EditSelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EditExpandToggleSegmentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EditCollapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EditExpandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Context

        private void AddModuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = CreateModule();
            TreeView.SelectedNode.Nodes.Add(node);
            TreeView.SelectedNode.Expand();
        }

        #endregion

        #region StripMenuItem - Tools

        private void ToolsSelectSymbolNameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
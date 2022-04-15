using CodeSys2.PlcConfiguration.Models;
using ConfigEditor.Data;
using ConfigEditor.ViewModels;

namespace ConfigEditor.Forms
{
    public partial class MainForm : Form
    {
        #region Properties

        private readonly DataContext _context;

        #endregion

        #region Lifetime

        public MainForm(DataContext dataContext)
        {
            InitializeComponent();

            _context = dataContext;

            Text = GetCaption();
        }

        #endregion

        #region Form Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            EntityTreeView.Nodes.Clear();

            if (_context.Configuration.RootModule is not null)
            {
                var rootNode = CreateTreeNode(_context.Configuration.RootModule);
                EntityTreeView.Nodes.Add(rootNode);
            }

            EntityTreeView.Nodes[0]?.Expand();
        }

        #endregion

        #region EntityTreeView Events

        private void EntityTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            PropertyGrid.SelectedObject =
                e.Node?.Tag is ModuleViewModel moduleViewModel ? moduleViewModel :
                e.Node?.Tag is ChannelViewModel channelViewModel ? channelViewModel :
                e.Node?.Tag is BitChannelViewModel bitChannelViewModel ? bitChannelViewModel :
                null;

            UpdateStateButton();
        }

        private void EntityTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) =>
            EntityTreeView.SelectedNode = e.Node;

        #endregion

        private TreeNode CreateTreeNode(object obj)
        {
            var node = new TreeNode();

            if (obj is Module module)
            {
                var vm = new ModuleViewModel(module);
                vm.Changed += ViewModel_Changed;
                node.Tag = vm;
                node.Text = vm.DisplayText;
                node.ImageIndex = 0;
                node.Nodes.AddRange(module.Children
                    .Select(child => CreateTreeNode(child))
                    .ToArray());
            }
            else if (obj is Channel channel)
            {
                var vm = new ChannelViewModel(channel);
                vm.Changed += ViewModel_Changed;
                node.Tag = vm;
                node.Text = vm.DisplayText;
                node.ImageIndex = 1;
                node.Nodes.AddRange(channel.BitChannels
                   .Select(child => CreateTreeNode(child))
                   .ToArray());
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
            _context.SourceFilename ?? "безыменный",
            _context.IsModified ? "*" : string.Empty,
            Application.ProductName);

        private void UpdateStateButton()
        {
            var isSelected = EntityTreeView.SelectedNode is not null;

            // File

            FileSaveToolStripMenuItem.Enabled = _context.IsModified;

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
            if (EntityTreeView.SelectedNode is not null)
            {
                if (MessageBox.Show("Удалить узел и все его дочерние элементы?",
                    Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    EntityTreeView.SelectedNode.Remove();
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

        #region StripMenuItem - Tools

        private void ToolsSelectSymbolNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new SymbolForm(_context, EntityTreeView);
            dlg.ShowDialog();
        }

        #endregion

        #region Context

        private void AddModuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = CreateModule();
            EntityTreeView.SelectedNode.Nodes.Add(node);
            EntityTreeView.SelectedNode.Expand();
        }

        #endregion

        private void ViewModel_Changed(object? sender, ChangedEventArgs e)
        {
            EntityTreeView.SelectedNode.Text =
                sender is ModuleViewModel moduleViewModel ? moduleViewModel.DisplayText :
                sender is ChannelViewModel channelViewModel ? channelViewModel.DisplayText :
                sender is BitChannelViewModel bitChannelViewModel ? bitChannelViewModel.DisplayText :
                throw new Exception();
        }
    }
}
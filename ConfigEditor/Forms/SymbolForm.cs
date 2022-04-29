using CodeSys2.PlcConfiguration.Models;
using ConfigEditor.Data;
using ConfigEditor.ViewModels;

namespace ConfigEditor.Forms
{
    public partial class SymbolForm : Form
    {
        private readonly DataContext _context;
        private readonly TreeView _treeView;


        public SymbolForm(DataContext context, TreeView treeView)
        {
            InitializeComponent();

            _context = context;
            _treeView = treeView;

            SymbolListView.Items.Clear();
            SymbolListView.Items.AddRange(treeView.Nodes
                .Cast<TreeNode>()
                .SelectMany(x => SelectSymbols(x))
                .ToArray());
        }

        private IEnumerable<ListViewItem> SelectSymbols(TreeNode node)
        {
            foreach (TreeNode childNode in node.Nodes)
            {
                if (childNode.Tag is ModuleViewModel moduleViewModel)
                {
                    return SelectSymbols(childNode);
                }
                else if (childNode.Tag is ChannelViewModel channelViewModel)
                {
                    if (childNode.Nodes.Count > 0)
                    {
                        return SelectSymbols(childNode);
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(channelViewModel.SymbolicName))
                        {
                            return new ListViewItem[]
                            {
                                CreateItem(
                                    channelViewModel.SymbolicName,
                                    channelViewModel.Address,
                                    0,
                                    0),
                            };
                        }
                    }
                }
                else if (childNode.Tag is BitChannelViewModel bitChannelViewModel)
                {
                    if (!string.IsNullOrWhiteSpace(bitChannelViewModel.SymbolicName))
                    {
                        return new ListViewItem[]
                        {
                            CreateItem(
                                bitChannelViewModel.SymbolicName,
                                bitChannelViewModel.Address,
                                0,
                                0),
                        };
                    }
                }
                else
                {
                    throw new Exception();
                }
            }

            return Array.Empty<ListViewItem>();
        }

        private ListViewItem CreateItem(string symbol, IECAddress address, int wordOffset, int bitOffset)
        {
            var subItem = new ListViewItem.ListViewSubItem[]
            {
                new ListViewItem.ListViewSubItem(null, symbol),
                new ListViewItem.ListViewSubItem(null, address.Size.ToString().ToUpper(), Color.Blue, Color.Transparent, Font),
                new ListViewItem.ListViewSubItem(null, address.ToString()),
                new ListViewItem.ListViewSubItem(null, wordOffset.ToString()),
                new ListViewItem.ListViewSubItem(null, bitOffset.ToString()),
            };
            return new ListViewItem(subItem, -1);
        }
    }
}

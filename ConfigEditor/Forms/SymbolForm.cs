using ConfigEditor.Data;

namespace ConfigEditor.Forms
{
    public partial class SymbolForm : Form
    {
        private readonly DataContext _context;


        public SymbolForm(DataContext context, TreeView treeView)
        {
            InitializeComponent();

            _context = context;
        }
    }
}

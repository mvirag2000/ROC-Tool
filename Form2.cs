using System.Data;
using System.Windows.Forms;

namespace ROC_Tool
{
    public partial class Form2 : Form
    {
        public Form2(DataTable showTable)
        {
            InitializeComponent();
            dataGridView1.DataSource = showTable;
        }
    }
}

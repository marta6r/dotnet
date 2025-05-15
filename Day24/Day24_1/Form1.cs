using System.Xml.Linq;

namespace Day24_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void spWin_Click(object sender, EventArgs e)
        {
            spWin.Text = "Windows is cascade";
        }

        private void spData_Click(object sender, EventArgs e)
        {
            spWin.Text = "Windows is horizontal";
        }
    }

}



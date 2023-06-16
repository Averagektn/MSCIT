using System.Windows.Forms;

namespace ControlFlow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            tbCode.Clear();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                tbCode.Text = File.ReadAllText(filename);
            }
        }

        private void Count_Click(object sender, EventArgs e)
        {
            Parser parser = new();
            if (tbCode.Text != string.Empty)
            {
                parser.Parse(tbCode.Lines);
            }
            else
            {
                parser.CL = 0;
                parser.CL_Relative = 0;
                parser.CLI = 0;
            }
            lblCL.Text = "CL: " + parser.CL;
            lblCL_Relative.Text = "cl: " + parser.CL_Relative;
            lblCLI.Text = "CLI: " + parser.CLI;
        }
    }
}
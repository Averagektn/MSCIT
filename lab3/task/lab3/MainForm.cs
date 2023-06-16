using System.Windows.Forms;

namespace lab3
{
    public partial class MainForm : Form
    {
        private string src = string.Empty;
        public MainForm()
        {
            InitializeComponent();
        }

        private void ChooseFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                src = openFileDialog.FileName;
                tbCode.Text = string.Empty;
                using var sr = new StreamReader(src);
                string? line;
                while((line = sr.ReadLine()) != null)
                {
                    tbCode.AppendText(line + "\r\n");
                }
            }
        }

        private void Count_Click(object sender, EventArgs e)
        {
            if (src != string.Empty)
            {
                dgvChepinFull.Rows.Clear();
                dgvChepinIO.Rows.Clear();
                dgvSpen.Rows.Clear();

                int height = dgvChepinFull.Rows[0].Height;
                dgvChepinFull.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvChepinIO.DefaultCellStyle.WrapMode = DataGridViewTriState.True; ;
                dgvSpen.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                // FULL
                Dictionary<string, Chepin.Group> res = Chepin.Count(src, false);
                string[] p = (from pair in res where pair.Value.Equals(Chepin.Group.P) select pair.Key).ToArray();
                string[] m = (from pair in res where pair.Value.Equals(Chepin.Group.M) select pair.Key).ToArray();
                string[] c = (from pair in res where pair.Value.Equals(Chepin.Group.C) select pair.Key).ToArray();
                string[] t = (from pair in res where pair.Value.Equals(Chepin.Group.T) select pair.Key).ToArray();

                string joinedP = string.Join(", ", p);
                string joinedM = string.Join(", ", m);
                string joinedC = string.Join(", ", c);
                string joinedT = string.Join(", ", t);

                float metric = Chepin.CalculateMetric(res);

                dgvChepinFull.Rows.Add(joinedP, joinedM, joinedC, joinedT);
                dgvChepinFull.Rows[0].Height = height * Math.Max(Math.Max(p.Length, m.Length), Math.Max(c.Length, t.Length));
                dgvChepinFull.Rows.Add(p.Length, m.Length, c.Length, t.Length);
                dgvChepinFull.Rows.Add("Total: ", metric);

                Dictionary<string, int> spens = Chepin.Spen;
                foreach(var spen in spens)
                {
                    dgvSpen.Rows.Add(dgvSpen.Rows.Count, spen.Key, spen.Value);
                }
                var totalSpen = Chepin.TotalSpen;
                dgvSpen.Rows.Add("", "Total:", totalSpen);

                // IO
                res = Chepin.Count(src, true);
                p = (from pair in res where pair.Value.Equals(Chepin.Group.P) select pair.Key).ToArray();
                m = (from pair in res where pair.Value.Equals(Chepin.Group.M) select pair.Key).ToArray();
                c = (from pair in res where pair.Value.Equals(Chepin.Group.C) select pair.Key).ToArray();
                t = (from pair in res where pair.Value.Equals(Chepin.Group.T) select pair.Key).ToArray();

                joinedP = string.Join(", ", p);
                joinedM = string.Join(", ", m);
                joinedC = string.Join(", ", c);
                joinedT = string.Join(", ", t);
                metric = Chepin.CalculateMetric(res);

                dgvChepinIO.Rows.Add(joinedP, joinedM, joinedC, joinedT);
                dgvChepinIO.Rows[0].Height = height * Math.Max(Math.Max(p.Length, m.Length), Math.Max(c.Length, t.Length));
                dgvChepinIO.Rows.Add(p.Length, m.Length, c.Length, t.Length);
                dgvChepinIO.Rows.Add("Total: ", metric);


            }
            else
            {
                MessageBox.Show(Chepin.Group.C.ToString());
                MessageBox.Show("File not selected");
            }
        }
    }
}
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Go
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeGrid(gridOperands);
            InitializeGrid(gridOperators);
        }

        static void InitializeGrid(DataGridView grid)
        {
            var numColumn = new DataGridViewTextBoxColumn();
            var opColumn = new DataGridViewTextBoxColumn();
            var countColumn = new DataGridViewTextBoxColumn();

            numColumn.Name = "numColumn";
            numColumn.HeaderText = "¹";

            if (grid.Name == "gridOperators")
                opColumn.HeaderText = "Operator";
            else
                opColumn.HeaderText = "Operand";

            opColumn.Name = "opColumnColumn";


            countColumn.Name = "countColumn";
            countColumn.HeaderText = "Number";

            grid.Columns.AddRange(numColumn, opColumn, countColumn);
        }

        private void Parse_Click(object sender, EventArgs e)
        {
            Holstead.functions = new();
            Holstead.operands = new();
            Holstead.operators = new()
            {
                {"++", 0}, {"--", 0}, {"+", 0 }, {"-", 0 }, {"*", 0 }, {"/", 0 }, {"%", 0 },
                {"&&", 0}, {"||", 0}, {">>", 0}, {"<<", 0}, {"&", 0 }, {"|", 0 }, {"^", 0 },
                {">=", 0}, {"<=", 0}, {"==", 0}, {"!=", 0}, {">", 0 }, {"<", 0 },
                {"!", 0 },
                {"[", 0 }, {"{", 0 },
                {":", 0 },

                {"if",0}, {"else", 0}, {"switch", 0}, {"case", 0}, {"default", 0}, {"for", 0}, {"break", 0}, {"continue", 0}, {"goto", 0}
            };
            for (int i = 0; i < tbCode.Lines.Length; i++)
            {
                Holstead.Parse(tbCode.Lines[i]);
            }
            FillTable(gridOperands, Holstead.operands);
            Dictionary<string, int> ops = new(Holstead.operators.Union(Holstead.functions));
            FillTable(gridOperators, ops);

            int counter = 0;
            foreach(var op in ops)
            {
                if (op.Value != 0)
                {
                    counter++;
                }
            }

            int dictionary = counter + Holstead.operands.Count;
            lblDictionary.Text = "Dictionary: " + dictionary;
            int length = 0;
            foreach (var c in Holstead.operands)
            {
                length += c.Value;
            }
            foreach (var c in ops)
            {
                length += c.Value;
            }
            lblLength.Text = "Length: " + length;
            int volume = (int)(length * Math.Log(dictionary) / Math.Log(2));
            lblVolume.Text = "Volume: " + volume;  
        }

        public static void FillTable(DataGridView table, Dictionary<string, int> dictionary)
        {
            table.Rows.Clear();

            int i = 1, sum = 0;
            DataGridViewRow row;
            DataGridViewTextBoxCell num, op, count;
            foreach (var c in dictionary)
            {
                if (c.Value != 0)
                {
                    row = new DataGridViewRow();

                    num = new DataGridViewTextBoxCell();
                    op = new DataGridViewTextBoxCell();
                    count = new DataGridViewTextBoxCell();

                    num.Value = i++;
                    op.Value = c.Key;
                    count.Value = c.Value;
                    sum += c.Value;

                    row.Cells.AddRange(num, op, count);
                    table.Rows.Add(row);
                }
            }

            row = new DataGridViewRow();
            num = new DataGridViewTextBoxCell(); num.Value = "Sum";
            op = new DataGridViewTextBoxCell(); op.Value = "";
            count = new DataGridViewTextBoxCell(); count.Value = sum;
            row.Cells.AddRange(num, op, count);
            table.Rows.Add(row);
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
    }
}

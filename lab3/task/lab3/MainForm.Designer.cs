namespace lab3
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCount = new System.Windows.Forms.Button();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.dgvSpen = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Variable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvChepinFull = new System.Windows.Forms.DataGridView();
            this.P = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.T = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvChepinIO = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblChepinFull = new System.Windows.Forms.Label();
            this.lblChepinIO = new System.Windows.Forms.Label();
            this.lblSpen = new System.Windows.Forms.Label();
            this.lblSourceCode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChepinFull)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChepinIO)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCount
            // 
            this.btnCount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCount.Location = new System.Drawing.Point(1055, 540);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(150, 75);
            this.btnCount.TabIndex = 0;
            this.btnCount.Text = "Count";
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Click += new System.EventHandler(this.Count_Click);
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnChooseFile.Location = new System.Drawing.Point(787, 540);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(150, 75);
            this.btnChooseFile.TabIndex = 1;
            this.btnChooseFile.Text = "Choose file...";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.ChooseFile_Click);
            // 
            // tbCode
            // 
            this.tbCode.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbCode.Location = new System.Drawing.Point(743, 43);
            this.tbCode.Multiline = true;
            this.tbCode.Name = "tbCode";
            this.tbCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbCode.Size = new System.Drawing.Size(513, 491);
            this.tbCode.TabIndex = 2;
            // 
            // dgvSpen
            // 
            this.dgvSpen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSpen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Variable,
            this.Spen});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSpen.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSpen.Location = new System.Drawing.Point(466, 43);
            this.dgvSpen.Name = "dgvSpen";
            this.dgvSpen.RowTemplate.Height = 28;
            this.dgvSpen.Size = new System.Drawing.Size(273, 491);
            this.dgvSpen.TabIndex = 3;
            // 
            // ID
            // 
            this.ID.HeaderText = "№";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 30;
            // 
            // Variable
            // 
            this.Variable.HeaderText = "Variable";
            this.Variable.Name = "Variable";
            this.Variable.ReadOnly = true;
            // 
            // Spen
            // 
            this.Spen.HeaderText = "Spen";
            this.Spen.Name = "Spen";
            this.Spen.ReadOnly = true;
            // 
            // dgvChepinFull
            // 
            this.dgvChepinFull.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChepinFull.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.P,
            this.M,
            this.C,
            this.T});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChepinFull.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvChepinFull.Location = new System.Drawing.Point(14, 43);
            this.dgvChepinFull.Name = "dgvChepinFull";
            this.dgvChepinFull.RowTemplate.Height = 28;
            this.dgvChepinFull.Size = new System.Drawing.Size(446, 248);
            this.dgvChepinFull.TabIndex = 4;
            // 
            // P
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.P.DefaultCellStyle = dataGridViewCellStyle2;
            this.P.HeaderText = "P";
            this.P.Name = "P";
            this.P.ReadOnly = true;
            // 
            // M
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.M.DefaultCellStyle = dataGridViewCellStyle3;
            this.M.HeaderText = "M";
            this.M.Name = "M";
            this.M.ReadOnly = true;
            // 
            // C
            // 
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.C.DefaultCellStyle = dataGridViewCellStyle4;
            this.C.HeaderText = "C";
            this.C.Name = "C";
            this.C.ReadOnly = true;
            // 
            // T
            // 
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.T.DefaultCellStyle = dataGridViewCellStyle5;
            this.T.HeaderText = "T";
            this.T.Name = "T";
            this.T.ReadOnly = true;
            // 
            // dgvChepinIO
            // 
            this.dgvChepinIO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChepinIO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChepinIO.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvChepinIO.Location = new System.Drawing.Point(14, 331);
            this.dgvChepinIO.Name = "dgvChepinIO";
            this.dgvChepinIO.RowTemplate.Height = 28;
            this.dgvChepinIO.Size = new System.Drawing.Size(444, 203);
            this.dgvChepinIO.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "P";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "M";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "C";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "T";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // lblChepinFull
            // 
            this.lblChepinFull.AutoSize = true;
            this.lblChepinFull.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblChepinFull.Location = new System.Drawing.Point(189, 15);
            this.lblChepinFull.Name = "lblChepinFull";
            this.lblChepinFull.Size = new System.Drawing.Size(104, 25);
            this.lblChepinFull.TabIndex = 6;
            this.lblChepinFull.Text = "Chepin full";
            // 
            // lblChepinIO
            // 
            this.lblChepinIO.AutoSize = true;
            this.lblChepinIO.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblChepinIO.Location = new System.Drawing.Point(155, 303);
            this.lblChepinIO.Name = "lblChepinIO";
            this.lblChepinIO.Size = new System.Drawing.Size(184, 25);
            this.lblChepinIO.TabIndex = 7;
            this.lblChepinIO.Text = "Chepin input/output";
            // 
            // lblSpen
            // 
            this.lblSpen.AutoSize = true;
            this.lblSpen.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSpen.Location = new System.Drawing.Point(565, 15);
            this.lblSpen.Name = "lblSpen";
            this.lblSpen.Size = new System.Drawing.Size(54, 25);
            this.lblSpen.TabIndex = 8;
            this.lblSpen.Text = "Spen";
            // 
            // lblSourceCode
            // 
            this.lblSourceCode.AutoSize = true;
            this.lblSourceCode.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSourceCode.Location = new System.Drawing.Point(938, 15);
            this.lblSourceCode.Name = "lblSourceCode";
            this.lblSourceCode.Size = new System.Drawing.Size(116, 25);
            this.lblSourceCode.TabIndex = 9;
            this.lblSourceCode.Text = "Source code";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 640);
            this.Controls.Add(this.lblSourceCode);
            this.Controls.Add(this.lblSpen);
            this.Controls.Add(this.lblChepinIO);
            this.Controls.Add(this.lblChepinFull);
            this.Controls.Add(this.dgvChepinIO);
            this.Controls.Add(this.dgvChepinFull);
            this.Controls.Add(this.dgvSpen);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.btnCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Chepin";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChepinFull)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChepinIO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnCount;
        private Button btnChooseFile;
        private TextBox tbCode;
        private DataGridView dgvSpen;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Variable;
        private DataGridViewTextBoxColumn Spen;
        private DataGridView dgvChepinFull;
        private DataGridView dgvChepinIO;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private OpenFileDialog openFileDialog;
        private DataGridViewTextBoxColumn P;
        private DataGridViewTextBoxColumn M;
        private DataGridViewTextBoxColumn C;
        private DataGridViewTextBoxColumn T;
        private Label lblChepinFull;
        private Label lblChepinIO;
        private Label lblSpen;
        private Label lblSourceCode;
    }
}
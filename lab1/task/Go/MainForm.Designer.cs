namespace Go
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
            this.gridOperands = new System.Windows.Forms.DataGridView();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.btnParse = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.gridOperators = new System.Windows.Forms.DataGridView();
            this.lblDictionary = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblVolume = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gridOperands)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOperators)).BeginInit();
            this.SuspendLayout();
            // 
            // gridOperands
            // 
            this.gridOperands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOperands.Location = new System.Drawing.Point(12, 0);
            this.gridOperands.Name = "gridOperands";
            this.gridOperands.ReadOnly = true;
            this.gridOperands.RowTemplate.Height = 28;
            this.gridOperands.Size = new System.Drawing.Size(353, 461);
            this.gridOperands.TabIndex = 0;
            // 
            // tbCode
            // 
            this.tbCode.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbCode.Location = new System.Drawing.Point(770, 0);
            this.tbCode.Multiline = true;
            this.tbCode.Name = "tbCode";
            this.tbCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbCode.Size = new System.Drawing.Size(353, 461);
            this.tbCode.TabIndex = 1;
            // 
            // btnParse
            // 
            this.btnParse.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnParse.Location = new System.Drawing.Point(770, 467);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(344, 40);
            this.btnParse.TabIndex = 2;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.Parse_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLoad.Location = new System.Drawing.Point(895, 519);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 40);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.Load_Click);
            // 
            // gridOperators
            // 
            this.gridOperators.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOperators.Location = new System.Drawing.Point(393, 0);
            this.gridOperators.Name = "gridOperators";
            this.gridOperators.ReadOnly = true;
            this.gridOperators.RowTemplate.Height = 28;
            this.gridOperators.Size = new System.Drawing.Size(353, 461);
            this.gridOperators.TabIndex = 4;
            // 
            // lblDictionary
            // 
            this.lblDictionary.AutoSize = true;
            this.lblDictionary.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDictionary.Location = new System.Drawing.Point(12, 467);
            this.lblDictionary.Name = "lblDictionary";
            this.lblDictionary.Size = new System.Drawing.Size(107, 25);
            this.lblDictionary.TabIndex = 5;
            this.lblDictionary.Text = "Dictionary: ";
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLength.Location = new System.Drawing.Point(12, 492);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(79, 25);
            this.lblLength.TabIndex = 6;
            this.lblLength.Text = "Length: ";
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblVolume.Location = new System.Drawing.Point(12, 517);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(85, 25);
            this.lblVolume.TabIndex = 7;
            this.lblVolume.Text = "Volume: ";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 629);
            this.Controls.Add(this.lblVolume);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.lblDictionary);
            this.Controls.Add(this.gridOperators);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.gridOperands);
            this.Name = "MainForm";
            this.Text = "Go";
            ((System.ComponentModel.ISupportInitialize)(this.gridOperands)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOperators)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView gridOperands;
        private TextBox tbCode;
        private Button btnParse;
        private Button btnLoad;
        private DataGridView gridOperators;
        private Label lblDictionary;
        private Label lblLength;
        private Label lblVolume;
        private OpenFileDialog openFileDialog;
    }
}
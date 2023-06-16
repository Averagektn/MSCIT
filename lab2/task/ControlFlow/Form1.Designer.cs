namespace ControlFlow
{
    partial class Form1
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnLoad = new System.Windows.Forms.Button();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.lblCL = new System.Windows.Forms.Label();
            this.lblCL_Relative = new System.Windows.Forms.Label();
            this.lblCLI = new System.Windows.Forms.Label();
            this.btnCount = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLoad.Location = new System.Drawing.Point(341, 504);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(122, 52);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.Load_Click);
            // 
            // tbCode
            // 
            this.tbCode.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbCode.Location = new System.Drawing.Point(12, 50);
            this.tbCode.Multiline = true;
            this.tbCode.Name = "tbCode";
            this.tbCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbCode.Size = new System.Drawing.Size(776, 381);
            this.tbCode.TabIndex = 1;
            // 
            // lblCL
            // 
            this.lblCL.AutoSize = true;
            this.lblCL.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCL.Location = new System.Drawing.Point(47, 9);
            this.lblCL.Name = "lblCL";
            this.lblCL.Size = new System.Drawing.Size(37, 25);
            this.lblCL.TabIndex = 2;
            this.lblCL.Text = "CL:";
            // 
            // lblCL_Relative
            // 
            this.lblCL_Relative.AutoSize = true;
            this.lblCL_Relative.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCL_Relative.Location = new System.Drawing.Point(356, 9);
            this.lblCL_Relative.Name = "lblCL_Relative";
            this.lblCL_Relative.Size = new System.Drawing.Size(30, 25);
            this.lblCL_Relative.TabIndex = 3;
            this.lblCL_Relative.Text = "cl:";
            // 
            // lblCLI
            // 
            this.lblCLI.AutoSize = true;
            this.lblCLI.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCLI.Location = new System.Drawing.Point(589, 9);
            this.lblCLI.Name = "lblCLI";
            this.lblCLI.Size = new System.Drawing.Size(42, 25);
            this.lblCLI.TabIndex = 4;
            this.lblCLI.Text = "CLI:";
            // 
            // btnCount
            // 
            this.btnCount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCount.Location = new System.Drawing.Point(341, 437);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(122, 52);
            this.btnCount.TabIndex = 5;
            this.btnCount.Text = "Count";
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Click += new System.EventHandler(this.Count_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 568);
            this.Controls.Add(this.btnCount);
            this.Controls.Add(this.lblCLI);
            this.Controls.Add(this.lblCL_Relative);
            this.Controls.Add(this.lblCL);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.btnLoad);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenFileDialog openFileDialog;
        private Button btnLoad;
        private TextBox tbCode;
        private Label lblCL;
        private Label lblCL_Relative;
        private Label lblCLI;
        private Button btnCount;
    }
}
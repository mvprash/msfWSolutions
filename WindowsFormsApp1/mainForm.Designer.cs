
namespace WindowsFormsApp1
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdImport = new System.Windows.Forms.Button();
            this.cmdBarCodes = new System.Windows.Forms.Button();
            this.textBoxXAxis = new System.Windows.Forms.TextBox();
            this.textBoxYAxis = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdImport
            // 
            this.cmdImport.Location = new System.Drawing.Point(62, 40);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(182, 61);
            this.cmdImport.TabIndex = 0;
            this.cmdImport.Text = "Import Inventory";
            this.cmdImport.UseVisualStyleBackColor = true;
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
            // 
            // cmdBarCodes
            // 
            this.cmdBarCodes.Location = new System.Drawing.Point(269, 40);
            this.cmdBarCodes.Name = "cmdBarCodes";
            this.cmdBarCodes.Size = new System.Drawing.Size(182, 61);
            this.cmdBarCodes.TabIndex = 1;
            this.cmdBarCodes.Text = "Create Bar Codes";
            this.cmdBarCodes.UseVisualStyleBackColor = true;
            this.cmdBarCodes.Click += new System.EventHandler(this.cmdBarCodes_Click);
            // 
            // textBoxXAxis
            // 
            this.textBoxXAxis.Location = new System.Drawing.Point(481, 40);
            this.textBoxXAxis.Name = "textBoxXAxis";
            this.textBoxXAxis.Size = new System.Drawing.Size(100, 20);
            this.textBoxXAxis.TabIndex = 2;
            // 
            // textBoxYAxis
            // 
            this.textBoxYAxis.Location = new System.Drawing.Point(481, 66);
            this.textBoxYAxis.Name = "textBoxYAxis";
            this.textBoxYAxis.Size = new System.Drawing.Size(100, 20);
            this.textBoxYAxis.TabIndex = 3;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxYAxis);
            this.Controls.Add(this.textBoxXAxis);
            this.Controls.Add(this.cmdBarCodes);
            this.Controls.Add(this.cmdImport);
            this.Name = "mainForm";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdImport;
        private System.Windows.Forms.Button cmdBarCodes;
        private System.Windows.Forms.TextBox textBoxXAxis;
        private System.Windows.Forms.TextBox textBoxYAxis;
    }
}


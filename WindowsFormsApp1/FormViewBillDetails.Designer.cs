
namespace MSFWSoftSolutions
{
    partial class FormViewBillDetails
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
            this.dataGridViewBillDetails = new System.Windows.Forms.DataGridView();
            this.btbClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBillDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewBillDetails
            // 
            this.dataGridViewBillDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBillDetails.Location = new System.Drawing.Point(29, 35);
            this.dataGridViewBillDetails.Name = "dataGridViewBillDetails";
            this.dataGridViewBillDetails.Size = new System.Drawing.Size(745, 215);
            this.dataGridViewBillDetails.TabIndex = 0;
            // 
            // btbClose
            // 
            this.btbClose.Location = new System.Drawing.Point(338, 283);
            this.btbClose.Name = "btbClose";
            this.btbClose.Size = new System.Drawing.Size(75, 23);
            this.btbClose.TabIndex = 1;
            this.btbClose.Text = "Close";
            this.btbClose.UseVisualStyleBackColor = true;
            this.btbClose.Click += new System.EventHandler(this.btbClose_Click);
            // 
            // FormViewBillDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 361);
            this.Controls.Add(this.btbClose);
            this.Controls.Add(this.dataGridViewBillDetails);
            this.Name = "FormViewBillDetails";
            this.Text = "FormViewBillDetails";
            this.Load += new System.EventHandler(this.FormViewBillDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBillDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewBillDetails;
        private System.Windows.Forms.Button btbClose;
    }
}
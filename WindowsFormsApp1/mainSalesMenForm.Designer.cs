
namespace MSFWSoftSolutions
{
    partial class mainSalesMenForm
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
            this.btnNewBill = new System.Windows.Forms.Button();
            this.dataGridViewGeneratedBills = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTSales = new System.Windows.Forms.Label();
            this.dataGridViewIncentiveDetails = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGeneratedBills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIncentiveDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNewBill
            // 
            this.btnNewBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewBill.Location = new System.Drawing.Point(29, 25);
            this.btnNewBill.Name = "btnNewBill";
            this.btnNewBill.Size = new System.Drawing.Size(182, 61);
            this.btnNewBill.TabIndex = 5;
            this.btnNewBill.Text = "New Bill";
            this.btnNewBill.UseVisualStyleBackColor = true;
            this.btnNewBill.Click += new System.EventHandler(this.btnNewBill_Click);
            // 
            // dataGridViewGeneratedBills
            // 
            this.dataGridViewGeneratedBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGeneratedBills.Location = new System.Drawing.Point(251, 25);
            this.dataGridViewGeneratedBills.Name = "dataGridViewGeneratedBills";
            this.dataGridViewGeneratedBills.Size = new System.Drawing.Size(919, 285);
            this.dataGridViewGeneratedBills.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(251, 326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 61);
            this.button1.TabIndex = 7;
            this.button1.Text = "Print Bill";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTSales
            // 
            this.lblTSales.AutoSize = true;
            this.lblTSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTSales.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTSales.Location = new System.Drawing.Point(1173, 25);
            this.lblTSales.Name = "lblTSales";
            this.lblTSales.Size = new System.Drawing.Size(14, 24);
            this.lblTSales.TabIndex = 8;
            this.lblTSales.Text = "I";
            // 
            // dataGridViewIncentiveDetails
            // 
            this.dataGridViewIncentiveDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIncentiveDetails.Location = new System.Drawing.Point(251, 405);
            this.dataGridViewIncentiveDetails.Name = "dataGridViewIncentiveDetails";
            this.dataGridViewIncentiveDetails.Size = new System.Drawing.Size(919, 285);
            this.dataGridViewIncentiveDetails.TabIndex = 9;
            // 
            // mainSalesMenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 726);
            this.Controls.Add(this.dataGridViewIncentiveDetails);
            this.Controls.Add(this.lblTSales);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewGeneratedBills);
            this.Controls.Add(this.btnNewBill);
            this.Name = "mainSalesMenForm";
            this.Text = "mainSalesMenForm";
            this.Load += new System.EventHandler(this.mainSalesMenForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGeneratedBills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIncentiveDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewBill;
        private System.Windows.Forms.DataGridView dataGridViewGeneratedBills;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblTSales;
        private System.Windows.Forms.DataGridView dataGridViewIncentiveDetails;
    }
}
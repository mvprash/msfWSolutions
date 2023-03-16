
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
            this.dateTimePickerFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerToDate = new System.Windows.Forms.DateTimePicker();
            this.lblDigital = new System.Windows.Forms.Label();
            this.lblCash = new System.Windows.Forms.Label();
            this.lblDigitalValue = new System.Windows.Forms.Label();
            this.lblCashValue = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
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
            this.lblTSales.Location = new System.Drawing.Point(1176, 286);
            this.lblTSales.Name = "lblTSales";
            this.lblTSales.Size = new System.Drawing.Size(107, 24);
            this.lblTSales.TabIndex = 8;
            this.lblTSales.Text = "Total Sales:";
            // 
            // dataGridViewIncentiveDetails
            // 
            this.dataGridViewIncentiveDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIncentiveDetails.Location = new System.Drawing.Point(251, 405);
            this.dataGridViewIncentiveDetails.Name = "dataGridViewIncentiveDetails";
            this.dataGridViewIncentiveDetails.Size = new System.Drawing.Size(919, 285);
            this.dataGridViewIncentiveDetails.TabIndex = 9;
            // 
            // dateTimePickerFromDate
            // 
            this.dateTimePickerFromDate.Location = new System.Drawing.Point(1330, 25);
            this.dateTimePickerFromDate.Name = "dateTimePickerFromDate";
            this.dateTimePickerFromDate.Size = new System.Drawing.Size(205, 20);
            this.dateTimePickerFromDate.TabIndex = 10;
            this.dateTimePickerFromDate.Value = new System.DateTime(2023, 3, 14, 19, 40, 29, 0);
            this.dateTimePickerFromDate.ValueChanged += new System.EventHandler(this.dateTimePickerFromDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(1176, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "From Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(1176, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "To Date";
            // 
            // dateTimePickerToDate
            // 
            this.dateTimePickerToDate.Location = new System.Drawing.Point(1330, 66);
            this.dateTimePickerToDate.Name = "dateTimePickerToDate";
            this.dateTimePickerToDate.Size = new System.Drawing.Size(205, 20);
            this.dateTimePickerToDate.TabIndex = 12;
            this.dateTimePickerToDate.ValueChanged += new System.EventHandler(this.dateTimePickerToDate_ValueChanged);
            // 
            // lblDigital
            // 
            this.lblDigital.AutoSize = true;
            this.lblDigital.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDigital.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblDigital.Location = new System.Drawing.Point(1176, 129);
            this.lblDigital.Name = "lblDigital";
            this.lblDigital.Size = new System.Drawing.Size(152, 24);
            this.lblDigital.TabIndex = 14;
            this.lblDigital.Text = "Digital Payments:";
            // 
            // lblCash
            // 
            this.lblCash.AutoSize = true;
            this.lblCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCash.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCash.Location = new System.Drawing.Point(1176, 207);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(145, 24);
            this.lblCash.TabIndex = 15;
            this.lblCash.Text = "Cash Payments:";
            // 
            // lblDigitalValue
            // 
            this.lblDigitalValue.AutoSize = true;
            this.lblDigitalValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDigitalValue.ForeColor = System.Drawing.Color.Blue;
            this.lblDigitalValue.Location = new System.Drawing.Point(1334, 129);
            this.lblDigitalValue.Name = "lblDigitalValue";
            this.lblDigitalValue.Size = new System.Drawing.Size(22, 31);
            this.lblDigitalValue.TabIndex = 16;
            this.lblDigitalValue.Text = "I";
            // 
            // lblCashValue
            // 
            this.lblCashValue.AutoSize = true;
            this.lblCashValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashValue.ForeColor = System.Drawing.Color.Blue;
            this.lblCashValue.Location = new System.Drawing.Point(1334, 207);
            this.lblCashValue.Name = "lblCashValue";
            this.lblCashValue.Size = new System.Drawing.Size(22, 31);
            this.lblCashValue.TabIndex = 17;
            this.lblCashValue.Text = "I";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalValue.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalValue.Location = new System.Drawing.Point(1334, 286);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(22, 31);
            this.lblTotalValue.TabIndex = 18;
            this.lblTotalValue.Text = "I";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(488, 326);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 61);
            this.button2.TabIndex = 19;
            this.button2.Text = "View Bill";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // mainSalesMenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1547, 726);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblTotalValue);
            this.Controls.Add(this.lblCashValue);
            this.Controls.Add(this.lblDigitalValue);
            this.Controls.Add(this.lblCash);
            this.Controls.Add(this.lblDigital);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerToDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerFromDate);
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
        private System.Windows.Forms.DateTimePicker dateTimePickerFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerToDate;
        private System.Windows.Forms.Label lblDigital;
        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.Label lblDigitalValue;
        private System.Windows.Forms.Label lblCashValue;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Button button2;
    }
}
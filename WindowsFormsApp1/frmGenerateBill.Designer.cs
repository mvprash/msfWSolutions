
namespace WindowsFormsApp1
{
    partial class frmGenerateBill
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
            this.textItemCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetDetails = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.itemCode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ItemColor = new System.Windows.Forms.Label();
            this.ItemBrand = new System.Windows.Forms.Label();
            this.ItemSellingPrice = new System.Windows.Forms.Label();
            this.ItemLastPrice = new System.Windows.Forms.Label();
            this.btnGenerateBill = new System.Windows.Forms.Button();
            this.ItemSoldPrice = new System.Windows.Forms.Label();
            this.textItemSoldPrice = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textItemCode
            // 
            this.textItemCode.Location = new System.Drawing.Point(384, 47);
            this.textItemCode.Name = "textItemCode";
            this.textItemCode.Size = new System.Drawing.Size(100, 20);
            this.textItemCode.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(286, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "ItemCode";
            // 
            // btnGetDetails
            // 
            this.btnGetDetails.Location = new System.Drawing.Point(508, 45);
            this.btnGetDetails.Name = "btnGetDetails";
            this.btnGetDetails.Size = new System.Drawing.Size(75, 23);
            this.btnGetDetails.TabIndex = 2;
            this.btnGetDetails.Text = "Get Details";
            this.btnGetDetails.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textItemSoldPrice);
            this.panel1.Controls.Add(this.ItemSoldPrice);
            this.panel1.Controls.Add(this.ItemLastPrice);
            this.panel1.Controls.Add(this.ItemSellingPrice);
            this.panel1.Controls.Add(this.ItemBrand);
            this.panel1.Controls.Add(this.ItemColor);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.itemCode);
            this.panel1.Location = new System.Drawing.Point(12, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 282);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // itemCode
            // 
            this.itemCode.AutoSize = true;
            this.itemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemCode.ForeColor = System.Drawing.SystemColors.Highlight;
            this.itemCode.Location = new System.Drawing.Point(23, 60);
            this.itemCode.Name = "itemCode";
            this.itemCode.Size = new System.Drawing.Size(79, 20);
            this.itemCode.TabIndex = 5;
            this.itemCode.Text = "ItemCode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(23, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "ItemDesc";
            // 
            // ItemColor
            // 
            this.ItemColor.AutoSize = true;
            this.ItemColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemColor.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ItemColor.Location = new System.Drawing.Point(23, 98);
            this.ItemColor.Name = "ItemColor";
            this.ItemColor.Size = new System.Drawing.Size(78, 20);
            this.ItemColor.TabIndex = 7;
            this.ItemColor.Text = "ItemColor";
            // 
            // ItemBrand
            // 
            this.ItemBrand.AutoSize = true;
            this.ItemBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemBrand.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ItemBrand.Location = new System.Drawing.Point(23, 131);
            this.ItemBrand.Name = "ItemBrand";
            this.ItemBrand.Size = new System.Drawing.Size(84, 20);
            this.ItemBrand.TabIndex = 8;
            this.ItemBrand.Text = "ItemBrand";
            // 
            // ItemSellingPrice
            // 
            this.ItemSellingPrice.AutoSize = true;
            this.ItemSellingPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemSellingPrice.ForeColor = System.Drawing.Color.Red;
            this.ItemSellingPrice.Location = new System.Drawing.Point(409, 19);
            this.ItemSellingPrice.Name = "ItemSellingPrice";
            this.ItemSellingPrice.Size = new System.Drawing.Size(145, 24);
            this.ItemSellingPrice.TabIndex = 9;
            this.ItemSellingPrice.Text = "ItemSellingPrice";
            // 
            // ItemLastPrice
            // 
            this.ItemLastPrice.AutoSize = true;
            this.ItemLastPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemLastPrice.ForeColor = System.Drawing.Color.Red;
            this.ItemLastPrice.Location = new System.Drawing.Point(409, 60);
            this.ItemLastPrice.Name = "ItemLastPrice";
            this.ItemLastPrice.Size = new System.Drawing.Size(121, 24);
            this.ItemLastPrice.TabIndex = 10;
            this.ItemLastPrice.Text = "ItemLastPrice";
            // 
            // btnGenerateBill
            // 
            this.btnGenerateBill.Location = new System.Drawing.Point(38, 391);
            this.btnGenerateBill.Name = "btnGenerateBill";
            this.btnGenerateBill.Size = new System.Drawing.Size(75, 23);
            this.btnGenerateBill.TabIndex = 5;
            this.btnGenerateBill.Text = "GenerateBill";
            this.btnGenerateBill.UseVisualStyleBackColor = true;
            // 
            // ItemSoldPrice
            // 
            this.ItemSoldPrice.AutoSize = true;
            this.ItemSoldPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemSoldPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ItemSoldPrice.Location = new System.Drawing.Point(409, 220);
            this.ItemSoldPrice.Name = "ItemSoldPrice";
            this.ItemSoldPrice.Size = new System.Drawing.Size(108, 20);
            this.ItemSoldPrice.TabIndex = 11;
            this.ItemSoldPrice.Text = "ItemSoldPrice";
            // 
            // textItemSoldPrice
            // 
            this.textItemSoldPrice.Location = new System.Drawing.Point(555, 220);
            this.textItemSoldPrice.Name = "textItemSoldPrice";
            this.textItemSoldPrice.Size = new System.Drawing.Size(100, 20);
            this.textItemSoldPrice.TabIndex = 6;
            // 
            // frmGenerateBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGenerateBill);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGetDetails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textItemCode);
            this.Name = "frmGenerateBill";
            this.Text = "frmGenerateBill";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textItemCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetDetails;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ItemBrand;
        private System.Windows.Forms.Label ItemColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label itemCode;
        private System.Windows.Forms.Label ItemLastPrice;
        private System.Windows.Forms.Label ItemSellingPrice;
        private System.Windows.Forms.Button btnGenerateBill;
        private System.Windows.Forms.TextBox textItemSoldPrice;
        private System.Windows.Forms.Label ItemSoldPrice;
    }
}
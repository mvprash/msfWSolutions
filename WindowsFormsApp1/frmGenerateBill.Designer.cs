
namespace MSFWSoftSolutions
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetDetails = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ItemInvID = new System.Windows.Forms.Label();
            this.textQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonViewLsellingPrice = new System.Windows.Forms.Button();
            this.textItemSoldPrice = new System.Windows.Forms.TextBox();
            this.ItemSoldPrice = new System.Windows.Forms.Label();
            this.ItemSellingPrice = new System.Windows.Forms.Label();
            this.ItemBrand = new System.Windows.Forms.Label();
            this.ItemColor = new System.Windows.Forms.Label();
            this.itemDesc = new System.Windows.Forms.Label();
            this.itemCode = new System.Windows.Forms.Label();
            this.btnGenerateBill = new System.Windows.Forms.Button();
            this.textItemCode = new System.Windows.Forms.TextBox();
            this.dataGridViewBillItem = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTotalBillAmount = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textCash = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textDigital = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBillItem)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(410, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "ItemCode";
            // 
            // btnGetDetails
            // 
            this.btnGetDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetDetails.Location = new System.Drawing.Point(792, 38);
            this.btnGetDetails.Name = "btnGetDetails";
            this.btnGetDetails.Size = new System.Drawing.Size(244, 44);
            this.btnGetDetails.TabIndex = 2;
            this.btnGetDetails.Text = "Get Details";
            this.btnGetDetails.UseVisualStyleBackColor = true;
            this.btnGetDetails.Click += new System.EventHandler(this.btnGetDetails_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ItemInvID);
            this.panel1.Controls.Add(this.textQuantity);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonViewLsellingPrice);
            this.panel1.Controls.Add(this.textItemSoldPrice);
            this.panel1.Controls.Add(this.ItemSoldPrice);
            this.panel1.Controls.Add(this.ItemSellingPrice);
            this.panel1.Controls.Add(this.ItemBrand);
            this.panel1.Controls.Add(this.ItemColor);
            this.panel1.Controls.Add(this.itemDesc);
            this.panel1.Controls.Add(this.itemCode);
            this.panel1.Location = new System.Drawing.Point(33, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1475, 339);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ItemInvID
            // 
            this.ItemInvID.AutoSize = true;
            this.ItemInvID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemInvID.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ItemInvID.Location = new System.Drawing.Point(23, 166);
            this.ItemInvID.Name = "ItemInvID";
            this.ItemInvID.Size = new System.Drawing.Size(14, 20);
            this.ItemInvID.TabIndex = 15;
            this.ItemInvID.Text = "I";
            // 
            // textQuantity
            // 
            this.textQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textQuantity.Location = new System.Drawing.Point(1261, 282);
            this.textQuantity.Multiline = true;
            this.textQuantity.Name = "textQuantity";
            this.textQuantity.Size = new System.Drawing.Size(75, 44);
            this.textQuantity.TabIndex = 13;
            this.textQuantity.TextChanged += new System.EventHandler(this.textQuantity_TextChanged);
            this.textQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textQuantity_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(1041, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 31);
            this.label3.TabIndex = 14;
            this.label3.Text = "Quantity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(1041, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 31);
            this.label2.TabIndex = 12;
            this.label2.Text = "Selling Price";
            // 
            // buttonViewLsellingPrice
            // 
            this.buttonViewLsellingPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonViewLsellingPrice.Location = new System.Drawing.Point(1226, 73);
            this.buttonViewLsellingPrice.Name = "buttonViewLsellingPrice";
            this.buttonViewLsellingPrice.Size = new System.Drawing.Size(205, 64);
            this.buttonViewLsellingPrice.TabIndex = 6;
            this.buttonViewLsellingPrice.Text = "OK";
            this.buttonViewLsellingPrice.UseVisualStyleBackColor = true;
            this.buttonViewLsellingPrice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonViewLsellingPrice_MouseDown);
            this.buttonViewLsellingPrice.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonViewLsellingPrice_MouseUp);
            // 
            // textItemSoldPrice
            // 
            this.textItemSoldPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textItemSoldPrice.Location = new System.Drawing.Point(1261, 231);
            this.textItemSoldPrice.Multiline = true;
            this.textItemSoldPrice.Name = "textItemSoldPrice";
            this.textItemSoldPrice.Size = new System.Drawing.Size(203, 44);
            this.textItemSoldPrice.TabIndex = 6;
            this.textItemSoldPrice.TextChanged += new System.EventHandler(this.textItemSoldPrice_TextChanged);
            this.textItemSoldPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textItemSoldPrice_KeyPress);
            // 
            // ItemSoldPrice
            // 
            this.ItemSoldPrice.AutoSize = true;
            this.ItemSoldPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemSoldPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ItemSoldPrice.Location = new System.Drawing.Point(1041, 231);
            this.ItemSoldPrice.Name = "ItemSoldPrice";
            this.ItemSoldPrice.Size = new System.Drawing.Size(197, 31);
            this.ItemSoldPrice.TabIndex = 11;
            this.ItemSoldPrice.Text = "Item Sold Price";
            // 
            // ItemSellingPrice
            // 
            this.ItemSellingPrice.AutoSize = true;
            this.ItemSellingPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemSellingPrice.ForeColor = System.Drawing.Color.Red;
            this.ItemSellingPrice.Location = new System.Drawing.Point(1222, 23);
            this.ItemSellingPrice.Name = "ItemSellingPrice";
            this.ItemSellingPrice.Size = new System.Drawing.Size(22, 31);
            this.ItemSellingPrice.TabIndex = 9;
            this.ItemSellingPrice.Text = "I";
            // 
            // ItemBrand
            // 
            this.ItemBrand.AutoSize = true;
            this.ItemBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemBrand.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ItemBrand.Location = new System.Drawing.Point(23, 131);
            this.ItemBrand.Name = "ItemBrand";
            this.ItemBrand.Size = new System.Drawing.Size(14, 20);
            this.ItemBrand.TabIndex = 8;
            this.ItemBrand.Text = "I";
            // 
            // ItemColor
            // 
            this.ItemColor.AutoSize = true;
            this.ItemColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemColor.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ItemColor.Location = new System.Drawing.Point(23, 98);
            this.ItemColor.Name = "ItemColor";
            this.ItemColor.Size = new System.Drawing.Size(14, 20);
            this.ItemColor.TabIndex = 7;
            this.ItemColor.Text = "I";
            // 
            // itemDesc
            // 
            this.itemDesc.AutoSize = true;
            this.itemDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemDesc.ForeColor = System.Drawing.SystemColors.Highlight;
            this.itemDesc.Location = new System.Drawing.Point(23, 24);
            this.itemDesc.Name = "itemDesc";
            this.itemDesc.Size = new System.Drawing.Size(14, 20);
            this.itemDesc.TabIndex = 6;
            this.itemDesc.Text = "I";
            // 
            // itemCode
            // 
            this.itemCode.AutoSize = true;
            this.itemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemCode.ForeColor = System.Drawing.SystemColors.Highlight;
            this.itemCode.Location = new System.Drawing.Point(23, 60);
            this.itemCode.Name = "itemCode";
            this.itemCode.Size = new System.Drawing.Size(14, 20);
            this.itemCode.TabIndex = 5;
            this.itemCode.Text = "I";
            this.itemCode.Click += new System.EventHandler(this.itemCode_Click);
            // 
            // btnGenerateBill
            // 
            this.btnGenerateBill.Location = new System.Drawing.Point(618, 768);
            this.btnGenerateBill.Name = "btnGenerateBill";
            this.btnGenerateBill.Size = new System.Drawing.Size(133, 29);
            this.btnGenerateBill.TabIndex = 5;
            this.btnGenerateBill.Text = "GenerateBill";
            this.btnGenerateBill.UseVisualStyleBackColor = true;
            this.btnGenerateBill.Click += new System.EventHandler(this.btnGenerateBill_Click);
            // 
            // textItemCode
            // 
            this.textItemCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textItemCode.Location = new System.Drawing.Point(569, 38);
            this.textItemCode.Multiline = true;
            this.textItemCode.Name = "textItemCode";
            this.textItemCode.Size = new System.Drawing.Size(203, 44);
            this.textItemCode.TabIndex = 13;
            this.textItemCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textItemCode_KeyPress);
            // 
            // dataGridViewBillItem
            // 
            this.dataGridViewBillItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBillItem.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewBillItem.Location = new System.Drawing.Point(618, 429);
            this.dataGridViewBillItem.Name = "dataGridViewBillItem";
            this.dataGridViewBillItem.Size = new System.Drawing.Size(890, 250);
            this.dataGridViewBillItem.TabIndex = 14;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(457, 429);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(133, 29);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(457, 475);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(133, 29);
            this.btnRemove.TabIndex = 16;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(768, 768);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(133, 29);
            this.btnReset.TabIndex = 17;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(612, 700);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 31);
            this.label4.TabIndex = 16;
            this.label4.Text = "Total Bill Amount:";
            // 
            // labelTotalBillAmount
            // 
            this.labelTotalBillAmount.AutoSize = true;
            this.labelTotalBillAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalBillAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelTotalBillAmount.Location = new System.Drawing.Point(833, 701);
            this.labelTotalBillAmount.Name = "labelTotalBillAmount";
            this.labelTotalBillAmount.Size = new System.Drawing.Size(22, 31);
            this.labelTotalBillAmount.TabIndex = 18;
            this.labelTotalBillAmount.Text = "I";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textCash);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textDigital);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(940, 687);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(568, 75);
            this.panel2.TabIndex = 19;
            // 
            // textCash
            // 
            this.textCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCash.Location = new System.Drawing.Point(261, 17);
            this.textCash.Multiline = true;
            this.textCash.Name = "textCash";
            this.textCash.Size = new System.Drawing.Size(75, 29);
            this.textCash.TabIndex = 17;
            this.textCash.Text = "0";
            this.textCash.TextChanged += new System.EventHandler(this.textCash_TextChanged);
            this.textCash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCash_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(187, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 29);
            this.label6.TabIndex = 18;
            this.label6.Text = "Cash";
            // 
            // textDigital
            // 
            this.textDigital.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDigital.Location = new System.Drawing.Point(106, 17);
            this.textDigital.Multiline = true;
            this.textDigital.Name = "textDigital";
            this.textDigital.Size = new System.Drawing.Size(75, 29);
            this.textDigital.TabIndex = 16;
            this.textDigital.Text = "0";
            this.textDigital.TextChanged += new System.EventHandler(this.textDigital_TextChanged);
            this.textDigital.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textDigital_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(30, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 29);
            this.label5.TabIndex = 16;
            this.label5.Text = "Digital";
            // 
            // frmGenerateBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1520, 815);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelTotalBillAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridViewBillItem);
            this.Controls.Add(this.textItemCode);
            this.Controls.Add(this.btnGenerateBill);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGetDetails);
            this.Controls.Add(this.label1);
            this.Name = "frmGenerateBill";
            this.Text = "frmGenerateBill";
            this.Load += new System.EventHandler(this.frmGenerateBill_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBillItem)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetDetails;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ItemBrand;
        private System.Windows.Forms.Label ItemColor;
        private System.Windows.Forms.Label itemDesc;
        private System.Windows.Forms.Label itemCode;
        private System.Windows.Forms.Label ItemSellingPrice;
        private System.Windows.Forms.Button btnGenerateBill;
        private System.Windows.Forms.TextBox textItemSoldPrice;
        private System.Windows.Forms.Label ItemSoldPrice;
        private System.Windows.Forms.Button buttonViewLsellingPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textItemCode;
        private System.Windows.Forms.TextBox textQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ItemInvID;
        private System.Windows.Forms.DataGridView dataGridViewBillItem;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelTotalBillAmount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textCash;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textDigital;
        private System.Windows.Forms.Label label5;
    }
}
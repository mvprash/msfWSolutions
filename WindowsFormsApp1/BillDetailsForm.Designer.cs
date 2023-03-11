
namespace MSFWSoftSolutions
{
    partial class BillDetailsForm
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
            this.PromptLabel = new System.Windows.Forms.Label();
            this.textBoxSoldPrice = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.textItemDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PromptLabel
            // 
            this.PromptLabel.AutoSize = true;
            this.PromptLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PromptLabel.Location = new System.Drawing.Point(63, 58);
            this.PromptLabel.Name = "PromptLabel";
            this.PromptLabel.Size = new System.Drawing.Size(137, 31);
            this.PromptLabel.TabIndex = 0;
            this.PromptLabel.Text = "Sold Price";
            // 
            // textBoxSoldPrice
            // 
            this.textBoxSoldPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSoldPrice.Location = new System.Drawing.Point(236, 57);
            this.textBoxSoldPrice.MaxLength = 4;
            this.textBoxSoldPrice.Multiline = true;
            this.textBoxSoldPrice.Name = "textBoxSoldPrice";
            this.textBoxSoldPrice.Size = new System.Drawing.Size(119, 44);
            this.textBoxSoldPrice.TabIndex = 1;
            this.textBoxSoldPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSoldPrice_KeyPress);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(188, 183);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // textItemDescription
            // 
            this.textItemDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textItemDescription.Location = new System.Drawing.Point(236, 119);
            this.textItemDescription.MaxLength = 6;
            this.textItemDescription.Multiline = true;
            this.textItemDescription.Name = "textItemDescription";
            this.textItemDescription.Size = new System.Drawing.Size(459, 44);
            this.textItemDescription.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Description";
            // 
            // BillDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 227);
            this.Controls.Add(this.textItemDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.textBoxSoldPrice);
            this.Controls.Add(this.PromptLabel);
            this.Name = "BillDetailsForm";
            this.Text = "BillDetailsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PromptLabel;
        private System.Windows.Forms.TextBox textBoxSoldPrice;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox textItemDescription;
        private System.Windows.Forms.Label label1;
    }
}

namespace MSFWSoftSolutions
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelSelected = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
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
            this.cmdBarCodes.Location = new System.Drawing.Point(1143, 604);
            this.cmdBarCodes.Name = "cmdBarCodes";
            this.cmdBarCodes.Size = new System.Drawing.Size(182, 61);
            this.cmdBarCodes.TabIndex = 1;
            this.cmdBarCodes.Text = "Create Bar Codes";
            this.cmdBarCodes.UseVisualStyleBackColor = true;
            this.cmdBarCodes.Click += new System.EventHandler(this.cmdBarCodes_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(62, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 61);
            this.button1.TabIndex = 4;
            this.button1.Text = "Import Sizes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Location = new System.Drawing.Point(300, 184);
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.Size = new System.Drawing.Size(1025, 414);
            this.dataGridViewItems.TabIndex = 5;
            this.dataGridViewItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewItems_CellContentClick);
            this.dataGridViewItems.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewItems_CellMouseDown);
            this.dataGridViewItems.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewItems_CellMouseUp);
            this.dataGridViewItems.MouseLeave += new System.EventHandler(this.dataGridViewItems_MouseLeave);
            this.dataGridViewItems.MouseHover += new System.EventHandler(this.dataGridViewItems_MouseHover);
            this.dataGridViewItems.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridViewItems_MouseMove);
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(300, 635);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(164, 20);
            this.textSearch.TabIndex = 6;
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.Location = new System.Drawing.Point(300, 606);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectAll.TabIndex = 7;
            this.buttonSelectAll.Text = "Select All";
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(893, 606);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Total Selected";
            // 
            // labelSelected
            // 
            this.labelSelected.AutoSize = true;
            this.labelSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelected.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelSelected.Location = new System.Drawing.Point(1029, 606);
            this.labelSelected.Name = "labelSelected";
            this.labelSelected.Size = new System.Drawing.Size(14, 24);
            this.labelSelected.TabIndex = 9;
            this.labelSelected.Text = "l";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 674);
            this.Controls.Add(this.labelSelected);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSelectAll);
            this.Controls.Add(this.textSearch);
            this.Controls.Add(this.dataGridViewItems);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdBarCodes);
            this.Controls.Add(this.cmdImport);
            this.Name = "mainForm";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.mainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdImport;
        private System.Windows.Forms.Button cmdBarCodes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.Button buttonSelectAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSelected;
    }
}


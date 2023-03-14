using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSFWSoftSolutions
{
    public partial class FormViewBillDetails : Form
    {
        MSFWEntities2 msfWContext = new MSFWEntities2();
        public long InvoiceID { get; set; }
        public FormViewBillDetails()
        {
            InitializeComponent();
        }

        private void FormViewBillDetails_Load(object sender, EventArgs e)
        {


            try
            {
                var billDetails = msfWContext.InvoiceItems.Include("ItemSize").Where(x => x.InvoiceID == this.InvoiceID).ToList();
                dataGridViewBillDetails.ReadOnly = true;
                dataGridViewBillDetails.DataSource = billDetails;

                dataGridViewBillDetails.Columns[0].Visible = false;
                dataGridViewBillDetails.Columns[1].Visible = false;
                dataGridViewBillDetails.Columns[2].Visible = false;
                dataGridViewBillDetails.Columns[6].Visible = false;
                dataGridViewBillDetails.Columns[7].Visible = false;
                dataGridViewBillDetails.Columns[8].Visible = false;
                dataGridViewBillDetails.Columns[9].Visible = false;
                dataGridViewBillDetails.Columns[10].Visible = false;


                // Create a new column
                DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();
                newColumn.HeaderText = "Item Size";
                newColumn.Name = "ItemSizeDetails";
                newColumn.DataPropertyName = "ItemSizeDetailsData";

                // Add the column to the datagrid
                dataGridViewBillDetails.Columns.Add(newColumn);




                foreach (DataGridViewRow row in dataGridViewBillDetails.Rows)
                {
                    if (((InvoiceItem)row.DataBoundItem).ItemSize != null)
                    {
                        string size = ((InvoiceItem)row.DataBoundItem).ItemSize.Size.ToString();
                        row.Cells[11].Value = size;
                    }
                }


                dataGridViewBillDetails.Refresh();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
            


        }

        private void btbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSFWSoftSolutions
{
    public partial class mainSalesMenForm : Form
    {
        MSFWEntities2 msfWContext = new MSFWEntities2();
        public mainSalesMenForm()
        {
            InitializeComponent();
        }

        private void mainSalesMenForm_Load(object sender, EventArgs e)
        {
            if (msfWContext.InvoiceDetails.Where(x => x.InvoiceDate.Day == DateTime.Now.Day && x.InvoiceDate.Month == DateTime.Now.Month && x.InvoiceDate.Year == DateTime.Now.Year).Count() > 0)
            {
                lblTSales.Text = "Today Sales: " + msfWContext.InvoiceDetails.Where(x => x.InvoiceDate.Day == DateTime.Now.Day && x.InvoiceDate.Month == DateTime.Now.Month && x.InvoiceDate.Year == DateTime.Now.Year).Sum(x => x.TotalPayable).ToString();
            }
            else
            {
                lblTSales.Text = "Today Sales: -";
            }

            List<InvoiceItem> listInvItemsIncentive = (from incV in msfWContext.InvoiceItems
                                                       where incV.Item.IsSaleDiscount == false
                                                       select incV).ToList();
            List<Incentive> listIncentive = new List<Incentive>();
            foreach(InvoiceItem inv in listInvItemsIncentive)
            {
                Incentive i = new Incentive();
                i.BillNumber = inv.InvoiceDetail.InvoiceNumber;
                i.IncentiveAmount = Convert.ToInt32((((inv.TotalAmount - inv.Item.LastSellingPrice) / 2.0 ) /112.0) * 100.0) ;
                listIncentive.Add(i);
            }

            dataGridViewIncentiveDetails.DataSource = listIncentive;

            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            //List<barCodeItem> btItems = new List<barCodeItem>();
            dataGridViewGeneratedBills.DataSource = null;


            dataGridViewGeneratedBills.DataSource = msfWContext.InvoiceDetails.OrderByDescending(x => x.InvoiceDate).ToList(); ;
            dataGridViewGeneratedBills.Columns[7].Visible = false;
            dataGridViewGeneratedBills.Columns[0].Visible = false;
            dataGridViewGeneratedBills.Columns[8].Visible = false;
            dataGridViewGeneratedBills.Columns[9].Visible = false;
            dataGridViewGeneratedBills.Columns[10].Visible = false;


            DataGridViewColumn numColumn = dataGridViewGeneratedBills.Columns[2];
            
            numColumn.DisplayIndex = 1;
            



            dataGridViewGeneratedBills.Refresh();
        }

        private void btnNewBill_Click(object sender, EventArgs e)
        {
            frmGenerateBill frm = new frmGenerateBill();
            frm.ShowDialog();
            LoadDataGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Get the selected row
            var selectedRow = dataGridViewGeneratedBills.SelectedRows[0];

            // Get the ID from the selected row
            long id = Convert.ToInt64(selectedRow.Cells["InvoiceID"].Value);

            // Get the entity from the database using the ID
            InvoiceDetail invoiceSelected = msfWContext.InvoiceDetails.SingleOrDefault(x => x.InvoiceID == id);

            var pdfByteArray = new MemoryStream(invoiceSelected.InvoicePDF);

            string folderPath = ConfigurationManager.AppSettings["TempBillFilePath"] + @"\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath); // Create the folder if it doesn't exist
            }

            string fileName = folderPath + invoiceSelected.InvoiceNumber.Replace("/","_") +  ".pdf";
            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {
                pdfByteArray.CopyTo(fileStream);
            }


           

            Process p = new Process();
            p.StartInfo = new ProcessStartInfo()
            {
                CreateNoWindow = true,
                Verb = "print",
                FileName = fileName
            };
            p.Start();

            //File.Delete(fileName); // Clean up temporary file



        }
    }
}

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
            dateTimePickerFromDate.Value = DateTime.Now;
            dateTimePickerToDate.Value = DateTime.Now;

            showSales();

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
            dataGridViewIncentiveDetails.ReadOnly = true;
            dataGridViewIncentiveDetails.DataSource = listIncentive;

            LoadDataGrid();
        }


        private void showSales()
        {
            DateTime frmDate = dateTimePickerFromDate.Value;
            DateTime toDate = dateTimePickerToDate.Value;

            int recCount = msfWContext.InvoiceDetails.Where(x => x.InvoiceDate.Day >= frmDate.Day && x.InvoiceDate.Day <= toDate.Day && x.InvoiceDate.Month >= frmDate.Month && x.InvoiceDate.Month <= toDate.Month && x.InvoiceDate.Year >= frmDate.Year && x.InvoiceDate.Year <= toDate.Year).Count();

            int recDigCount = msfWContext.InvoiceDetails.Where(x => x.InvoiceDate.Day >= frmDate.Day && x.InvoiceDate.Day <= toDate.Day && x.InvoiceDate.Month >= frmDate.Month && x.InvoiceDate.Month <= toDate.Month && x.InvoiceDate.Year >= frmDate.Year && x.InvoiceDate.Year <= toDate.Year && x.Digital==true).Count();

            int recCashCount = msfWContext.InvoiceDetails.Where(x => x.InvoiceDate.Day >= frmDate.Day && x.InvoiceDate.Day <= toDate.Day && x.InvoiceDate.Month >= frmDate.Month && x.InvoiceDate.Month <= toDate.Month && x.InvoiceDate.Year >= frmDate.Year && x.InvoiceDate.Year <= toDate.Year && x.Cash == true).Count();


            if (recCount > 0)
            {
                lblTotalValue.Text =  msfWContext.InvoiceDetails.Where(x => x.InvoiceDate.Day >= frmDate.Day && x.InvoiceDate.Day <= toDate.Day && x.InvoiceDate.Month >= frmDate.Month && x.InvoiceDate.Month <= toDate.Month && x.InvoiceDate.Year >= frmDate.Year && x.InvoiceDate.Year <= toDate.Year).Sum(x => x.TotalPayable).ToString();
            }
            else
            {
                lblTotalValue.Text = "-";
            }


            if (recDigCount > 0)
            {
                lblDigitalValue.Text =  msfWContext.InvoiceDetails.Where(x => x.InvoiceDate.Day >= frmDate.Day && x.InvoiceDate.Day <= toDate.Day && x.InvoiceDate.Month >= frmDate.Month && x.InvoiceDate.Month <= toDate.Month && x.InvoiceDate.Year >= frmDate.Year && x.InvoiceDate.Year <= toDate.Year && x.Digital==true).Sum(x => x.TotalPayable).ToString();
            }
            else
            {
                lblDigitalValue.Text = "-";
            }

            if (recCashCount > 0)
            {
                lblCashValue.Text =  msfWContext.InvoiceDetails.Where(x => x.InvoiceDate.Day >= frmDate.Day && x.InvoiceDate.Day <= toDate.Day && x.InvoiceDate.Month >= frmDate.Month && x.InvoiceDate.Month <= toDate.Month && x.InvoiceDate.Year >= frmDate.Year && x.InvoiceDate.Year <= toDate.Year && x.Cash == true).Sum(x => x.TotalPayable).ToString();
            }
            else
            {
                lblCashValue.Text = "-";
            }


        }
        private void LoadDataGrid()
        {

            dataGridViewGeneratedBills.ReadOnly = true;
            //List<barCodeItem> btItems = new List<barCodeItem>();
            dataGridViewGeneratedBills.DataSource = null;


            dataGridViewGeneratedBills.DataSource = msfWContext.InvoiceDetails.OrderByDescending(x => x.InvoiceDate).ToList(); ;
            dataGridViewGeneratedBills.Columns[7].Visible = false;
            dataGridViewGeneratedBills.Columns[0].Visible = false;
            dataGridViewGeneratedBills.Columns[8].Visible = true;
            dataGridViewGeneratedBills.Columns[9].Visible = true;
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
            showSales();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewGeneratedBills.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewGeneratedBills.SelectedRows[0].Index;
                // Do something with the selected row index
            }
            else
            {
                MessageBox.Show("No Row Selected");
                return;
            }

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

        private void dateTimePickerFromDate_ValueChanged(object sender, EventArgs e)
        {
            showSales();
        }

        private void dateTimePickerToDate_ValueChanged(object sender, EventArgs e)
        {
            showSales();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewGeneratedBills.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewGeneratedBills.SelectedRows[0].Index;
                // Do something with the selected row index
            }
            else
            {
                MessageBox.Show("No Row Selected");
                return;
            }

            // Get the selected row
            var selectedRow = dataGridViewGeneratedBills.SelectedRows[0];

            // Get the ID from the selected row
            long id = Convert.ToInt64(selectedRow.Cells["InvoiceID"].Value);

            FormViewBillDetails frm = new FormViewBillDetails();
            frm.InvoiceID = id;
            frm.ShowDialog();


        }
    }
}

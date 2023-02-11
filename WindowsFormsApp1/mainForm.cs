using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;

namespace WindowsFormsApp1
{
    public partial class mainForm : Form
    {
        MSFWEntities msfWContext = new MSFWEntities();
        public mainForm()
        {
            InitializeComponent();
        }

        private void cmdImport_Click(object sender, EventArgs e)
        {

            
            var filePath = @"F:\MVP\personal\myShop\InventoryFile.xlsx";

            try
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var workbook = package.Workbook;
                    var worksheet = workbook.Worksheets[0];
                    var totalRows = worksheet.Dimension.End.Row;
                    var totalColumns = worksheet.Dimension.End.Column;

                    DataTable dataTable = new DataTable();

                    for (int col = 1; col <= totalColumns; col++)
                    {
                        dataTable.Columns.Add(worksheet.Cells[1, col].Value.ToString());
                    }

                    for (int row = 2; row <= totalRows; row++)
                    {
                        DataRow dataRow = dataTable.NewRow();
                        for (int col = 1; col <= totalColumns; col++)
                        {
                            dataRow[col - 1] = worksheet.Cells[row, col].Value.ToString();
                        }
                        dataTable.Rows.Add(dataRow);
                    }




                    foreach (DataRow dataRow in dataTable.Rows)
                    {

                        string batchNumber = dataRow[12].ToString();

                        Item itBatch = (from iteM in msfWContext.Items
                                        where iteM.BatchNumber.Equals(batchNumber)
                                        select iteM).FirstOrDefault();
                        if (itBatch != null)
                        {
                            MessageBox.Show("This Batch is already completed");
                            break;
                        }

                        Item itm = new Item();

                        
                        itm.ICode = dataRow[0].ToString();
                        itm.HSN = dataRow[1].ToString();
                        itm.Description = dataRow[2].ToString();

                        string itemType = dataRow[3].ToString();
                        ItemType it = (from c in msfWContext.ItemTypes
                                       where c.Description.Equals(itemType)
                                       select c).FirstOrDefault();

                        itm.TypeID = it.TypeID;

                        string colourType = dataRow[4].ToString();
                        ColourType ct = (from c in msfWContext.ColourTypes
                                         where c.Description.Equals(colourType)
                                         select c).FirstOrDefault();

                        itm.ColorID = ct.ColourID;

                        string brandType = dataRow[5].ToString();
                        BrandType bt = (from b in msfWContext.BrandTypes
                                        where b.Description.Equals(brandType)
                                        select b).FirstOrDefault();
                        itm.BrandID = bt.BrandID;
                        itm.AvailableUnits = Convert.ToInt32(dataRow[6].ToString());
                        itm.CostPrice = Convert.ToInt32(dataRow[7].ToString());
                        itm.SellingPrice = Convert.ToInt32(dataRow[8].ToString());
                        itm.MaxDiscount = Convert.ToInt32(dataRow[9].ToString());
                        itm.DateOfPurchase = Convert.ToDateTime(dataRow[10].ToString());
                        itm.Rack = dataRow[11].ToString();
                        itm.BatchNumber = dataRow[12].ToString();
                        msfWContext.Items.Add(itm);

                        //msfWContext.Items.Add(new Item( { ICode= dataRow[0].ToString(),HSN= dataRow[1].ToString(),Description= dataRow[2].ToString()
                        //    ,ColorID=(from c in msfWContext.ColourTypes.Where(c=>c.Description==dataRow[3].ToString()))

                        foreach (var item in dataRow.ItemArray)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                    }

                    msfWContext.SaveChanges();
                    MessageBox.Show("Imported Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cmdBarCodes_Click(object sender, EventArgs e)
        {
            //var qrWriter = new BarcodeWriter
            //{
            //    Format = BarcodeFormat.QR_CODE,
            //    Options = new QrCodeEncodingOptions
            //    {
            //        Height = 100,
            //        Width = 100
            //    }
            //};

            // Create a new PDF document
            Document doc = new Document(PageSize.A4,0,50,50,50);
            PdfWriter.GetInstance(doc, new FileStream("barcode.pdf", FileMode.Create));
            doc.Open();

            int totalItems = msfWContext.Items.Count();


         
                int k = 0;
                int totalColumnLength = 4;
                PdfPTable table = new PdfPTable(totalColumnLength);
                foreach (Item itm in msfWContext.Items)
                {

                    if(k== totalColumnLength)
                    {
                        doc.Add(table);
                        doc.SpacingAfter = 10;
                        table.Rows.Clear();
                        k = 0;
                    }

                        string data = itm.ICode;





                        // Create a barcode writer instance
                        BarcodeWriter barcodeWriter = new BarcodeWriter();
                        barcodeWriter.Format = BarcodeFormat.CODE_128;
                        barcodeWriter.Options = new QrCodeEncodingOptions
                        {
                            Height = 40,
                            Width = 100
                        };

                        // Generate the barcode image
                        Bitmap barcodeImage = barcodeWriter.Write(data);

                        iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance(barcodeImage, System.Drawing.Imaging.ImageFormat.Png);
                        // Convert the image to a PDF image
                        //iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(barcodeImage, System.Drawing.Imaging.ImageFormat.Png);

                        table.AddCell(image1);

                        
                        


                // Add the image to the PDF document

                k = k + 1;
                }
            
            doc.Add(table);
            // Close the document
            doc.Close();


            //var bitmap = new Bitmap(result);
            //bitmap.Save("qrcode.png", ImageFormat.Png);
        }
    }
}

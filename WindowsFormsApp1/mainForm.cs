using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;

namespace MSFWSoftSolutions
{
    public partial class mainForm : Form
    {
        MSFWEntities2 msfWContext = new MSFWEntities2();
        BindingList<barCodeItem> btItems = new BindingList<barCodeItem>();
        public mainForm()
        {
            InitializeComponent();
        }

        private void cmdImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Select a excel file";
            openFileDialog1.InitialDirectory = "E:\\";
            openFileDialog1.Multiselect = false;
            string filePathD = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePathD = openFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("Please select the file");
                return;
            }


            var filePath = filePathD;

            //var filePath = @"E:\Software-msFWSolutions\InventoryFile.xlsx";

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
                            if (worksheet.Cells[row, col].Value.ToString()!=null)
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
                          //  MessageBox.Show("This Batch is already completed");
                            continue;
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
                        itm.LastSellingPrice = Convert.ToInt32(dataRow[9].ToString());
                        itm.DateOfPurchase = Convert.ToDateTime(dataRow[10].ToString());
                        itm.Rack = dataRow[11].ToString();
                        itm.BatchNumber = dataRow[12].ToString();
                        itm.IsSaleDiscount = Convert.ToBoolean(dataRow[13].ToString());
                        itm.SaleDiscountP = Convert.ToInt32(dataRow[14].ToString());
                        itm.DateOfEntryNew = DateTime.Now;
                        msfWContext.Items.Add(itm);
                        
                        //msfWContext.Items.Add(new Item( { ICode= dataRow[0].ToString(),HSN= dataRow[1].ToString(),Description= dataRow[2].ToString()
                        //    ,ColorID=(from c in msfWContext.ColourTypes.Where(c=>c.Description==dataRow[3].ToString()))

                        //foreach (var item in dataRow.ItemArray)
                        //{
                        //    Console.Write(item + " ");
                        //}
                        //Console.WriteLine();
                    }

                    
                    msfWContext.SaveChanges();
                    MessageBox.Show("Imported Successfully");
                }
            }
            catch (DbEntityValidationException deX)
            {
                var newException = new FormattedDbEntityValidationException(deX);
                throw newException;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            LoadDataGrid();
        }

        //private void cmdBarCodes_Click(object sender, EventArgs e)
        //{

        //    string rupeeSymbol = "\u20B9";
        //    //var qrWriter = new BarcodeWriter
        //    //{
        //    //    Format = BarcodeFormat.QR_CODE,
        //    //    Options = new QrCodeEncodingOptions
        //    //    {
        //    //        Height = 100,
        //    //        Width = 100
        //    //    }
        //    //};

        //    // Create a new PDF document
        //    Document doc = new Document(PageSize.A4,0,50,50,50);
        //    PdfWriter.GetInstance(doc, new FileStream("barcode.pdf", FileMode.Create));
        //    doc.Open();


        //    int totalItems = msfWContext.Items.Count();


         
        //        int k = 0;
        //        int totalColumnLength = 4;
        //        PdfPTable table = new PdfPTable(totalColumnLength);
        //        table.WidthPercentage = 80;
        //        foreach (Item itm in msfWContext.Items)
        //        {

        //            if(k== totalColumnLength)
        //            {
        //                table.DefaultCell.Padding = 5;  // Set padding for all cells
        //                table.SpacingBefore = 10;       // Set spacing before the table
        //                table.SpacingAfter = 10;        // Set spacing after the table
        //                doc.Add(table);
        //                //doc.SpacingAfter = 10;
        //                table.Rows.Clear();
        //                k = 0;
        //            }

        //                string data = itm.ICode;


                      

        //                // Create a barcode writer instance
        //                BarcodeWriter barcodeWriter = new BarcodeWriter();
        //                barcodeWriter.Format = BarcodeFormat.CODE_128;
                        
        //                barcodeWriter.Options = new QrCodeEncodingOptions
        //                {
        //                    Height = 50,
        //                    Width = 200,
        //                    Margin=0
        //                };

        //        //        // Generate the barcode image
        //        //        Bitmap barcodeImage = barcodeWriter.Write(data);


        //        //        // Convert the image to a PDF image
        //        //        //iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(barcodeImage, System.Drawing.Imaging.ImageFormat.Png);

        //        //        // Add some text to the image
        //        //        using (var graphics = Graphics.FromImage(barcodeImage))
        //        //        {
        //        //            using (var font = new System.Drawing.Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular))
        //        //            {
        //        //                var text = "This is some text";
        //        //                var brush = new SolidBrush(Color.Black);
        //        //                graphics.DrawString(text, font, brush, new PointF(10, 30));
        //        //            }
        //        //        }

        //        //iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance(barcodeImage, System.Drawing.Imaging.ImageFormat.Png);

        //        // Create a Bitmap to hold the barcode and the text
        //        var bitmap = new Bitmap(200, 70, PixelFormat.Format32bppArgb);

        //        // Get a Graphics object for the Bitmap
        //        using (var graphics = Graphics.FromImage(bitmap))
        //        {
        //            // Set the font and size for the text
        //            var font = new System.Drawing.Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular);

        //            // Set the color for the text
        //            var brush = new SolidBrush(Color.Black);

        //            // Draw the text at the top of the Bitmap
        //            var text = rupeeSymbol +" " + itm.SellingPrice.ToString() + "      R: " +itm.Rack;
        //            var textSize = graphics.MeasureString(text, font);
        //            var textX = (bitmap.Width - textSize.Width) / 2;
        //            graphics.DrawString(text, font, brush, new PointF(textX, 0));

        //            // Generate the barcode and draw it at the bottom of the Bitmap
        //            var barcodeBitmap = barcodeWriter.Write(data);
        //            graphics.DrawImage(barcodeBitmap, new Point(0, 20));
        //            iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance(bitmap, System.Drawing.Imaging.ImageFormat.Png);

                    

        //            table.AddCell(image1);
        //        }
                
                        





        //        // Add the image to the PDF document

        //        k = k + 1;
        //        }
            
        //    doc.Add(table);
        //    // Close the document
        //    doc.Close();


        //    //var bitmap = new Bitmap(result);
        //    //bitmap.Save("qrcode.png", ImageFormat.Png);
        //}




        private void cmdBarCodes_Click(object sender, EventArgs e)
        {
            int totalItemCountSelected = 0;
            totalItemCountSelected = btItems.Where(x => x.IsChecked == true).Sum(x => x.ItemCount);
            if(totalItemCountSelected>44)
            {
                MessageBox.Show("You have Selected " + totalItemCountSelected.ToString() + "\n" + " Please select items lesser than or equal to 44");
                return;

            }

            if (btItems.Count==0 || btItems.Where(x=>x.IsChecked==true).Count()==0)
            {
                MessageBox.Show("No records to create barcode");
                return;
            }


            string rupeeSymbol = "\u20B9";
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
            Document doc = new Document(PageSize.A4, 0, 50, 50, 50);
            PdfWriter.GetInstance(doc, new FileStream("barcode.pdf", FileMode.Create));
            doc.Open();


            //int totalItems = msfWContext.Items.Count();

            int totalItems = btItems.Count;



            int k = 0;
         
            int barCodeMaxCount = 0;
            int rowCount = 1;
            int columnCount = 1;
            //int xSize=Convert.ToInt32(textBoxXAxis.Text), ySize= Convert.ToInt32(textBoxYAxis.Text);
            int xSize = 20, ySize = 780;
            int barCodeWidth = 100, barCodeHeight = 30;

            foreach (barCodeItem itm in btItems.Where(x=>x.IsChecked==true).Take(44))
            {

                barCodeMaxCount = itm.ItemCount;

                for (int l = 1; l <= barCodeMaxCount; l++)
                {
                    string data = itm.ICode;


                // Create a barcode writer instance
                BarcodeWriter barcodeWriter = new BarcodeWriter();
                barcodeWriter.Format = BarcodeFormat.CODE_128;

                barcodeWriter.Options = new QrCodeEncodingOptions
                {
                    Height = 40,
                    Width = 200,
                    Margin = 0,
                    PureBarcode = true
                };

                //        // Generate the barcode image
                //        Bitmap barcodeImage = barcodeWriter.Write(data);


                //        // Convert the image to a PDF image
                //        //iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(barcodeImage, System.Drawing.Imaging.ImageFormat.Png);

                //        // Add some text to the image
                //        using (var graphics = Graphics.FromImage(barcodeImage))
                //        {
                //            using (var font = new System.Drawing.Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular))
                //            {
                //                var text = "This is some text";
                //                var brush = new SolidBrush(Color.Black);
                //                graphics.DrawString(text, font, brush, new PointF(10, 30));
                //            }
                //        }

                //iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance(barcodeImage, System.Drawing.Imaging.ImageFormat.Png);

                // Create a Bitmap to hold the barcode and the text
                var bitmap = new Bitmap(210, 120, PixelFormat.Format32bppArgb);

                // Get a Graphics object for the Bitmap
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    // Set the font and size for the text
                    var font = new System.Drawing.Font(FontFamily.GenericSansSerif, 16, FontStyle.Regular);

                    // Set the color for the text
                    var brush = new SolidBrush(Color.Black);

                    // Draw the text at the top of the Bitmap
                    int priceAfterDiscount = 0;
                    if (itm.IsSaleDiscount)
                    {
                        priceAfterDiscount = (itm.SellingPrice) - (itm.SellingPrice * itm.SaleDiscountP / 100);
                    }

                    string text = string.Empty;
                    if (itm.IsSaleDiscount)
                        //var text = "MRP: " + rupeeSymbol + " " + itm.SellingPrice.ToString() + " DP: " + (itm.SellingPrice - ((itm.SellingPrice-itm.SellingPrice%itm.SaleDiscountP)).ToString() +      @"R: " + itm.Rack;
                        text = rupeeSymbol + itm.SellingPrice.ToString() + " DP:" + rupeeSymbol + " " + priceAfterDiscount.ToString() + @" [R:" + itm.Rack.ToString() + " ]";
                    else
                        text = rupeeSymbol + itm.SellingPrice.ToString() + @"                 [R:" + itm.Rack.ToString() + " ]";


                    var textSize = graphics.MeasureString(text, font);
                    var textX = (bitmap.Width - textSize.Width) / 2;
                    graphics.DrawString(text, font, brush, new PointF(textX, 0));

                    

                    // Generate the barcode and draw it at the bottom of the Bitmap
                    var barcodeBitmap = barcodeWriter.Write(data);

                        // Calculate the position of the barcode
                        var barcodeX = (bitmap.Width - barcodeBitmap.Width) / 2;
                        var barcodeY = textSize.Height + 10; // Add some space between text and barcode


                        // Draw the barcode below the text
                        graphics.DrawImage(barcodeBitmap, new Point(barcodeX, Convert.ToInt32(barcodeY)));

                        //graphics.DrawImage(barcodeBitmap, new Point(0, 20));


                        // Draw text after the barcode with space
                        var space = "       "; // add space here
                        var textA = data + space;
                        var fontA = new System.Drawing.Font(FontFamily.GenericSansSerif, 16, FontStyle.Regular);
                        var brushA = new SolidBrush(Color.Black);
                        var textSizeA = graphics.MeasureString(textA, font);
                        var textXA = (bitmap.Width - textSizeA.Width) / 2;
                        var textYA = barcodeY + barcodeBitmap.Height + 5; // add some more space between barcode and text
                        graphics.DrawString(textA, font, brush, new PointF(textXA, textYA));

                    //    // Draw text after the barcode
                    //    var textA = data + "       ";
                    //var fontA = new System.Drawing.Font(FontFamily.GenericSansSerif, 16, FontStyle.Regular);
                    //var brushA = new SolidBrush(Color.Black);
                    //var textSizeA = graphics.MeasureString(textA, font);
                    //var textXA = (bitmap.Width - textSizeA.Width) / 2;
                    //var textYA = barcodeBitmap.Height + 20;
                    //graphics.DrawString(textA, fontA, brushA, new PointF(textXA, textYA));


                    iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance(bitmap, System.Drawing.Imaging.ImageFormat.Png);

                    image1.ScaleAbsolute(barCodeWidth, barCodeHeight);
                    k = k + 1;


                    if (k > 1 && k <= 4)
                    {
                        columnCount = columnCount + 1;

                        if (columnCount == 3)
                        {
                            xSize = xSize + (barCodeWidth + 60);
                        }
                        else
                        {
                            xSize = xSize + (barCodeWidth + 40);
                        }
                        image1.SetAbsolutePosition(xSize, ySize);
                    }
                    else if (k == 5)
                    {
                        rowCount = rowCount + 1;

                        columnCount = 1;
                        xSize = 20;

                        if (rowCount == 3)
                        {
                            ySize = ySize - (barCodeHeight + 50);
                        }
                        else if (rowCount == 4)
                        {
                            ySize = ySize - (barCodeHeight + 40);
                        }
                        else if (rowCount == 5)
                        {
                            ySize = ySize - (barCodeHeight + 30);
                        }
                        else if (rowCount == 6)
                        {
                                ySize = ySize - (barCodeHeight + 40);
                        }
                        else if (rowCount == 7)
                        {
                            ySize = ySize - (barCodeHeight + 50);
                        }
                        else if (rowCount == 8)
                        {
                            ySize = ySize - (barCodeHeight + 30);
                        }
                        else if (rowCount == 10)
                        {
                            ySize = ySize - (barCodeHeight + 50);
                        }
                        else if (rowCount == 11)
                        {
                            ySize = ySize - (barCodeHeight + 40);
                        }
                        else if (rowCount == 12)
                        {
                            ySize = ySize - (barCodeHeight + 32);
                        }
                        else
                        {
                            ySize = ySize - (barCodeHeight + 32);
                        }
                        image1.SetAbsolutePosition(xSize, ySize);
                        k = 1;
                    }
                    else
                    {
                        image1.SetAbsolutePosition(xSize, ySize);
                    }




                    doc.Add(image1);

                }





            }


                // Add the image to the PDF document

                
            }

            //doc.Add(table);
            // Close the document
            doc.Close();
            MessageBox.Show("Created Successfully");

            //var bitmap = new Bitmap(result);
            //bitmap.Save("qrcode.png", ImageFormat.Png);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Select a excel file";
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Multiselect = false;
            string filePathD = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePathD = openFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("Please select the file");
                return;
            }


            var filePath = filePathD;

            try
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var workbook = package.Workbook;
                    var worksheet = workbook.Worksheets[1];
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
                            if (worksheet.Cells[row, col].Value.ToString() != null)
                                dataRow[col - 1] = worksheet.Cells[row, col].Value.ToString();
                        }
                        dataTable.Rows.Add(dataRow);
                    }




                    foreach (DataRow dataRow in dataTable.Rows)
                    {

                        string batchNumber = dataRow[3].ToString();

                        ItemSize itBatch = (from iteM in msfWContext.ItemSizes
                                        where iteM.BatchNumber.Equals(batchNumber)
                                        select iteM).FirstOrDefault();
                        if (itBatch != null)
                        {
                            //  MessageBox.Show("This Batch is already completed");
                            continue;
                        }

                        ItemSize itm = new ItemSize();


                        itm.ICode = dataRow[0].ToString();
                        itm.Size = dataRow[1].ToString();
                        itm.Count = Convert.ToInt32(dataRow[2].ToString());
                       

                      

                      
                        itm.BatchNumber = dataRow[3].ToString();
                      
                        msfWContext.ItemSizes.Add(itm);

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

        private void mainForm_Load(object sender, EventArgs e)
        {
            LoadDataGrid();   
        }
        private void LoadDataGrid()
        {
            //List<barCodeItem> btItems = new List<barCodeItem>();
            dataGridViewItems.DataSource = null;
            foreach (Item itm in msfWContext.Items.OrderByDescending(x=>x.DateOfEntryNew))
            {
                btItems.Add(new barCodeItem { ICode = itm.ICode, Description = itm.Description, DateOfEntry = itm.DateOfEntryNew, ItemCount = itm.AvailableUnits, IsSaleDiscount = itm.IsSaleDiscount, SaleDiscountP = itm.SaleDiscountP, Rack = itm.Rack, SellingPrice = itm.SellingPrice, IsChecked = false });
            }

            dataGridViewItems.DataSource = btItems;
            dataGridViewItems.Refresh();
        }


        private void LoadCheckedDataGrid()
        {
            //List<barCodeItem> btItems = new List<barCodeItem>();
            dataGridViewItems.DataSource = null;
            

            dataGridViewItems.DataSource = btItems;
            dataGridViewItems.Refresh();
        }

        private void FilterData(string search)
        {
            foreach (DataGridViewRow row in dataGridViewItems.Rows)
            {
                if (!row.IsNewRow && row.Index != dataGridViewItems.CurrentRow.Index)
                {
                    bool visible = false;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && cell.Value.ToString().Contains(search))
                        {
                            visible = true;
                            break;
                        }
                    }
                    row.Visible = visible;
                }
            }
        }



        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            
                FilterData(textSearch.Text);
            
        }


        private void dataGridViewItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is a checkbox cell and the checkbox is checked
            //if (dataGridViewItems.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            //{
            //    DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dataGridViewItems.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //    if (checkbox.Value != null && (bool)checkbox.Value == true)
            //    {
            //        // Execute your code here
            //        // For example, you can get the value of other cells in the same row:
            //        string name = dataGridViewItems .Rows[e.RowIndex].Cells["NameColumn"].Value.ToString();
            //        int age = Convert.ToInt32(dataGridViewItems.Rows[e.RowIndex].Cells["AgeColumn"].Value);
            //        // ...
            //        int totalItemCountSelected = 0;
            //        totalItemCountSelected = btItems.Where(x => x.IsChecked == true).Select(x => x.ItemCount).Sum();


            //    }
            //}



        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            foreach (barCodeItem bt in btItems)
            {

                bt.IsChecked = true;
            }

            LoadCheckedDataGrid();
            labelSelected.Text = btItems.Where(x => x.IsChecked == true).Sum(x => x.ItemCount).ToString();
        }

        private void dataGridViewItems_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            //labelSelected.Text = btItems.Where(x => x.IsChecked == true).Sum(x => x.ItemCount).ToString();
        }

        private void dataGridViewItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void dataGridViewItems_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
         
        }

        private void dataGridViewItems_MouseHover(object sender, EventArgs e)
        {
            labelSelected.Text = btItems.Where(x => x.IsChecked == true).Sum(x => x.ItemCount).ToString();
        }

        private void dataGridViewItems_MouseLeave(object sender, EventArgs e)
        {
            labelSelected.Text = btItems.Where(x => x.IsChecked == true).Sum(x => x.ItemCount).ToString();
        }

        private void dataGridViewItems_MouseMove(object sender, MouseEventArgs e)
        {
            labelSelected.Text = btItems.Where(x => x.IsChecked == true).Sum(x => x.ItemCount).ToString();
        }
    }

    public class FormattedDbEntityValidationException : Exception
    {
        public FormattedDbEntityValidationException(DbEntityValidationException innerException) :
            base(null, innerException)
        {
        }

        public override string Message
        {
            get
            {
                var innerException = InnerException as DbEntityValidationException;
                if (innerException != null)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine();
                    sb.AppendLine();
                    foreach (var eve in innerException.EntityValidationErrors)
                    {
                        sb.AppendLine(string.Format("- Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().FullName, eve.Entry.State));
                        foreach (var ve in eve.ValidationErrors)
                        {
                            sb.AppendLine(string.Format("-- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                ve.PropertyName,
                                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                ve.ErrorMessage));
                        }
                    }
                    sb.AppendLine();

                    return sb.ToString();
                }

                return base.Message;
            }
        }


    }
}

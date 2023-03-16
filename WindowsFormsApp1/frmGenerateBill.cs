using iTextSharp.text;
using iTextSharp.text.pdf;
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
    public partial class frmGenerateBill : Form
    {
        // Create an array of RadioButtons
        RadioButton[] radioButtons = new RadioButton[1];
        MSFWEntities2 msfWContext = new MSFWEntities2();
        List<DisplayItemSizes> dispItemSizes = new List<DisplayItemSizes>();
        int LastSellingPrice;
        bool isWithoutItemCodeBill;
        bool isDigitalSelected = false, isCashSelected = false;
        BindingList<DisplayInvoiceItem> displayBillItems = new BindingList<DisplayInvoiceItem>();
        public frmGenerateBill()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Create a rectangle with a 10-pixel margin
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(10, 10, panel1.ClientSize.Width - 20, panel1.ClientSize.Height - 20);

            // Draw the rectangle with a black pen
            using (Pen pen1 = new Pen(Color.Black))
            {
                e.Graphics.DrawRectangle(pen1, rect);
            }


            // Get the graphics object for the panel
            Graphics g = e.Graphics;

            // Set the color and thickness of the line
            Pen pen = new Pen(Color.Red, 2);

            // Calculate the start and end points of the line
            int x = panel1.Width / 2;
            int y1 = 0;
            int y2 = panel1.Height;

            // Draw the line
            g.DrawLine(pen, x, y1 + 10, x, y2 - 90);


            // Draw a horizontal line across the middle of the panel
            int y = (panel1.Height / 2) + 50;
            g.DrawLine(Pens.Green, 0 + 10, y, panel1.Width - 10, y);

        }

        private void btnGenerateBill_Click(object sender, EventArgs e)
        {
            if (displayBillItems.Count() == 0 || dataGridViewBillItem.Rows.Count == 0)
            {
                MessageBox.Show("No items to generate the bill");
                return;
            }

            if (isDigitalSelected==false && isCashSelected==false)
            {
                MessageBox.Show("Please select payment details");
                return;
            }

            CompanyDetail cd = (from comp in msfWContext.CompanyDetails
                                where comp.CompanyID.Equals(1)
                                select comp).FirstOrDefault();

            List<InvoiceItem> lI = new List<InvoiceItem>();

            foreach (DisplayInvoiceItem invDisplayItem in displayBillItems)
            {
                InvoiceItem invItem = new InvoiceItem();
                if (invDisplayItem.isWithoutItemCodeBill)
                {
                    invItem.InvID = invDisplayItem.InvID;
                    invItem.Rate = invDisplayItem.Rate;
                    invItem.Quantity = invDisplayItem.Quantity;
                    invItem.ItemDescription = invDisplayItem.ItemDescription;
                    invItem.TotalAmount = invItem.Rate * invItem.Quantity;
                }
                else
                {
                    invItem.InvID = invDisplayItem.InvID;
                    invItem.Rate = invDisplayItem.Rate;
                    invItem.Quantity = invDisplayItem.Quantity;
                    invItem.ItemDescription = invDisplayItem.ItemDescription;
                    invItem.TotalAmount = invItem.Rate * invItem.Quantity;
                    invItem.SizeID = invDisplayItem.SizeID;

                    Item itemQModify = (from iteM in msfWContext.Items
                                  where iteM.InvID==invItem.InvID
                                  select iteM).FirstOrDefault();

                    ItemSize iSize = (from isz in msfWContext.ItemSizes
                                      where isz.SizeID == invItem.SizeID
                                              select isz).FirstOrDefault();
                    itemQModify.AvailableUnits = itemQModify.AvailableUnits - invItem.Quantity;
                    iSize.Count = iSize.Count - invItem.Quantity;


                }
                lI.Add(invItem);
            }

          


           
            //lI.Add(invItem1);

            InvoiceDetail invDetail = new InvoiceDetail();

            invDetail.InvoiceDate = DateTime.Now;


            string strFinYear = FinancialYear.Current.ToString();

            DateTime fromFinDate = new DateTime(Convert.ToInt32(strFinYear.Substring(0, 4)), 4, 1);
            DateTime ToFinDate = new DateTime(Convert.ToInt32(strFinYear.Substring(5, 4)), 3, 31);

  

           


            InvoiceDetail invCheck = (from inv in msfWContext.InvoiceDetails
                                      where inv.InvoiceDate >= fromFinDate && inv.InvoiceDate <= ToFinDate
                                      select inv).OrderByDescending(x=>x.InvoiceDate).FirstOrDefault();

            if (invCheck == null)
            {
                invDetail.InvoiceNumber = "MS/" + strFinYear + "/1";
            }
            else
            {
                string[] array = invCheck.InvoiceNumber.Split('/');
                int newSerialNumber = Convert.ToInt32(array[2]) + 1;
                invDetail.InvoiceNumber = "MS/" + strFinYear + "/" + newSerialNumber ;
            }

            int totalInvoiceAmount = lI.Sum(x => x.TotalAmount);
            Double taxableAmount = (totalInvoiceAmount / (100 + Convert.ToDouble(cd.CGST) + Convert.ToDouble(cd.SGST))) * 100.0;


            invDetail.TaxableAmount = Convert.ToInt32(taxableAmount);

            Double cGST = invDetail.TaxableAmount * (Convert.ToDouble(cd.CGST) / 100);
            Double sGST = invDetail.TaxableAmount * (Convert.ToDouble(cd.SGST) / 100);

            invDetail.CGST = Convert.ToInt32(cGST);
            invDetail.SGST = Convert.ToInt32(sGST);

            Double totalPayable = taxableAmount + invDetail.TaxableAmount * (Convert.ToDouble(cd.CGST) / 100) + invDetail.TaxableAmount * (Convert.ToDouble(cd.SGST) / 100);

            //invDetail.TotalPayable = invDetail.TaxableAmount + invDetail.CGST + invDetail.SGST;
            invDetail.TotalPayable = Convert.ToInt32(totalPayable);
            invDetail.InvoiceItems = lI;



            //MessageBox.Show("B1");
            string strBillFileName=CreateBill( invDetail );
            byte[] fileBytes = File.ReadAllBytes(strBillFileName);
            invDetail.InvoicePDF = fileBytes;
            //MessageBox.Show("B2");
            if (isCashSelected == true)
            {
                invDetail.Cash = true;

            }
            else if (isDigitalSelected == true)
            {
                invDetail.Digital = true;
            }
            //MessageBox.Show("B3");
            msfWContext.InvoiceDetails.Add(invDetail);
            msfWContext.SaveChanges();
            //MessageBox.Show("B4");
            printBill(strBillFileName);
            //MessageBox.Show("B5");
            ResetControls(this.Controls);

           
        }

        private void printBill(string strFileName)
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo()
            {
                CreateNoWindow = true,
                Verb = "print",
                FileName = strFileName
            };
            p.Start();
        }


        private void ResetControls(Control.ControlCollection controls)
        {
            isWithoutItemCodeBill = false;
            labelTotalBillAmount.Text = "I";
            dispItemSizes.Clear();
            displayBillItems.Clear();

            isCashSelected = false;
            isDigitalSelected = false;

            foreach (RadioButton radioButton in radioButtons)
            {
                panel1.Controls.Remove(radioButton);
            }


            foreach (Control control in controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
                else if (control is Label)
                {
                    ItemSellingPrice.Text = "I";
                    itemDesc.Text = "I";
                    itemCode.Text = "I";
                    ItemBrand.Text = "I";
                    ItemInvID.Text = "I";
                    ItemColor.Text = "I";

                    //((TextBox)control).Clear();
                }
                else if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1;
                }
                else if (control is CheckBox)
                {
                    ((CheckBox)control).Checked = false;
                }
                else if (control is DateTimePicker)
                {
                    ((DateTimePicker)control).Value = DateTime.Now;
                }
                else if (control is RadioButton)
                {
                    ((RadioButton)control).Checked = false;




                }
                else if (control is NumericUpDown)
                {
                    ((NumericUpDown)control).Value = 0;
                }
                else if (control is ListBox)
                {
                    ((ListBox)control).SelectedIndex = -1;
                }
                else if (control is DataGridView)
                {
                    ((DataGridView)control).DataSource = null;
                    ((DataGridView)control).Rows.Clear();
                }
                else if (control is Panel || control is GroupBox || control is TabControl || control is TabPage)
                {
                    ResetControls(control.Controls);
                }
            }
        }

        private void ResetItemControls(Control.ControlCollection controls)
        {
            isWithoutItemCodeBill = false;
            textItemSoldPrice.Text = "";
            textQuantity.Text = "";
            dispItemSizes.Clear();
            isCashSelected = false;
            isDigitalSelected = false;

            foreach (RadioButton radioButton in radioButtons)
            {
                panel1.Controls.Remove(radioButton);
            }


            foreach (Control control in controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
                else if (control is Label)
                {
                    ItemSellingPrice.Text = "I";
                    itemDesc.Text = "I";
                    itemCode.Text = "I";
                    ItemBrand.Text = "I";
                    ItemInvID.Text = "I";
                    ItemColor.Text = "I";

                    //((TextBox)control).Clear();
                }
                else if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1;
                }
                else if (control is CheckBox)
                {
                    ((CheckBox)control).Checked = false;
                }
                else if (control is DateTimePicker)
                {
                    ((DateTimePicker)control).Value = DateTime.Now;
                }
                //else if (control is RadioButton)
                //{
                //    ((RadioButton)control).Checked = false;




                //}
                else if (control is NumericUpDown)
                {
                    ((NumericUpDown)control).Value = 0;
                }
                else if (control is ListBox)
                {
                    ((ListBox)control).SelectedIndex = -1;
                }
               
            }
        }


        private void frmGenerateBill_Load(object sender, EventArgs e)
        {
            // Create a new instance of the RadioButton class
            RadioButton radioButton1 = new RadioButton();
            RadioButton radioButton2 = new RadioButton();

            // Set the properties of the RadioButton objects
            radioButton1.Name = "radioButtonDP";
            radioButton1.Text = "Digital";
            radioButton1.Location = new Point(10, 10);
            radioButton1.Size = new Size(100, 50);
            // Assuming you have a RadioButton control named radioButton1
            radioButton1.Font = new System.Drawing.Font(radioButton1.Font.FontFamily, 14, FontStyle.Regular);


            radioButton2.Name = "radioButtonCash";
            radioButton2.Text = "Cash";
            radioButton2.Location = new Point(120, 10);
            radioButton2.Size = new Size(100, 50);
            // Assuming you have a RadioButton control named radioButton1
            radioButton2.Font = new System.Drawing.Font(radioButton1.Font.FontFamily, 14, FontStyle.Regular);


            // Add an event handler for the CheckedChanged event of the RadioButton objects
            radioButton1.CheckedChanged += new EventHandler(radioButton_CheckedChangedPayment);
            radioButton2.CheckedChanged += new EventHandler(radioButton_CheckedChangedPayment);

            // Add the RadioButton objects to the Controls collection of the parent container control
            panel2.Controls.Add(radioButton1);
            panel2.Controls.Add(radioButton2);

        }

        private void radioButton_CheckedChangedPayment(object sender, EventArgs e)
        {
            isCashSelected = false;
            isDigitalSelected = false;
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Text == "Cash")
            {
                isCashSelected = true;
            }
            else if (radioButton.Text == "Digital")
            {
                isDigitalSelected = true;
            }
            
        }



        private void btnGetDetails_Click(object sender, EventArgs e)
        {
            List<ItemSize> listItemsizes = new List<ItemSize>();

            if (textItemCode.Text == "")
            {
                MessageBox.Show("Enter Item Code");
                return;
            }

            Item iBill = (from iteM in msfWContext.Items
                          where iteM.ICode.Equals(textItemCode.Text)
                          select iteM).FirstOrDefault();
            if (iBill != null)
            {
                ResetItemControls(this.Controls);

                var entity = msfWContext.Items.Find(iBill.InvID);
                msfWContext.Entry(entity).Reload();

                if (iBill.AvailableUnits <= 0)
                {
                    MessageBox.Show("Stock Not Available");
                    return;
                }

                listItemsizes = (from itemS in msfWContext.ItemSizes
                                                where itemS.ICode.Equals(iBill.ICode)
                                                select itemS).ToList();
            }


            if (iBill == null)
            {
                ResetItemControls(this.Controls);                //MessageBox.Show("Item Not Found, Please enter selling price, description and proceed");

                var userInput = BillDetailsForm.Show();
                //MessageBox.Show($"Hello, {userInput.Description}!");
                if (userInput != null)
                {
                    itemDesc.Text = userInput.Description;
                    textItemSoldPrice.Text = userInput.SoldPrice.ToString();
                    
                    buttonViewLsellingPrice.Visible = false;
                    isWithoutItemCodeBill = true;
                }
                //return;
            }
            else
            {

                if (listItemsizes.Count()<=0)
                {
                    MessageBox.Show("Stock Not Available");
                    return;

                }

               
                // Create an array of RadioButtons
                Array.Resize(ref radioButtons, listItemsizes.Count());
                int i = 0;
                foreach (ItemSize iSize in listItemsizes)
                {

                    DisplayItemSizes ds = new DisplayItemSizes();
                    //for (int i = 0; i < radioButtons.Length; i++)
                    //{
                        // Create a new RadioButton
                        radioButtons[i] = new RadioButton();
                        radioButtons[i].Font = new System.Drawing.Font(radioButtons[i].Font.FontFamily, 16);


                         // Set the properties of the RadioButton
                         radioButtons[i].Text = "Size:-" + iSize.Size;
                        
                        radioButtons[i].Location = new Point(500, 20 + i * 35);
                        radioButtons[i].Size = new Size(200, 40);

                        // Add the RadioButton to a container control
                        panel1.Controls.Add(radioButtons[i]);

                        // Add the CheckedChanged event handler
                        radioButtons[i].CheckedChanged += new EventHandler(radioButton_CheckedChanged);

                    ds.SizeID = iSize.SizeID;
                    ds.IndexValue = i;

                    dispItemSizes.Add(ds);


                    //}
                    i = i + 1;

                }

                itemDesc.Text = iBill.Description;
                itemCode.Text = iBill.ICode;
                ItemColor.Text = iBill.ColourType.Description;
                ItemBrand.Text = iBill.BrandType.Description;
                ItemInvID.Text = iBill.InvID.ToString();

                ItemSellingPrice.Text = iBill.SellingPrice.ToString();
                //ItemLastPrice.Text = iBill.LastSellingPrice.ToString();
                LastSellingPrice = iBill.LastSellingPrice;
            }


        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DisplayItemSizes obj in dispItemSizes)
            {
                obj.IsSelected = false;
            }


            RadioButton radioButton = sender as RadioButton;
            int index = Array.IndexOf(radioButtons, radioButton);
            if (radioButton.Checked)
            {

                // Use LINQ to find the person with the specified name, and update their Age property
                dispItemSizes = dispItemSizes.Select(p=> p.IndexValue == index ? new DisplayItemSizes { SizeID = p.SizeID, IndexValue = p.IndexValue, IsSelected = true } : p).ToList();

                // This radio button is now checked
                // Do something with the index value
            }
        }


        private void itemCode_Click(object sender, EventArgs e)
        {

        }

        private string CreateBill(InvoiceDetail invPDF)
        {
            CompanyDetail cd=  (from comp in msfWContext.CompanyDetails
                                where comp.CompanyID.Equals(1)
                                select comp).FirstOrDefault();
            string currentDate = DateTime.Now.ToString("dd/MM/yyyy h:mm tt");

            string monthYear = DateTime.Now.ToString("MMMM-yyyy"); // Get the current month and year in the format "Month-Year"
            string folderPath = ConfigurationManager.AppSettings["BillDirectoryPath"] + @"\" + monthYear;

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath); // Create the folder if it doesn't exist
            }

            string strInvoiceFileName = invPDF.InvoiceNumber.Replace(@"/", "_");
            string strInvoiceFileNameFullPath = folderPath + @"\" + strInvoiceFileName + ".pdf";

            System.IO.FileStream fs = new FileStream(strInvoiceFileNameFullPath, FileMode.Create);


            //var pgSize = new iTextSharp.text.Rectangle(0, 0, 144, 255);
            var pgSize = new iTextSharp.text.Rectangle(0, 0, 144, 500);
            //var pgSize = new iTextSharp.text.Rectangle(10, 10);
            Document document = new Document(pgSize, 5f, 5f, 0f, 0f);
            // Create an instance of the document class which represents the PDF document itself.  
            //Document document = new Document(PageSize., 25, 25, 30, 30);
            // Create an instance to the PDF file by creating an instance of the PDF   
            // Writer class using the document and the filestrem in the constructor.  

            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            // Add meta information to the document  
            document.AddAuthor(cd.CompanyName);
            document.AddCreator("MSFW Soultions");
            document.AddKeywords("Invoice");
            document.AddSubject("Invoice");
            document.AddTitle(invPDF.InvoiceNumber);

            // Open the document to enable you to write to the document  
            document.Open();


            //TEST 1
            //// Add a simple and wellknown phrase to the document in a flow layout manner  
            //BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            //iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 7, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            //Paragraph para = new Paragraph("ABC Limited", times);
            //para.Alignment = Element.ALIGN_CENTER;

            //document.Add(new Paragraph(para));

            //LineSeparator line = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_LEFT, 1);
            //document.Add(new Paragraph("\n"));
            //document.Add(line);
            ////TEST 2
            ///
            string headText0 = "TAX INVOICE";
            string headText = cd.CompanyName + "\n" + "Banaswadi";
            string gstText2           = "GSTIN                     : " + cd.GSTNumber + " ";
            string invoiceNumberText2 = " Invoice Number       : " + invPDF.InvoiceNumber + " ";
            string BillDate = " Date                        : " + currentDate  ; 

            //headText = headText.Replace(Environment.NewLine, String.Empty).Replace("  ", String.Empty);
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, false);

            iTextSharp.text.Font brown = new iTextSharp.text.Font(bfTimes, 9f, iTextSharp.text.Font.NORMAL, new BaseColor(163, 21, 21));

            iTextSharp.text.Font lightblue = new iTextSharp.text.Font(bfTimes, 7f, iTextSharp.text.Font.NORMAL, new BaseColor(0, 0, 0));

            iTextSharp.text.Font courier = new iTextSharp.text.Font(bfTimes, 9f);

            iTextSharp.text.Font georgia = FontFactory.GetFont("georgia", 10f);

            iTextSharp.text.Font iTemgeorgia = FontFactory.GetFont("georgia", 8f);

            iTextSharp.text.Font iNumbereorgia = FontFactory.GetFont("georgia", 7f);

            iTextSharp.text.Font georgia0 = FontFactory.GetFont("georgia", 8f);

            iTextSharp.text.Font georgia2 = FontFactory.GetFont("georgia", 8f);

            georgia.Color = BaseColor.GRAY;


            Chunk heading0 = new Chunk(headText0, georgia0);
            Chunk heading = new Chunk(Environment.NewLine + headText, georgia);
            Chunk gstChunk = new Chunk( gstText2, iNumbereorgia);
            Chunk invoiceNumChunk = new Chunk(invoiceNumberText2, iNumbereorgia);
            Chunk invoiceDateChunk = new Chunk(BillDate, iNumbereorgia);

            string lineText = Environment.NewLine + "----------------------------------------";
            string lineTextAfterGST = "   ----------------------------------------";
            string itemcolumnHeadings = "SN  ITEMS (Q) RATE     AMT";
            string lineTextAfterColumnHeadings = Environment.NewLine + "----------------------------------------";
            Chunk chnkLineText = new Chunk(lineText, georgia);
            Chunk chnkLineTextGST = new Chunk(lineTextAfterGST, georgia);
            Chunk chnkLineTextItemColumnHeadings = new Chunk(itemcolumnHeadings, georgia);
            Chunk chnkLineTextAfterColumHeadings = new Chunk(lineTextAfterColumnHeadings, georgia);


            Phrase pGST = new Phrase();
            pGST.Add(gstChunk);
            pGST.Add(invoiceNumChunk);
            pGST.Add(invoiceDateChunk);
            pGST.Add(chnkLineTextGST);

            //Phrase pinvNum = new Phrase();
            //pinvNum.Add(invoiceNumChunk);

            Phrase pCHeading = new Phrase();
            pCHeading.Add(chnkLineTextItemColumnHeadings);
            pCHeading.Add(chnkLineTextAfterColumHeadings);

            Phrase p1 = new Phrase();
            p1.Add(heading0);
            p1.Add(heading);
            p1.Add(chnkLineText);

            Paragraph para1 = new Paragraph(p1);
            para1.Alignment = Element.ALIGN_CENTER;
            document.Add(para1);

            Paragraph paraGST = new Paragraph(pGST);
            paraGST.Alignment = Element.ALIGN_LEFT;
            document.Add(paraGST);

            //Paragraph parainvNum = new Paragraph(pinvNum);
            //parainvNum.Alignment = Element.ALIGN_LEFT;
            //document.Add(parainvNum);

            Paragraph paraCHeading = new Paragraph(pCHeading);
            paraCHeading.Alignment = Element.ALIGN_LEFT;
            document.Add(paraCHeading);

            int srNo = 1;

            foreach (InvoiceItem iItem in invPDF.InvoiceItems) 
            {
                //string itemLine = Environment.NewLine + srNo.ToString() + "       " + iItem.ItemDescription + "  (" + iItem.Quantity.ToString() + ")         " + iItem.Rate + "        " + iItem.TotalAmount.ToString();
                string itemLine =  srNo.ToString() + "  " + iItem.ItemDescription + "  (" + iItem.Quantity.ToString() + ")   " + iItem.Rate + "        " + iItem.TotalAmount.ToString();

                Chunk c1 = new Chunk(itemLine, iTemgeorgia);


                Phrase p2 = new Phrase();

                p2.Add(c1);

                //p2.Add(c2);

                //p2.Add(c3);

                //p2.Add(c4);

                //p2.Add(c5);

                //p2.Add(c6);

                //p2.Add(c7);

                //p2.Add(c8);

                //p2.Add(c9);

                Paragraph para2 = new Paragraph();

                //para2.Add(p1);

                para2.Add(p2);

                document.Add(para2);
                srNo = srNo + 1;
            }

            string lineTextAfterItemDetails = "------------------------------------------------";
            Chunk chnklineTextAfterItemDetails = new Chunk(lineTextAfterItemDetails, iTemgeorgia);

            string lineSubTotal = "SUB TOTAL                               " + invPDF.InvoiceItems.Sum(x=>x.TotalAmount).ToString() ;
            Chunk chnklineTextSubTotal = new Chunk(lineSubTotal, iTemgeorgia);


            string lineTextAfterSubTotal = "   ------------------------------------------------";
            Chunk chnklineTextAfterSubTotal = new Chunk(lineTextAfterSubTotal, iTemgeorgia);


            Phrase pSubTotal = new Phrase();
            pSubTotal.Add(chnklineTextAfterItemDetails);
            pSubTotal.Add(chnklineTextSubTotal);
            pSubTotal.Add(chnklineTextAfterSubTotal);

            Paragraph paraSubTotal = new Paragraph(pSubTotal);
            paraSubTotal.Alignment = Element.ALIGN_LEFT;
            document.Add(paraSubTotal);

            //Taxable Amount

            string lineTaxableAmount = "TAXABLE AMOUNT                  " + invPDF.TaxableAmount.ToString();
            Chunk chnklineTextTaxableAmount = new Chunk(lineTaxableAmount, iTemgeorgia);

            string lineSGST = "    CGST " + cd.CGST.ToString() + "%                               " + invPDF.SGST.ToString();
            Chunk chnklineTextTaxableSGST = new Chunk(lineSGST, iTemgeorgia);

            string lineCGST = "    SGST " + cd.SGST.ToString() + "%                               " + invPDF.CGST.ToString();
            Chunk chnklineTextTaxableCGST = new Chunk(lineCGST, iTemgeorgia);


            string lineTextAfterTaxableAmount = "    ------------------------------------------------";
            Chunk chnklineTextAfterTaxableAmount = new Chunk(lineTextAfterTaxableAmount, iTemgeorgia);


            Phrase pTaxableAmount = new Phrase();
            pTaxableAmount.Add(chnklineTextTaxableAmount);
            pTaxableAmount.Add(chnklineTextTaxableSGST);
            pTaxableAmount.Add(chnklineTextTaxableCGST);
            pTaxableAmount.Add(chnklineTextAfterTaxableAmount);

            Paragraph paraTaxableAmount = new Paragraph(pTaxableAmount);
            paraTaxableAmount.Alignment = Element.ALIGN_LEFT;
            document.Add(paraTaxableAmount);



            //Total Amount

            string lineTotalAmount = "TOTAL AMOUNT                     " + invPDF.TotalPayable.ToString();
            Chunk chnklineTextTotalAmount = new Chunk(lineTotalAmount, iTemgeorgia);

            string lineTextAfterTotalAmount = "    ------------------------------------------------";
            Chunk chnklineTextAfterTotalAmount = new Chunk(lineTextAfterTotalAmount, iTemgeorgia);


            Phrase pTotalAmount = new Phrase();
            pTotalAmount.Add(chnklineTextTotalAmount);
            pTotalAmount.Add(chnklineTextAfterTotalAmount);
           

            Paragraph paraTotalAmount = new Paragraph(pTotalAmount);
            paraTotalAmount.Alignment = Element.ALIGN_LEFT;
            document.Add(paraTotalAmount);

            //Terms Amount

            string lineTerms = "TERMS AND CONDITIONS" + "\n";
            Chunk chnklineTextlineTerms = new Chunk(lineTerms, iNumbereorgia);

            string lineTerms1 = "Goods once sold will not be taken back or exchanged";
            Chunk chnklineTextlineTerms1 = new Chunk(lineTerms1, iNumbereorgia);

            


            Phrase pTerms = new Phrase();
            pTerms.Add(chnklineTextlineTerms);
            pTerms.Add(chnklineTextlineTerms1);


            Paragraph paraTerms = new Paragraph(pTerms);
            paraTerms.Alignment = Element.ALIGN_LEFT;
            document.Add(paraTerms);





            // Close the document  
            document.Close();
            // Close the writer instance  
            writer.Close();
            // Always close open filehandles explicity  
            fs.Close();

            MessageBox.Show("Bill Generated Seccuessfully");
            
            return strInvoiceFileNameFullPath;


        }






        private void showLastSellingPrice()
        {
            buttonViewLsellingPrice.Text = LastSellingPrice.ToString();
        }
        private void resetLastSellingPrice()
        {
            buttonViewLsellingPrice.Text = "OK";
        }

        private void buttonViewLsellingPrice_MouseDown(object sender, MouseEventArgs e)
        {
            showLastSellingPrice();
        }

        private void buttonViewLsellingPrice_MouseUp(object sender, MouseEventArgs e)
        {
            resetLastSellingPrice();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if(textItemSoldPrice.Text=="")
            {
                MessageBox.Show("Please enter Sold Price");
                return;
            }

            if (textQuantity.Text == "")
            {
                MessageBox.Show("Please enter Quantity");
                return;
            }

            if (itemDesc.Text == "I" || itemDesc.Text == "")
            {
                MessageBox.Show("Invalid Entry");
                return;
            }

            if (!isWithoutItemCodeBill)
            {
                if (Convert.ToInt32(textItemSoldPrice.Text) < LastSellingPrice)
                {
                    MessageBox.Show("The Sold Price is lesser than the Item Last Selling Price");
                    return;
                }
            }






            DisplayInvoiceItem invItem = new DisplayInvoiceItem();
            if (isWithoutItemCodeBill)
            {
                invItem.InvID = null;
                invItem.Rate = Convert.ToInt32(textItemSoldPrice.Text);
                invItem.Quantity = Convert.ToInt32(textQuantity.Text);
                invItem.ItemDescription = itemDesc.Text;
                invItem.TotalAmount = invItem.Rate * invItem.Quantity;
                invItem.isWithoutItemCodeBill = true;
            }
            else
            {


                List<DisplayItemSizes> selectedSizes = dispItemSizes.Where(x => x.IsSelected).ToList();


                if (selectedSizes.Count() <= 0)
                {
                    MessageBox.Show("Size Not Selected");
                    return;
                }

                   


                invItem.InvID = Convert.ToInt32(ItemInvID.Text);
                invItem.Rate = Convert.ToInt32(textItemSoldPrice.Text);
                invItem.Quantity = Convert.ToInt32(textQuantity.Text);
                invItem.ItemDescription = itemDesc.Text;
                invItem.TotalAmount = invItem.Rate * invItem.Quantity;
                DisplayItemSizes iSize= (from isz in dispItemSizes
                                         where isz.IsSelected==true
                                         select isz).FirstOrDefault();
                invItem.SizeID = iSize.SizeID;

                var entity = msfWContext.ItemSizes.Find(iSize.SizeID);
                msfWContext.Entry(entity).Reload();

                ItemSize SelectedItemsize = new ItemSize();

                SelectedItemsize = (from itemS in msfWContext.ItemSizes
                                    where itemS.SizeID == iSize.SizeID
                                    select itemS).FirstOrDefault();


                invItem.Size = SelectedItemsize.Size;



                if (invItem.Quantity > SelectedItemsize.Count)
                {
                    MessageBox.Show("Stock Not Available");
                    return;
                }
                if (displayBillItems.Count() > 0)
                {
                    if (invItem.Quantity + displayBillItems.Where(p => p.InvID == invItem.InvID && p.SizeID ==iSize.SizeID).Sum(p=>p.Quantity) > SelectedItemsize.Count)
                    {
                        MessageBox.Show("Stock Not Available");
                        return;
                    }
                }



            }
            isWithoutItemCodeBill = false;
            displayBillItems.Add(invItem);
            LoadDataGridBillItem();
            ResetItemControls(this.Controls);

            labelTotalBillAmount.Text = displayBillItems.Sum(s => s.TotalAmount).ToString();
            


        }

        private void LoadDataGridBillItem()
        {

            
            //List<barCodeItem> btItems = new List<barCodeItem>();
            dataGridViewBillItem.DataSource = null;
            //foreach (DisplayInvoiceItem itm in displayBillItems)
            //{
            //    btItems.Add(new barCodeItem { ICode = itm.ICode, Description = itm.Description, DateOfPurchase = itm.DateOfPurchase, ItemCount = itm.AvailableUnits, IsSaleDiscount = itm.IsSaleDiscount, SaleDiscountP = itm.SaleDiscountP, Rack = itm.Rack, SellingPrice = itm.SellingPrice, IsChecked = false });
            //}

            dataGridViewBillItem.DataSource = displayBillItems;
            dataGridViewBillItem.Columns[0].Visible = false;
            dataGridViewBillItem.Columns[4].Visible = false;
            //dataGridViewBillItem.Columns[5].Visible = false;
            dataGridViewBillItem.Columns[6].Visible = false;

            DataGridViewColumn descColumn = dataGridViewBillItem.Columns[3];
            DataGridViewColumn sizeColumn = dataGridViewBillItem.Columns[7];
            DataGridViewColumn quantColumn = dataGridViewBillItem.Columns[2];
            descColumn.DisplayIndex = 0;
            sizeColumn.DisplayIndex = 1;
            quantColumn.DisplayIndex = 3;


            dataGridViewBillItem.Refresh();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridViewBillItem.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewBillItem.SelectedRows[0].Index;
                dataGridViewBillItem.Rows.RemoveAt(rowIndex);
            }

           
            dataGridViewBillItem.Refresh();
            labelTotalBillAmount.Text = displayBillItems.Sum(s => s.TotalAmount).ToString();
        }

        private void textItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the key pressed is a numeric digit or a control key (backspace, delete, etc.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Set the Handled property of the KeyPressEventArgs object to true to indicate the event is handled
                e.Handled = true;
            }
        }

        private void textItemSoldPrice_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textItemSoldPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the key pressed is a numeric digit or a control key (backspace, delete, etc.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Set the Handled property of the KeyPressEventArgs object to true to indicate the event is handled
                e.Handled = true;
            }
        }

        private void textQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the key pressed is a numeric digit or a control key (backspace, delete, etc.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Set the Handled property of the KeyPressEventArgs object to true to indicate the event is handled
                e.Handled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetControls(this.Controls);
        }
    }



    public class FinancialYear
    {
        //int yearNumber;
        string yearNumber;
        private static readonly int firstMonthInYear = 4;

        public static FinancialYear Current
        {
            get { return new FinancialYear(DateTime.Today); }
        }

        public FinancialYear(DateTime forDate)
        {
            if (forDate.Month < firstMonthInYear)
            {
                //yearNumber = forDate.Year + 1;
                yearNumber = (forDate.Year - 1).ToString() + "-" + forDate.Year.ToString();
            }
            else
            {
                //yearNumber = forDate.Year;
                yearNumber = (forDate.Year).ToString() + "-" + (forDate.Year+1).ToString();
            }
        }

        public override string ToString()
        {
            return yearNumber.ToString();
        }
    }
}
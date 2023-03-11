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
    public partial class BillDetailsForm : Form
    {
        public BillDetailsForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public static ManualBill Show()
        {

            ManualBill b = new ManualBill();
            using (var form = new BillDetailsForm())
            {
                //form.PromptLabel.Text = prompt;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    b.SoldPrice = Convert.ToInt32(form.textBoxSoldPrice.Text);
                    b.Description = form.textItemDescription.Text;
                    //return form.textBoxSoldPrice.Text;
                    return b;
                }
                else
                {
                    return null;
                }
            }
        }

        private void textBoxSoldPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the key pressed is a numeric digit or a control key (backspace, delete, etc.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Set the Handled property of the KeyPressEventArgs object to true to indicate the event is handled
                e.Handled = true;
            }
        }
    }

    public class ManualBill
    {
        public string Description { get; set; }
        public int SoldPrice { get; set; }

    }
}

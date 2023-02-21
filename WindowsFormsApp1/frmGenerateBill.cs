using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmGenerateBill : Form
    {
        public frmGenerateBill()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Create a rectangle with a 10-pixel margin
            Rectangle rect = new Rectangle(10, 10, panel1.ClientSize.Width - 20, panel1.ClientSize.Height - 20);

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
            g.DrawLine(pen, x, y1+10, x, y2-90);


            // Draw a horizontal line across the middle of the panel
            int y = (panel1.Height / 2)+50;
            g.DrawLine(Pens.Green, 0+10, y, panel1.Width-10, y);

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GDIDrawer;

namespace CMPE1700BrandonFooteICA6
{
    public partial class Form1 : Form
    {
        public static CDrawer canvas = new CDrawer(800, 600, false);
        public static Color[,] ColorArray = new Color[60, 80];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            canvas.Scale = 10;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            for(int count = 0; count < 60; count++)
            {
                for (int count2 = 0; count2 < 80; count2++)
                {
                    ColorArray[count, count2] = Color.Black;
                    if (count == 0 || count2 == 0 || count == 59 || count2 == 79)
                    {
                        ColorArray[count, count2] = Color.Red;
                    }
                }
            }

            for (int count = 0; count < tkbNumBlocks.Value; count++)
            {
                int xPoint = 0;
                int yPoint = 0;
                do
                {
                    xPoint = random.Next(1, 59);
                    yPoint = random.Next(1, 79); 
                }
                while(ColorArray[xPoint,yPoint] == Color.Red);

                ColorArray[xPoint, yPoint] = Color.Red;
            }

            for (int count = 0; count < 60; count++)
            {
                for (int count2 = 0; count2 < 80; count2++)
                {
                    canvas.SetBBScaledPixel(count2,count,ColorArray[count,count2]);
                }
            }
            canvas.Render();
        }

        private void btnFillColor_Click(object sender, EventArgs e)
        {
            cldNewDialog.ShowDialog();
            lblColorDisplay.BackColor = cldNewDialog.Color;
        }
        public static void FloodFill(int x, int y, Color Target, Color FillColor)
        {
            if (x >= 0 && x <= 79 && y >= 0 && y <= 59)
            {
                if (ColorArray[y, x] != Target)
                {
                    return;
                }
                else if (ColorArray[y, x] == FillColor)
                {
                    return;
                }
                else
                {
                    ColorArray[y, x] = FillColor;
                    canvas.SetBBScaledPixel(x, y, FillColor);
                }
                FloodFill(x - 1, y, Target, FillColor);
                FloodFill(x + 1, y, Target, FillColor);
                FloodFill(x, y - 1, Target, FillColor);
                FloodFill(x, y + 1, Target, FillColor);
                return;
            }
            
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            tmrFillTimer.Interval = 100;
            tmrFillTimer.Start();
        }

        private void tmrFillTimer_Tick(object sender, EventArgs e)
        {
            bool success = false;
            Point newPoint = new Point();
            Color Target = new Color();
            success = canvas.GetLastMouseLeftClickScaled(out newPoint);
            if (success == true)
            {
                Target = ColorArray[newPoint.Y, newPoint.X];
                Console.WriteLine("Click");
                FloodFill(newPoint.X, newPoint.Y, Target, lblColorDisplay.BackColor);
                canvas.Render();
                
            }
        }
    }
}

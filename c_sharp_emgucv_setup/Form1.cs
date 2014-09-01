using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Bitmap img;
       // Bitmap src;
    

        public Form1()
        {
            InitializeComponent();
        }
        /** 讀影像 **/
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {   string name = op.FileName;
                //Image newImage = Image.FromFile(name);
                img = (Bitmap)Bitmap.FromFile(name);
                pictureBox1.Image = img;  
                //pictureBox1.Image = newImage;
            }
           

        }
        // Gray processing 將影像灰階化
        private void GrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap GrayBitmap = new Bitmap(img.Width, img.Height);

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    //get the pixel from the original image
                    Color originalColor = img.GetPixel(i, j);

                    //create the grayscale version of the pixel
                    int grayScale = (int)((originalColor.R * .3) + (originalColor.G * .59)
                        + (originalColor.B * .11));

                    //create the color object
                    Color newColor = Color.FromArgb(grayScale, grayScale, grayScale);

                    //set the new image's pixel to the grayscale version
                    GrayBitmap.SetPixel(i, j, newColor);
                    pictureBox2.Image = GrayBitmap;
                }
            }
        }
    }
}

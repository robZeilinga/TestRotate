using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestRotate
{
    public partial class Form1 : Form
    {

        string fileName = "";
        string  initialImg = "";
        Image img = null;

        public Form1()
        {
            InitializeComponent();

            openFileDialog1.InitialDirectory = @"C:\Users\rober\Pictures\";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr =  openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK || dr == DialogResult.Yes)
            {
                fileName = openFileDialog1.FileName;
                pictureBox1.Load(fileName);
                initialImg = fileName;
                img = pictureBox1.Image;
            }
        }

        // reset image
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Load(initialImg);
            img = pictureBox1.Image;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            img = RotateImage(img, 1, 1);
            pictureBox1.Image = img;
            
        }

        // rotate image from: http://code-bude.net/2011/07/12/bilder-rotieren-mit-csharp-bitmap-rotateflip-vs-gdi-graphics/
        public static Image RotateImage(Image img, float rotationAngle, float zoom)
        {
            using (Graphics gfx = Graphics.FromImage(img))
            {
                gfx.TranslateTransform((float)img.Width / 2, (float)img.Height / 2);
                gfx.RotateTransform(rotationAngle);
                gfx.ScaleTransform(zoom, zoom);
                gfx.TranslateTransform(-(float)img.Width / 2, -(float)img.Height / 2);
                gfx.DrawImage(img, new Point(0, 0));
            }
            return img;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            img = RotateImage(img, -1, 1);
            pictureBox1.Image = img;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            img = RotateImage(img, 0.1f, 1);
            pictureBox1.Image = img;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            img = RotateImage(img, -0.1f, 1);
            pictureBox1.Image = img;
        }
    }
}

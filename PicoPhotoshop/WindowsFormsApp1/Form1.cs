using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace PicoPhotoshopForm
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = @"Image files (*.jpg, *.jpeg, *.jpe, *.png) | *.jpg; *.jpeg; *.jpe; *.png";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;

                ImageBox.Image = Image.FromFile(filename);
                ImageBox.ImageLocation = filename;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ImageBox.Image = null;
        }

        private void trackBarBr_ValueChanged(object sender, EventArgs e)
        {
            int value1 = trackBarBr.Value;
            float value = value1 * 0.01f;

            float[][] colorMatrixElements = {
                new float[] {1,0,0,0,0},
                new float[] {0,1,0,0,0},
                new float[] {0,0,1,0,0},
                new float[] {0,0,0,1,0},
                new float[] {value,value,value,0,1}
            };

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Image _img = Image.FromFile(ImageBox.ImageLocation);

            Graphics _g = default(Graphics);
            Bitmap bm_dest = new Bitmap(Convert.ToInt32(_img.Width), Convert.ToInt32(_img.Height));
            _g = Graphics.FromImage(bm_dest);
            _g.DrawImage(_img, new Rectangle(0, 0, bm_dest.Width + 1, bm_dest.Height + 1), 0, 0, bm_dest.Width + 1, bm_dest.Height + 1, GraphicsUnit.Pixel, imageAttributes);
            ImageBox.Image = bm_dest;
            this.Refresh();
        }

        private void ContrastBar_ValueChanged(object sender, EventArgs e)
        {
            float contrast = ContrastBar.Value*0.01f;
            contrast = 1 + contrast;
            float value = 0.5f*(1.0f-contrast);

            float[][] colorMatrixElements = {
                new float[] {contrast,0,0,0,0},
                new float[] {0,contrast,0,0,0},
                new float[] {0,0,contrast,0,0},
                new float[] {0,0,0,1.0f,0},
                new float[] {value,value,value,0,1}
            };

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Image _img = Image.FromFile(ImageBox.ImageLocation);

            Graphics _g = default(Graphics);
            Bitmap bm_dest = new Bitmap(Convert.ToInt32(_img.Width), Convert.ToInt32(_img.Height));
            _g = Graphics.FromImage(bm_dest);
            _g.DrawImage(_img, new Rectangle(0, 0, bm_dest.Width + 1, bm_dest.Height + 1), 0, 0, bm_dest.Width + 1, bm_dest.Height + 1, GraphicsUnit.Pixel, imageAttributes);
            ImageBox.Image = bm_dest;
            this.Refresh();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int value1 = trackBar1.Value;
            float value = value1 * 0.01f;

            float[][] colorMatrixElements = {
                new float[] {value,0,0,0,0},
                new float[] {0,1,0,0,0},
                new float[] {0,0,1,0,0},
                new float[] {0,0,0,1,0},
                new float[] {0,0,0,0,1}
            };

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Image _img = Image.FromFile(ImageBox.ImageLocation);

            Graphics _g = default(Graphics);
            Bitmap bm_dest = new Bitmap(Convert.ToInt32(_img.Width), Convert.ToInt32(_img.Height));
            _g = Graphics.FromImage(bm_dest);
            _g.DrawImage(_img, new Rectangle(0, 0, bm_dest.Width + 1, bm_dest.Height + 1), 0, 0, bm_dest.Width + 1, bm_dest.Height + 1, GraphicsUnit.Pixel, imageAttributes);
            ImageBox.Image = bm_dest;
            this.Refresh();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            int value1 = trackBar2.Value;
            float value = value1 * 0.01f;

            float[][] colorMatrixElements = {
                new float[] {1,0,0,0,0},
                new float[] {0,value,0,0,0},
                new float[] {0,0,1,0,0},
                new float[] {0,0,0,1,0},
                new float[] {0,0,0,0,1}
            };

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Image _img = Image.FromFile(ImageBox.ImageLocation);

            Graphics _g = default(Graphics);
            Bitmap bm_dest = new Bitmap(Convert.ToInt32(_img.Width), Convert.ToInt32(_img.Height));
            _g = Graphics.FromImage(bm_dest);
            _g.DrawImage(_img, new Rectangle(0, 0, bm_dest.Width + 1, bm_dest.Height + 1), 0, 0, bm_dest.Width + 1, bm_dest.Height + 1, GraphicsUnit.Pixel, imageAttributes);
            ImageBox.Image = bm_dest;
            this.Refresh();
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            int value1 = trackBar3.Value;
            float value = value1 * 0.01f;

            float[][] colorMatrixElements = {
                new float[] {1,0,0,0,0},
                new float[] {0,1,0,0,0},
                new float[] {0,0,value,0,0},
                new float[] {0,0,0,1,0},
                new float[] {0,0,0,0,1}
            };

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Image _img = Image.FromFile(ImageBox.ImageLocation);

            Graphics _g = default(Graphics);
            Bitmap bm_dest = new Bitmap(Convert.ToInt32(_img.Width), Convert.ToInt32(_img.Height));
            _g = Graphics.FromImage(bm_dest);
            _g.DrawImage(_img, new Rectangle(0, 0, bm_dest.Width + 1, bm_dest.Height + 1), 0, 0, bm_dest.Width + 1, bm_dest.Height + 1, GraphicsUnit.Pixel, imageAttributes);
            ImageBox.Image = bm_dest;
            this.Refresh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ImageBox.Invalidate();
            ImageBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ImageBox.Invalidate();
            ImageBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
        }

        /*public void SetContrast(double contrast)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            if (contrast < -100) contrast = -100;
            if (contrast > 100) contrast = 100;
            contrast = (100.0 + contrast) / 100.0;
            contrast *= contrast;
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    double pR = c.R / 255.0;
                    pR -= 0.5;
                    pR *= contrast;
                    pR += 0.5;
                    pR *= 255;
                    if (pR < 0) pR = 0;
                    if (pR > 255) pR = 255;

                    double pG = c.G / 255.0;
                    pG -= 0.5;
                    pG *= contrast;
                    pG += 0.5;
                    pG *= 255;
                    if (pG < 0) pG = 0;
                    if (pG > 255) pG = 255;

                    double pB = c.B / 255.0;
                    pB -= 0.5;
                    pB *= contrast;
                    pB += 0.5;
                    pB *= 255;
                    if (pB < 0) pB = 0;
                    if (pB > 255) pB = 255;

                    bmap.SetPixel(i, j,
                    Color.FromArgb((byte)pR, (byte)pG, (byte)pB));
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
        }*/

    }
}

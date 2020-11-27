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
        bool paint = false;
        bool isDraw = false;
        Image tmp;
        Image original;
        string filename;
        Size imageSize;
        private List<Point> pointsToDraw = new List<Point>();

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = @"Image files (*.jpg, *.jpeg, *.jpe, *.png) | *.jpg; *.jpeg; *.jpe; *.png";
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMargin = new System.Drawing.Size(5, 5);
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(20, 20);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;

                tmp = Image.FromFile(filename);
                ImageBox.Image = tmp;
                original = tmp;
                ImageBox.ImageLocation = filename;
                ImageBox.Height = tmp.Height;
                ImageBox.Width = tmp.Width;
                panel1.Height = tmp.Height;
                panel1.Width = tmp.Width;
                imageSize = tmp.Size;
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

            Image _img = tmp;
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
            Image _img = tmp;

            Graphics _g = default(Graphics);
            Bitmap bm_dest = new Bitmap(Convert.ToInt32(_img.Width), Convert.ToInt32(_img.Height));
            _g = Graphics.FromImage(bm_dest);
            _g.DrawImage(_img, new Rectangle(0, 0, bm_dest.Width + 1, bm_dest.Height + 1), 0, 0, bm_dest.Width + 1, bm_dest.Height + 1, GraphicsUnit.Pixel, imageAttributes);
            ImageBox.Image = bm_dest;
            this.Refresh();
        }

        private void ChangeColor(object sender, EventArgs e)
        {
            int value1 = trackBar1.Value;
            int value2 = trackBar2.Value;
            int value3 = trackBar3.Value;
            float red = value1 * 0.01f;
            float green = value2 * 0.01f;
            float blue = value3 * 0.01f;

            float[][] colorMatrixElements = {
                new float[] {red,0,0,0,0},
                new float[] {0,green,0,0,0},
                new float[] {0,0,blue,0,0},
                new float[] {0,0,0,1,0},
                new float[] {0,0,0,0,1}
            };

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Image _img = tmp;

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
            int tmpSize = imageSize.Width;
            imageSize.Width = imageSize.Height;
            imageSize.Height = tmpSize;
            ImageBox.Size = imageSize;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ImageBox.Invalidate();
            ImageBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            int tmpSize = imageSize.Width;
            imageSize.Width = imageSize.Height;
            imageSize.Height = tmpSize;
            ImageBox.Size = imageSize;
        }

        private void SaveImage(object sender, EventArgs e)
        {
            tmp = ImageBox.Image;
        }

        private void RotationAngle_Scroll(object sender, EventArgs e)
        {
            Image _img = tmp;
            Bitmap bmp = new Bitmap(Convert.ToInt32(_img.Width), Convert.ToInt32(_img.Height));
            Graphics gfx = Graphics.FromImage(bmp);

            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
            gfx.RotateTransform(RotationAngle.Value);
            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
            gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            gfx.DrawImage(_img, new Rectangle(0, 0, bmp.Width + 1, bmp.Height + 1), 0, 0, bmp.Width + 1, bmp.Height + 1, GraphicsUnit.Pixel); 
           
            ImageBox.Image = bmp;
            gfx.Dispose();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tmp = original;
            ImageBox.Image = tmp;
        }

        private void ImageBox_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;
            if (isDraw)
            {
                pointsToDraw.Clear();
            }
        }

        private void ImageBox_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            if (isDraw && (e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                pointsToDraw.Add(e.Location);
            }
        }

        private void ImageBox_MouseMove(object sender, MouseEventArgs e)
        {
            if ((paint) && (isDraw))
            {
                if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                {
                    pointsToDraw.Add(e.Location);
                    using (Graphics grp = Graphics.FromImage(ImageBox.Image))
                    {
                        if (pointsToDraw.Count > 1)
                            grp.DrawLines(Pens.Black, pointsToDraw.ToArray());
                    }
                    tmp = ImageBox.Image;
                    ImageBox.Refresh();
                    ImageBox.Invalidate();
                }

                /*Brush pen = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
                Image _img = tmp;
                Bitmap bmp = new Bitmap(Convert.ToInt32(_img.Width), Convert.ToInt32(_img.Height));
                Graphics gfx = Graphics.FromImage(bmp);
                gfx.DrawImage(_img, new Rectangle(0, 0, bmp.Width + 1, bmp.Height + 1), 0, 0, bmp.Width + 1, bmp.Height + 1, GraphicsUnit.Pixel);
                gfx.FillEllipse(pen, new Rectangle(e.X, e.Y, 10, 10));
                ImageBox.Image = bmp;
                tmp = ImageBox.Image;*/
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (ImageBox.Image != null)
            { 
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ImageBox.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            isDraw = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            isDraw = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SizeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScaleImageOnPictureBox(SizeBox.SelectedItem.ToString());
        }

        private int ParseSizeString(String text)
        {
            var temp = "";
            foreach (char c in text)
            {
                if (Char.IsNumber(c))
                    temp += c;
                else
                    break;
            }
            if (temp == "")
                throw new ArgumentException("Некорректный ввод");
            else
            {
                var result = Int32.Parse(temp);
                if (result > 200)
                    throw new ArgumentException("Value must be less than 200%");
                else
                    return result;
            }
        }

        private void CalculateModifiedImageSize(int widthZoom, int heightZoom)
        {
            if (tmp == null)
                throw new ArgumentNullException("Image", @"Choose image");
            imageSize = new Size((tmp.Width * widthZoom) / 100, (tmp.Height * heightZoom) / 100);
        }

        private void ScaleImageOnPictureBox(String text)
        {
            try
            {
                Int32 zoom = ParseSizeString(text);
                CalculateModifiedImageSize(zoom, zoom);
                if (ImageBox.Image != null)
                {
                    RedrawPictureBoxImage(tmp, imageSize);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RedrawPictureBoxImage(Image source, Size modifiedSize)
        {
            Bitmap bm_dest = new Bitmap(modifiedSize.Width, modifiedSize.Height, PixelFormat.Format24bppRgb);

            using (Graphics gr_dest = Graphics.FromImage(bm_dest))
            {
                gr_dest.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                gr_dest.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                gr_dest.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                gr_dest.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                gr_dest.DrawImage(source, 0, 0, bm_dest.Width, bm_dest.Height);
            }
            ImageBox.Size = modifiedSize;
            ImageBox.Image = bm_dest;
        }
    }
}

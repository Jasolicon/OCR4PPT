using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.UI;
using Emgu.CV.Util;
namespace csWin2
{
    public partial class MouseRoi : Form
    {
        Point start = new Point();
        Point end = new Point();
        bool mouseDown = false;
        bool Drawn = false;
        Graphics g;
        Image<Bgr, byte> imgROI;
        Image<Bgr,byte> ImgOgn;

        Form1 f1;

        Bitmap bmp;
        public MouseRoi(string path)
        {
            InitializeComponent();
            pictureBox1.ImageLocation = path;
            ImgOgn = new Image<Bgr, byte>(path);
            
        }
        public MouseRoi(Bitmap b)
        {
            InitializeComponent();
            pictureBox1.Image = b;
            ImgOgn = new Image<Bgr, byte>(b);
        }

        private void MouseRoi_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnROIConfirm;
            pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(pictureBox1_MouseDown);
            pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(pictureBox1_MouseMove);
            pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(pictureBox1_MouseUp);
            f1 = (Form1)this.Owner;
            f1.isCut = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Image =ImgOgn.ToBitmap();
            start.X = e.X;
            start.Y = e.Y;
            end.X = e.X;
            end.Y = e.Y;
            g = this.pictureBox1.CreateGraphics();
            mouseDown = true;
            Drawn = false;
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            end.X = e.X;
            end.Y = e.Y;
            g.DrawRectangle(new Pen(Color.Blue, 2), new Rectangle(Math.Min(start.X, end.X), Math.Min(start.Y, end.Y), Math.Abs(end.X - start.X), Math.Abs(end.Y - start.Y)));
            mouseDown = false;
            Drawn = true;
            
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                end.X = e.X;
                end.Y = e.Y;
                //f1.rtbOCR.Text += (end.X + "/" + Math.Min(end.X, start.X) * pictureBox1.Image.Size.Width / pictureBox1.Size.Width);
            }
        }
        private void btnROIConfirm_Click(object sender, EventArgs e)
        {
            //if (f1.PicCut != null)
            //{
            //    f1.isCut = true;
            //    f1.PicCut = imgROI;
            //}
            //else
            //{
                if (Drawn)
                {
                    int ratioW = Math.Abs(end.X - start.X) * ImgOgn.Size.Width / pictureBox1.Size.Width;
                    int ratioH = Math.Abs(end.Y - start.Y) * ImgOgn.Size.Height / pictureBox1.Size.Height;
                    int locationX = Math.Min(start.X, end.X) * ImgOgn.Size.Width / pictureBox1.Size.Width;
                    int locationY = Math.Min(start.Y, end.Y) * ImgOgn.Size.Height / pictureBox1.Size.Height;
                    imgROI = new Image<Bgr, byte>(ratioW, ratioH);
                    Image<Bgr, byte> img = ImgOgn;//new Image<Bgr, byte>((Bitmap)pictureBox1.Image);
                    Rectangle rect = new Rectangle(locationX, locationY, ratioW, ratioH);
                    CvInvoke.cvSetImageROI(img, rect);
                    CvInvoke.cvCopy(img, imgROI, IntPtr.Zero);
                    pictureBox1.Image = imgROI.ToBitmap();
                    //f1.rtbOCR.Text += ("+"+img.ROI.X);
                    f1.isCut = true;
                    f1.PicCut = imgROI;
                }

            //}
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //if (btnPreView.Text == "预览")
            //{
                //btnPreView.Text = "恢复";
                pictureBox1.Image = ImgOgn.ToBitmap();
                imgROI = null;
            //}
            //else
            //{
            //    //btnPreView.Text = "预览";
            //    pictureBox1.Image = imgROI.ToBitmap();
            //}
        }

        private void btnPreView_Click(object sender, EventArgs e)
        {
            //if (btnPreView.Text == "预览")
            //{
            if (Drawn)
            {
                int ratioW = Math.Abs(end.X - start.X) * pictureBox1.Image.Size.Width / pictureBox1.Size.Width;
                int ratioH = Math.Abs(end.Y - start.Y) * pictureBox1.Image.Size.Height / pictureBox1.Size.Height;
                int locationX= Math.Min(start.X, end.X) * pictureBox1.Image.Size.Width / pictureBox1.Size.Width;
                int locationY= Math.Min(start.Y, end.Y) * pictureBox1.Image.Size.Height / pictureBox1.Size.Height;
                imgROI = new Image<Bgr, byte>(ratioW, ratioH);
                Image<Bgr, byte> img = new Image<Bgr, byte>((Bitmap)pictureBox1.Image);
                Rectangle rect = new Rectangle(locationX,locationY ,ratioW ,ratioH );
                CvInvoke.cvSetImageROI(img, rect);
                CvInvoke.cvCopy(img, imgROI, IntPtr.Zero);
                pictureBox1.Image = imgROI.ToBitmap();
                //f1.rtbOCR.Text += ("+"+img.ROI.X);
            }
            
            //else if (btnPreView.Text == "恢复")
            //{
            //    pictureBox1.Image = imgROI.ToBitmap();
            //}
        }
    }
}

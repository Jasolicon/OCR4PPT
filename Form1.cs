using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
using System.Drawing.Drawing2D;

namespace csWin2
{
    public partial class Form1 : Form
    {
        OpenFileDialog ofd;
        string[] path = new string[100];
        private int i = 0;
        public bool isCut = false;
        public Image<Bgr, byte> PicCut; 
        public string rtbString;
        Bitmap imageNow;
        public Form1()
        {
            InitializeComponent();

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            i = 0;
            ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.ShowDialog();
            path = ofd.FileNames;
            if (path.Length > 1)
                txtPath.Text = ofd.FileNames[0] + " ...";
            else if (path.Length == 1)
                txtPath.Text = ofd.FileNames[0];

            showImage();
        }
        private void showImage()
        {
            if (i < path.Length)
            {
                if (File.Exists(path[i]))
                {
                    pBxOgn.ImageLocation = path[i];
                    //pBxOgn.SizeMode = PictureBoxSizeMode.StretchImage;
                    pBxOgn.Show();

                    imageNow = new Bitmap(path[i]);
                }

                else
                {
                    MessageBox.Show("文件不存在！");
                }
            }
        }

        private void ocrGet()
        {
            if (pBxCanny.Image != null && i < path.Length)
                OCROperate();
            else
                MessageBox.Show("没有处理后的图片");
        }
        private void pBxCanny_Click(object sender, EventArgs e)
        {
            if (pBxCanny.Image != null && i < path.Length)
                OCROperate();
            else
                MessageBox.Show("没有处理后的图片");
        }

        
        private void pBxOgn_Click(object sender, EventArgs e)
        {
            imageNow = Rotate(imageNow, -90);
            pBxOgn.Image = imageNow;
            pBxOgn.Show();
        }
        
        public Bitmap Rotate(Bitmap b, int angle)
        {
            angle = angle % 360;

            //弧度转换
            double radian = angle * Math.PI / 180.0;
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);

            //原图的宽和高
            int w = b.Width;
            int h = b.Height;
            int W = (int)(Math.Max(Math.Abs(w * cos - h * sin), Math.Abs(w * cos + h * sin)));
            int H = (int)(Math.Max(Math.Abs(w * sin - h * cos), Math.Abs(w * sin + h * cos)));

            //目标位图
            Bitmap dsImage = new Bitmap(W, H);
            Graphics g = Graphics.FromImage(dsImage);

            g.InterpolationMode = InterpolationMode.Bilinear;

            g.SmoothingMode = SmoothingMode.HighQuality;

            //计算偏移量
            Point Offset = new Point((W - w) / 2, (H - h) / 2);

            //构造图像显示区域：让图像的中心与窗口的中心点一致
            Rectangle rect = new Rectangle(Offset.X, Offset.Y, w, h);
            Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(360 - angle);

            //恢复图像在水平和垂直方向的平移
            g.TranslateTransform(-center.X, -center.Y);
            g.DrawImage(b, rect);

            //重至绘图的所有变换
            g.ResetTransform();

            g.Save();
            g.Dispose();
            return dsImage;
        }
        private void pBxOgnOperation()
        {
            //    try
            //    {
            if (pBxOgn.Image != null && i < path.Length)
            {

                //pBxCanny.Image = null;
                Image<Bgr, byte> img;
                if (!isCut)
                    img = new Image<Bgr, byte>((Bitmap)pBxOgn.Image);
                else
                    img = PicCut;
                if (img == null)
                    MessageBox.Show("img==null");
                Image<Gray, byte> dst1 = new Image<Gray, byte>(img.Width, img.Height);
                UMat dst2 = new UMat();//Image<Gray, byte> dst2 = new Image<Gray, byte>(img.Width, img.Height);
                CvInvoke.CvtColor(img, dst1, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                
                dst1.SmoothGaussian(3);
                Image<Gray, byte> savedst1 = dst1.Copy();
                for (int x = 0; x < dst1.Rows; x++)
                {
                    //dst1.Data[x, dst1.Cols, 0] = 0;
                    //dst1.Data[x, 0, 0] = 0;
                    for (int y = 0; y < dst1.Cols; y++)
                    {
                        if (dst1.Data[x, y, 0] <= 50)
                        {
                            dst1.Data[x, y, 0] = 0;
                        }
                        else if (dst1.Data[x, y, 0] >= 200)
                        {
                            dst1.Data[x, y, 0] = 255;
                        }
                    }
                }
                dst1.SmoothGaussian(11);
                Image<Gray, byte> dst1th = dst1.CopyBlank();
                double cannyAccThresh = CvInvoke.Threshold(dst1, dst1th, 120, 255, ThresholdType.Otsu | ThresholdType.Binary);
                double cannyThresh = 0.1 * cannyAccThresh;

                for (int x = 0; x < dst1.Rows; x++)
                {
                    for (int y = 0; y < dst1.Cols; y++)
                    {
                        if (dst1th.Data[x, y, 0] == 0)
                        {
                            dst1.Data[x, y, 0] = 0;
                        }
                    }
                }

                //CvInvoke.Canny(dst1, dst2, 75, 50);
                Image<Gray, byte> dst4 = new Image<Gray, byte>(img.Width, img.Height);
                CvInvoke.AdaptiveThreshold(dst1th, dst4, 255, AdaptiveThresholdType.GaussianC, ThresholdType.Binary, 55, 10);
                dst4.Dilate(100);
                
                CvInvoke.Canny(dst4, dst2, cannyThresh, cannyAccThresh);
                pBxOgn.Image = dst4.ToBitmap();

                LineSegment2D[] lines = CvInvoke.HoughLinesP(dst2, 1, Math.PI / 90.0, 100, 1, 100);
                List<RotatedRect> boxlist = new List<RotatedRect>();
                using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
                {
                    CvInvoke.FindContours(dst2, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
                    int count = contours.Size;
                    for (int i = 0; i < count; i++)
                    {
                        using (VectorOfPoint contour = contours[i])
                        {
                            using (VectorOfPoint approxContour = new VectorOfPoint())
                            {
                                CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, false) * 0.05, false);
                                if (CvInvoke.ContourArea(approxContour, false) > img.Size.Height*img.Size.Width*0.001)
                                    if (approxContour.Size >= 4) //The contour has 4 vertices.
                                    {
                                        //#region determine if all the angles in the contour are within [80, 100] degree
                                        //bool isRectangle = true;
                                        //Point[] pts = approxContour.ToArray();
                                        //LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

                                        //for (int j = 0; j < edges.Length; j++)
                                        //{
                                        //    double angle = Math.Abs(
                                        //       edges[(j + 1) % edges.Length].GetExteriorAngleDegree(edges[j]));
                                        //    if (angle < 80 || angle > 100)
                                        //    {
                                        //        isRectangle = false;
                                        //        break;
                                        //    }
                                        //}
                                        //#endregion

                                        //if (isRectangle)
                                            boxlist.Add(CvInvoke.MinAreaRect(approxContour));

                                    }
                                    else
                                    {
                                        rtbOCR.Text += ("no"+i+" ");
                                    }
                            }
                        }
                    }
                }
                

                Image<Bgr, Byte> toDraw = dst4.CopyBlank().Convert<Bgr, Byte>().Not();
                //Image<Bgr, Byte> toDraw2 = dst1.Copy().Convert<Bgr,Byte>().Not();

                RotatedRect maxrect = new RotatedRect();
                double maxarea = 1000;
                Image<Gray, Byte> getLine = dst4.CopyBlank();
                foreach (RotatedRect rect in boxlist)
                {
                    if (rect.Size.Width * rect.Size.Height > maxarea)
                    {
                        maxarea = rect.Size.Width * rect.Size.Height;
                        maxrect = rect;
                    }
                    //toDraw.Draw(rect, new Bgr(Color.Red), 9);

                }
                //foreach (LineSegment2D line in lines)
                //{
                //    getLine.Draw(line, new Gray(255), 9);
                //    toDraw2.Draw(line, new Bgr(Color.Blue), 5);
                //}
                //getLine.Draw(maxrect, new Gray(255), 9);

                //pbx.Image = toDraw2.ToBitmap();

                //List<RotatedRect> boxlist2 = new List<RotatedRect>();
                //using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
                //{
                //    CvInvoke.FindContours(getLine, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
                //    int count = contours.Size;
                //    for (int i = 0; i < count; i++)
                //    {
                //        using (VectorOfPoint contour = contours[i])
                //        {
                //            using (VectorOfPoint approxContour = new VectorOfPoint())
                //            {
                //                CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, false) * 0.05, false);
                //                if (CvInvoke.ContourArea(approxContour, false) > img.Size.Height * img.Size.Width * 0.001)
                //                    if (approxContour.Size >= 4) //The contour has 4 vertices.
                //                    {
                //                        boxlist2.Add(CvInvoke.MinAreaRect(approxContour));
                //                    }
                //                    else
                //                    {
                //                        rtbOCR.Text += ("no" + i + " ");
                //                    }
                //            }
                //        }
                //    }
                //}
                //RotatedRect maxrect2 = new RotatedRect();
                //maxarea = 1000;//img.Height * img.Width * 0.5 * 0.5;
                //foreach (RotatedRect rect in boxlist2)
                //{
                //    if (rect.Size.Width * rect.Size.Height > maxarea&&rect.Size.Width * rect.Size.Height<=img.Width*img.Height*0.99)
                //    {
                //        maxarea = rect.Size.Width * rect.Size.Height;
                //        maxrect2 = rect;
                //    }
                //    toDraw.Draw(rect, new Bgr(Color.Yellow), 9);
                //}
                //PointF[] vertical = maxrect.GetVertices();
                //toDraw.Draw(maxrect, new Bgr(Color.Red), 4);
                //toDraw.Draw(maxrect2, new Bgr(Color.Black), 4);


                Image<Gray, byte> dst5 = new Image<Gray, byte>(img.Width, img.Height);
                CvInvoke.AdaptiveThreshold(savedst1, dst5, 255, AdaptiveThresholdType.GaussianC, ThresholdType.Binary,77,10);
                dst5.SmoothGaussian(31);
                dst5.Erode(5);
                
                pbx.Image = dst5.ToBitmap();
                //CvInvoke.AbsDiff(dst5, dst4, dst5);
                
                CvInvoke.cvSetImageROI(dst5, maxrect.MinAreaRect());
                
                Image<Gray, Byte> imgRoi = new Image<Gray, byte>(dst5.ROI.Width, dst5.ROI.Height);
                CvInvoke.cvCopy(dst5, imgRoi, IntPtr.Zero);
                pBxCanny.Image = imgRoi.ToBitmap();

                ocrGet();
            }
            else
                MessageBox.Show("没有原图片！");
        }

        private void rotateRectRotation(RotatedRect rr, ref Image<Gray, Byte> img)
        {
            Mat rotateM = new Mat();
            CvInvoke.GetRotationMatrix2D(rr.Center, 90+rr.Angle, 1, rotateM);
            CvInvoke.WarpAffine(img, img, rotateM, img.Size);
        }
        private void OCROperate()
        {

            string tessPath = @"C:/Users/李景阳/Desktop/WordBigBang - 副本/tessdata";//./tessdata/";//申明数据源路径，在运行目录下的tessdata
            Tesseract ocr = new Tesseract();
            ocr.Init(tessPath, "chi_sim", OcrEngineMode.TesseractOnly);
            ocr.SetVariable("tessedit_char_blacklist", "ˉ'′_一丨丿丶");
            ocr.Recognize(new Image<Bgr, byte>((Bitmap)pBxCanny.Image));
            rtbOCR.Text = ocr.GetText();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (txtPath != null && path != null)
            {
                if (i == 0)
                {
                    MessageBox.Show("已经是第一张!");
                }

                else
                {
                    i = i - 1;

                    showImage();
                    //showInfo(this.last);
                    //OCROperate();
                }
            }
            else
                MessageBox.Show("没有图片！");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (txtPath != null && path != null)
            {

                if (i >= path.Length - 1 && path.Length != 0)
                {
                    MessageBox.Show("已经是最后一张!");
                }
                else
                {
                    i = i + 1;

                    showImage();
                    //OCROperate();
                    //showInfo(next);
                }
            }
            else
                MessageBox.Show("没有图片！");
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            pBxOgnOperation();
            //operation();
        }
        private void operation()
        {
            //    try
            //    {
            if (pBxOgn.Image != null && i < path.Length)
            {

                //pBxCanny.Image = null;
                Image<Bgr, byte> img;
                if (!isCut)
                    img = new Image<Bgr, byte>((Bitmap)pBxOgn.Image);
                else
                    img = PicCut;
                if (img == null)
                    MessageBox.Show("img==null");
                Image<Gray, byte> dst1 = new Image<Gray, byte>(img.Width, img.Height);
                Image<Gray, byte> dst2 = new Image<Gray, byte>(img.Width, img.Height);
                CvInvoke.CvtColor(img, dst1, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                dst1.SmoothGaussian(3);
                Image<Gray, byte> dst1th = dst1.CopyBlank();
                double cannyAccThresh = CvInvoke.Threshold(dst1, dst1th, 0, 255, ThresholdType.Otsu | ThresholdType.Binary);
                double cannyThresh = 0.1 * cannyAccThresh;

                for (int x = 0; x < dst1.Rows; x++)
                {
                    for (int y = 0; y < dst1.Cols; y++)
                    {
                        if (dst1th.Data[x, y, 0] == 0)
                        {
                            dst1.Data[x, y, 0] = 0;
                        }
                    }
                }


                Image<Gray, byte> dst4 = new Image<Gray, byte>(img.Width, img.Height);
                CvInvoke.AdaptiveThreshold(dst1, dst4, 255, AdaptiveThresholdType.GaussianC, ThresholdType.Binary, 41, 10);
                dst4.Dilate(100);

                CvInvoke.Canny(dst4, dst2, 25, 75);
                //CvInvoke.Canny(dst4, dst2, cannyThresh, cannyAccThresh);
                pBxOgn.Image = dst4.ToBitmap();

                //dst4.Save(path[i]+".jpg");

                VectorOfVectorOfPoint con = new VectorOfVectorOfPoint();
                Image<Gray, byte> c = new Image<Gray, byte>(img.Width, img.Height);
                Image<Bgr, byte> dst3 = new Image<Bgr, byte>(img.Width, img.Height);
                CvInvoke.FindContours(dst2, con, c, RetrType.Ccomp, ChainApproxMethod.ChainApproxSimple);
                double areaM = dst2.Height * dst2.Width;
                double areaMin = 200;
                RotatedRect rRect = new RotatedRect();
                Image<Bgr, byte> d;
                int j = 0;
                for (int i = 0; i < con.Size; i++)
                {
                    double area = CvInvoke.ContourArea(con[i]);
                    if (area < areaM)
                    {
                        if (area > areaMin && !con[i].Equals(con[j]))
                        {
                            areaMin = area;
                            j = i;
                        }
                    }
                }
                double gotArea = CvInvoke.ContourArea(con[j]);
                if (gotArea > 4000)
                {
                    CvInvoke.CvtColor(dst4, dst3, ColorConversion.Gray2Bgr);
                    //CvInvoke.DrawContours(img, con, i, new MCvScalar(0, 0, 255, 255), 2);
                    rRect = CvInvoke.MinAreaRect(con[j]);
                    PointF[] pt = CvInvoke.BoxPoints(rRect);
                    CvInvoke.cvSetImageROI(dst3, rRect.MinAreaRect());
                    d = new Image<Bgr, byte>(dst3.ROI.Width, dst3.ROI.Height);
                    CvInvoke.cvCopy(dst3, d, IntPtr.Zero);
                    if (d == null)
                        MessageBox.Show("没有生成图片！");
                    else
                    {
                        pBxCanny.Image = d.ToBitmap();
                        rtbOCR.Text += ("\n!" + gotArea + "!\n");
                        isCut = false;
                    }
                }
                else
                    rtbOCR.Text += ("\n<" + gotArea + ">\n");


            }
            else
                MessageBox.Show("没有原图片！");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnConfirm;

        }

        private void btnMouseRoi_Click(object sender, EventArgs e)
        {
            if (pBxOgn.Image != null)
            {
                //MouseRoi mouseROI = new MouseRoi(path[i]);
                MouseRoi mouseROI = new MouseRoi(imageNow);
                mouseROI.ShowDialog(this);
                if (isCut)
                {
                    Image<Bgr, byte> img;
                    button1.Visible = true;
                    img = PicCut;
                    if (img == null)
                        MessageBox.Show("img==null");
                    Image<Gray, byte> dst1 = new Image<Gray, byte>(img.Width, img.Height);
                    Image<Gray, byte> dst2 = new Image<Gray, byte>(img.Width, img.Height);
                    CvInvoke.CvtColor(img, dst1, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                    CvInvoke.AdaptiveThreshold(dst1, dst2, 255, AdaptiveThresholdType.GaussianC, ThresholdType.Binary, 41, 10);
                    //dst1.Dilate(100);
                    //CvInvoke.Canny(dst1, dst2, 25, 75);

                    //Image<Bgr, byte> dst3 = new Image<Bgr, byte>(img.Width, img.Height);

                    
                        if (dst2 == null)
                            MessageBox.Show("没有生成图片！");
                        else
                        {
                            pBxCanny.Image = dst2.ToBitmap();
                            //rtbOCR.Text += ("\n!" + gotArea + "!\n");
                            isCut = false;
                        }
                    
                }
                else
                {
                    MessageBox.Show("没有截图！");
                }
            }
        }

        private void btnBigBang_Click(object sender, EventArgs e)
        {
            if (rtbOCR.Text == null)
                btnBigBang.Enabled = false;
            else
            {
                btnBigBang.Enabled = true;
                Bigbang bigbang = new Bigbang();
                rtbString = rtbOCR.Text;
                bigbang.ShowDialog(this);
            }
        }

        private void rtbOCR_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OCROperate();
        }
    }
}

    
     



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Filling
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }
        
        

        private bool chosing = false;
        private bool loaded = false;
        private Point chosenPoint;
        private Image selectedImage;
        private static Bitmap img;
        private bool pointIsChosen = false;

        

        private void select_image_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            ofd.ShowDialog();
            if (ofd.FileName == "" || !File.Exists(ofd.FileName))
                return;
            selectedImage = Image.FromFile(ofd.FileName);
            Bitmap bm = new Bitmap(selectedImage, new Size(1200, 675));
            selectedImage = bm;
            pictureBox1.Image = bm;
            loaded = true;

        }

        private void chose_start_dot_button_Click(object sender, EventArgs e)
        {
            if (!loaded)
                return;
            pictureBox1.Image = selectedImage;
            pictureBox1.Cursor = Cursors.Cross;
            chosing = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!chosing)
                return;
            MouseEventArgs mArgs = (MouseEventArgs)e;
            chosenPoint = new Point(mArgs.X, mArgs.Y);
            Bitmap bm = new Bitmap(selectedImage);

            DrawCross(bm, chosenPoint, 30);
            
            dot_status_label.Text = chosenPoint.ToString();
            pictureBox1.Image = bm;
            chosing = false;
            pictureBox1.Cursor = Cursors.Default;
            pointIsChosen = true;
        }

        private void DrawCross(Bitmap bm, Point center, int wight)
        {
            Graphics gr = Graphics.FromImage(bm);
            gr.DrawLine(Pens.Red, new Point(center.X + wight, center.Y), new Point(center.X - wight, center.Y));
            gr.DrawLine(Pens.Red, new Point(center.X, center.Y + wight), new Point(center.X, center.Y - wight));
            
        }

        private void select_border_button_Click(object sender, EventArgs e)
        {
            if (!pointIsChosen)
                return;
            BorderList = new List<BorderPointStruct>();
            BPend = 0;
            BPstart = 0;
            CurrentPixel = new BorderPointStruct();
                
            

            img = new Bitmap(selectedImage);
            BorderColor = Color.Black; //img.GetPixel(chosenPoint.X, chosenPoint.Y);
            if (!img.GetPixel(chosenPoint.X, chosenPoint.Y).ToArgb().Equals(Color.Black.ToArgb()))
                return;
            BorderFill(chosenPoint.X, chosenPoint.Y);
            pictureBox1.Image = img;

            //MessageBox.Show("Border selected", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }

        private static List<BorderPointStruct> BorderList;
        private static int BPstart;
        private static int BPend;
        private static Color BorderColor;
        private static int BLOCKED = 1;
        private static int UNBLOCKED = 2;


        private void BorderFill(int x, int y)
        {
            if (checkBox1.Checked)
            {
                TraceBorder(x, y);
                SortBP();
                ScanRegion(ref x, ref y);

                TraceBorder(x, y);
                SortBP();
                ScanRegion(ref x, ref y);

                FillRegion();
            }
            else
            {
                TraceBorder(x, y);
                foreach (var p in BorderList)
                {
                    img.SetPixel(p.x, p.y, Color.Red);
                    img.SetPixel(p.x, p.y + 1, Color.Red);
                    img.SetPixel(p.x, p.y - 1, Color.Red);
                    img.SetPixel(p.x + 1, p.y, Color.Red);
                    img.SetPixel(p.x - 1, p.y, Color.Red);
                }
                    
            }

            
            
        }

        private static void ScanRegion(ref int x, ref int y)
        {
            int i = BPstart;
            int xr;
            while (i < BPend - 1)
            {
                if (BorderList[i].flag == BLOCKED)
                    ++i;
                else
                if (BorderList[i].y != BorderList[i + 1].y)
                    ++i;
                else
                {
                    if (BorderList[i].x < BorderList[i+1].x-1)
                    {
                        xr = ScanRight(BorderList[i].x + 1, BorderList[i].y);
                        if (xr < BorderList[i + 1].x)
                        {
                            x = xr;
                            y = BorderList[i].y;
                            break;
                        }
                    }
                    i += 2;
                }
            }
            BPstart = i;
        }

        private static void SortBP()
        {
            BorderList.Sort(delegate (BorderPointStruct s1, BorderPointStruct s2) { return s1.Compare(s2); });
        }

        private  void FillRegion()
        {
            var DistinctBPList = BorderList.Distinct(new MyComparer()).ToList();
            int it = 0;
            for (int i = 0; i<DistinctBPList.Count - 1; )
            {
                if (DistinctBPList[i].flag == BLOCKED)
                    ++i;
                else
                if (DistinctBPList[i].y != DistinctBPList[i + 1].y)
                    ++i;
                else
                {
                    if (DistinctBPList[i].x < DistinctBPList[i+1].x - 1)
                    {
                        Graphics g = Graphics.FromImage(img);
                        g.DrawLine(Pens.Red, new Point(DistinctBPList[i].x + 1, DistinctBPList[i].y), new Point(DistinctBPList[i + 1].x - 1, DistinctBPList[i + 1].y));
                        i += 2;
                    }
                }
                ++it;
                if (it >= BPend*100)
                {
                    //MessageBox.Show("Some error", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
        }

        private static BorderPointStruct CurrentPixel;
        private static int CurrentDirection = 0;
        private static int PrevD = 0;
        private static int PrevV = 0;

        private static void TraceBorder(int StartX, int StartY)
        {
            bool NextFound;
            bool Done = false;
            CurrentPixel.x = StartX;
            CurrentPixel.y = StartY;

            CurrentDirection = 6;
            PrevD = 8;
            PrevV = 2;
            do
            {
                NextFound = FindNextPixel();
                Done = (CurrentPixel.x == StartX) && (CurrentPixel.y == StartY);
            }
            while (NextFound && !Done);
            if (!NextFound)
            {
                AppendBPList(StartX, StartY, UNBLOCKED);
                AppendBPList(StartX, StartY, UNBLOCKED);
            }
            else
                if ((PrevD <= 3) && (PrevD >= 1))
                    AppendBPList(StartX, StartY, UNBLOCKED);
            
        }

        private static bool FindNextPixel()
        {
            bool flag = false;
            for (int i = -1; i <= 5; ++i)
            {
                flag = FindBP((CurrentDirection + i) & 7);
                if (flag)
                {
                    CurrentDirection = (CurrentDirection + i) & 6;
                    break;
                }
            }
            return flag;
        }

        private static bool FindBP(int d)
        {
            int x, y;
            x = CurrentPixel.x;
            y = CurrentPixel.y;
            NextXY(ref x,ref y, d);
            if (img.GetPixel(x, y).ToArgb().Equals(BorderColor.ToArgb()))
            {
                AddBPList(d);
                CurrentPixel.x = x;
                CurrentPixel.y = y;
                return true;
            }
            else
                return false;
        }

        private static void NextXY(ref int x, ref int y, int direction)
        {
            switch(direction)
            {
                case 1:
                case 2:
                case 3:
                    y--;
                    break;
                case 5:
                case 6:
                case 7:
                    y++;
                    break;
            }
            switch (direction)
            {
                case 3:
                case 4:
                case 5:
                    x--;
                    break;
                case 1:
                case 0:
                case 7:
                    x++;
                    break;
            }
        }

        private static void AddBPList(int d)
        {
            if (d == PrevD)
                SameDirection();
            else
            {
                DifferentDirection(d);
                PrevV = d;
            }
            PrevD = d;
        }

        private static void SameDirection()
        {
            if (PrevD == 0)
                BorderList[BPend - 1].flag = BLOCKED;
            else
            if (PrevD != 4)
                AppendBPList(CurrentPixel.x, CurrentPixel.y, UNBLOCKED);
        }

        private static void DifferentDirection(int d)
        {
            if (PrevD == 4)
            {
                if (PrevD == 5)
                    BorderList[BPend - 1].flag = BLOCKED;
                
                AppendBPList(CurrentPixel.x, CurrentPixel.y, BLOCKED);
            }
            else
            if (PrevD == 0)
            {
                BorderList[BPend - 1].flag = BLOCKED;
                if (d == 7)
                    AppendBPList(CurrentPixel.x, CurrentPixel.y, BLOCKED);
                else
                    AppendBPList(CurrentPixel.x, CurrentPixel.y, UNBLOCKED);
            }
            else
            {
                AppendBPList(CurrentPixel.x, CurrentPixel.y, UNBLOCKED);
                if ((((d >= 1) && (d <= 3)) && ((PrevD >= 5) && (PrevD <= 7))) ||
                     (((d >= 5) && (d <= 7)) && ((PrevD >= 1) && (PrevD <= 3))))
                    AppendBPList(CurrentPixel.x, CurrentPixel.y, UNBLOCKED);
            }
        }

        private static void AppendBPList(int p, int q, int f)
        {
            BorderList.Add(new BorderPointStruct(p, q, f));
            ++BPend;
        }
        private static int Xmax = 1200;

        private static int ScanRight(int x, int y)
        {
            while (!img.GetPixel(x, y).ToArgb().Equals(BorderColor.ToArgb()))
            {
                ++x;
                if (x == Xmax)
                    break;
            }
            return (x);
        }

        

        
    }
}

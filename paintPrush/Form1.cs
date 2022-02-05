using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paintBrush
{
    
    public partial class Form1 : Form
    {
        private Point point1;
        private Point point2;
        Graphics Graphics;
        bool startPaint = false;
        Pen pen;
        bool Square = false;
        bool Rectangle = false;
        bool Circle = false;
        bool Line = false;
        Color color = Color.Black;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        { 
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            string coordinates = e.X + "," + e.Y;
            txtCoordinates.Text = coordinates;
        }
        private void btnPenColor_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            color = colorDialog2.Color;
            btnPenColor.BackColor = colorDialog2.Color;
        }
        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            pen = new Pen(color);
            Graphics = panel3.CreateGraphics();
            if (startPaint == false)
            {
                point1 = new Point(e.X, e.Y);
                startPaint = true;
            }
           else if (Square == true && startPaint == true)
           { 
                point2 = new Point(e.X, e.Y);
                int width = Math.Abs(point1.X - point2.X);
                int height = Math.Abs(point1.Y - point2.Y);

                Rectangle rectangle = new Rectangle(point1.X, point1.Y, width, width);
                Graphics.DrawRectangle(pen, rectangle);
                
                startPaint = false;
                Square = false;
           }
            else if (Rectangle == true && startPaint == true)
            {
               
                point2 = new Point(e.X, e.Y);
                int width = Math.Abs(point1.X - point2.X);
                int height = Math.Abs(point1.Y - point2.Y);

                Rectangle rectangle = new Rectangle(point1.X, point1.Y, width, height);
                Graphics.DrawRectangle(pen, rectangle);
               
                startPaint = false;
                Rectangle = false;
            }
            else if (Circle == true && startPaint == true)
            {
                
               
                point2 = new Point(e.X, e.Y);
                int width = Math.Abs(point1.X - point2.X);
                int height = Math.Abs(point1.Y - point2.Y);

                Rectangle rectangle = new Rectangle(point1.X, point1.Y, width, height);
                Graphics.DrawEllipse(pen,rectangle);
                startPaint = false;
                Circle = false;
            }
            else if(Line == true && startPaint == true)
            {
               
              
                point2 = new Point(e.X, e.Y);


                Graphics.DrawLine(pen, point1, point2);
                Graphics.DrawLine(pen, point2, point1);

                startPaint = false;
                Line = false;
            }
        }
       

        private void btnSquare_Click(object sender, EventArgs e)
        {
            Square = true;
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            Rectangle = true;
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            Circle = true;
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            Line = true;
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            panel3.BackColor = colorDialog1.Color;
            button1.BackColor = colorDialog1.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            this.Refresh();
            panel3.BackColor = Color.White;
            btnCanvesColor.BackColor = Color.White;
        }
    }
}

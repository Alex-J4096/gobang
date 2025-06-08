using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static gobang.Size;


namespace gobang
{
    class ChessBoard
    {

        public static void DrawBoard(Graphics g, PictureBox pic)
        {
            int i = 0;
            int Line= Board_width/Board_gap;    // 总共需要画几条线

            Image img = new Bitmap(Board_width, Board_height);
            g = Graphics.FromImage(img);
            g.Clear(Color.Lavender);

            Pen p = new Pen(Color.Black, 1.0f);
            g.DrawRectangle(p, 0, 0, Board_width-1, Board_height-1);
            // 画线
            for (i = 0; i < Line; i++)
            {
                g.DrawLine(p,0, i*Board_gap, Board_width, i * Board_gap);
                g.DrawLine(p, i * Board_gap, 0, i * Board_gap, Board_height);
            }
            pic.Image = img;
            g.Dispose();
        }

        // 直接从鼠标点击获得位置画棋子
        public static void DrawChess(bool type, PictureBox pic, Graphics g, MouseEventArgs e)
        {
            g=pic.CreateGraphics();
            Pen p_black = new Pen(Color.Black, 1);
            Pen p_white = new Pen(Color.White, 1);

            Brush bru_black = new SolidBrush(Color.Black);
            Brush bru_white = new SolidBrush(Color.White);

            int X = (int)((e.X + Board_gap / 2) / Board_gap) * Board_gap - Chess_radious / 2;
            int Y = (int)((e.Y + Board_gap / 2) / Board_gap) * Board_gap - Chess_radious / 2;

            if (type)
            {
                // White
                g.DrawEllipse(p_white,X,Y,Chess_radious,Chess_radious);
                g.FillEllipse(bru_white, X, Y, Chess_radious, Chess_radious);
            }
            else
            {
                // Black
                g.DrawEllipse(p_black, X, Y, Chess_radious, Chess_radious);
                g.FillEllipse(bru_black, X, Y, Chess_radious, Chess_radious);
            }
        }

        // 重载 根据坐标数组画出棋子
        public static void DrawChess(bool type, PictureBox pic, Graphics g, int x,int y)
        {
            g = pic.CreateGraphics();
            Pen p_black = new Pen(Color.Black, 1);
            Pen p_white = new Pen(Color.White, 1);

            Brush bru_black = new SolidBrush(Color.Black);
            Brush bru_white = new SolidBrush(Color.White);

            x = (int)(x * Board_gap - Chess_radious / 2);
            y = (int)(y * Board_gap - Chess_radious / 2);

            if (type)
            {
                // White
                g.DrawEllipse(p_white, x, y, Chess_radious, Chess_radious);
                g.FillEllipse(bru_white, x, y, Chess_radious, Chess_radious);
            }
            else
            {
                // Black
                g.DrawEllipse(p_black, x, y, Chess_radious, Chess_radious);
                g.FillEllipse(bru_black, x, y, Chess_radious, Chess_radious);
            }

        }
    }
}

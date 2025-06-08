using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using static gobang.Chess_Composition;
using static gobang.ChessBoard;
using static gobang.Size;

namespace gobang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chessBoard.Width = Board_width + 8;
            chessBoard.Height = Board_height + 8;
            DrawBoard(g, chessBoard);
            isStart = false;
        }

        Graphics g;
        static bool isStart;
        static bool botOn = false;
        static bool now; // 0 Black;1 White;
        Chess_Composition composition = new Chess_Composition();
        private void Initial()
        {
            int i = 0, j = 0;
            for (i = 0; i < 13; i++)
            {
                ChessRecord[i, j] = 0;
            }
            isStart = true;
            btn_Save.Enabled = true;
            btn_Load.Enabled = true;
            TxboxComposInfo.AppendText("对局开始\r\n");
        }

        private void chessBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (isStart)
            {
                // 获取位置
                int X = (int)(e.X + Board_gap / 2) / Board_gap;
                int Y = (int)(e.Y + Board_gap / 2) / Board_gap;

                if (ChessRecord[X, Y] != 0)
                {
                    return;
                }
                DrawChess(now, chessBoard, g, e);
                ChessRecord[X, Y] = now ? 1 : 2;


                // 判断平局
                if (IsFull() && !JudgeVictory(X, Y))
                {
                    TxboxComposInfo.AppendText("平局，游戏结束\r\n");
                }

                // 判断胜利
                if (JudgeVictory(X, Y))
                {
                    string Vic = now ? "白" : "黑";
                    TxboxComposInfo.AppendText(Vic + "胜利，游戏结束\r\n");
                    return;
                }
                TextBoxWrite(now, X, Y);

                now = !now;
                timer1.Enabled = false;
                if (botOn)
                {
                    Stopwatch sw = new Stopwatch(); // 计算AI决策时间
                    sw.Start();

                    ComplexAI();

                    sw.Stop();
                    TimeSpan ts2 = sw.Elapsed;
                    Time_white += Convert.ToInt32(ts2.TotalSeconds);
                    label2.Text = " AI已用时：" + timeTransfer(Time_white);
                    now = !now;
                    timer1.Enabled = true;
                }

            }
        }

        private bool IsFull()
        {
            bool full = true;
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    if (ChessRecord[i, j] == 0)
                        full = false;
                }
            }
            return full;
        }

        private bool JudgeVictory(int x, int y)
        {
            if (HorVic(x, y))
                return true;
            if (VerVic(x, y))
                return true;
            if (Vic45(x, y))
                return true;
            else
                return false;
        }

        // 斜线判断
        private bool Vic45(int x, int y)
        {
            int b1 = (x - 4) > 0 ? x - 4 : 0;
            int b2 = (y - 4) > 0 ? y - 4 : 0;
            int val = ChessRecord[x, y];
            for (int i = b1; i < 12; i++)
            {
                for (int j = b2; j < 12; j++)
                {
                    if (ChessRecord[i, j] == val && ChessRecord[i + 1, j + 1] == val &&
                        ChessRecord[i + 2, j + 2] == val && ChessRecord[i + 3, j + 3] == val
                        && ChessRecord[i + 4, j + 4] == val)
                    {
                        return true;
                    }

                }
            }
            if (b1 > 4 && b2 > 4)
            {
                for (int i = b1; i < 12; i++)
                {
                    for (int j = b2; j < 12; j++)
                    {
                        if (ChessRecord[i, j] == val && ChessRecord[i - 1, j + 1] == val &&
                        ChessRecord[i - 2, j + 2] == val && ChessRecord[i - 3, j + 3] == val
                        && ChessRecord[i - 4, j + 4] == val)
                        {
                            return true;
                        }

                    }
                }
            }
            return false;
        }

        // 纵向判断
        private bool VerVic(int x, int y)
        {
            int buttom = (y - 4) > 0 ? y - 4 : 0;
            int val = ChessRecord[x, y];
            for (int i = buttom; i < 12; i++)
            {
                if (ChessRecord[x, i] == val && ChessRecord[x, i + 1] == val &&
                    ChessRecord[x, i + 2] == val && ChessRecord[x, i + 3] == val
                    && ChessRecord[x, i + 4] == val)
                {
                    return true;
                }

            }
            return false;
        }

        // 横向判断
        private bool HorVic(int x, int y)
        {
            int left = (x - 4) > 0 ? x - 4 : 0;
            int val = ChessRecord[x, y];
            for (int i = left; i < 12; i++)
            {
                if (ChessRecord[i, y] == val && ChessRecord[i + 1, y] == val &&
                    ChessRecord[i + 2, y] == val && ChessRecord[i + 3, y] == val
                    && ChessRecord[i + 4, y] == val)
                {
                    return true;
                }

            }
            return false;
        }

        private void EasyAI(int x, int y)
        {
            // List 1,2 代表x,y
            List<int> candidate_x = new List<int>();
            List<int> candidate_y = new List<int>();
            int i, j;
            for (i = x - 1; i <= x + 1; i++)
            {
                for (j = y - 1; j <= y + 1; j++)
                {
                    if (i < 0 || i > 12 || j < 0 || j > 12)
                    {
                        continue;
                    }
                    else if (i == x && j == y)
                    {
                        continue;
                    }
                    candidate_x.Add(i);
                    candidate_y.Add(j);
                }
            }
            Random ran = new Random();
            int result = ran.Next(candidate_x.Count);
            while (ChessRecord[candidate_x[result], candidate_y[result]] == 0)
            {
                result = ran.Next(candidate_x.Count);
                ChessRecord[candidate_x[result], candidate_y[result]] = now ? 1 : 2;
                DrawChess(now, chessBoard, g, candidate_x[result], candidate_y[result]);
                TxboxComposInfo.AppendText("白棋(AI)落子(" + candidate_x[result] + "," + candidate_y[result] + ")\r\n");
                return;
            }

            ChessRecord[candidate_x[result], candidate_y[result]] = now ? 1 : 2;
            DrawChess(now, chessBoard, g, candidate_x[result], candidate_y[result]);
            TxboxComposInfo.AppendText("白棋(AI)落子(" + candidate_x[result] + "," + candidate_y[result] + ")\r\n");
            return;
        }

        private void ComplexAI()
        {
            
            ComplexAI AI = new ComplexAI(ChessRecord);
            AI.putChess();
            ChessRecord[AI.ChooseX, AI.ChooseY] = now ? 1 : 2;
            DrawChess(now, chessBoard, g, AI.ChooseX, AI.ChooseY);
            TxboxComposInfo.AppendText("白棋(AI)落子(" + AI.ChooseX + "," + AI.ChooseY + ")\r\n");
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            Initial();
            timer1.Enabled = true;
        }

        // 保存-
        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "保存";
            saveFileDialog.Filter = "所有文件(*json*)|*.json";

            JavaScriptSerializer jss = new JavaScriptSerializer();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;

                string json_compos = jss.Serialize(ChessRecord);
                File.WriteAllText(path, json_compos);
            }
        }

        // 读取
        private void btn_Load_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "请选择文件";
            openFileDialog.Filter = "所有文件(*json*)|*.json";

            JavaScriptSerializer jss = new JavaScriptSerializer();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                int[,] loadBoard = jss.Deserialize(file, typeof(int[,])) as int[,];
                int i = 0, j = 0;
                for (i = 0; i < 13; i++)
                {
                    for (j = 0; j < 13; j++)
                    {
                        DrawBoard(g, chessBoard);
                        bool res = (loadBoard[i, j] == 0) ? false : true;
                        DrawChess(res, chessBoard, g, i, j);
                    }
                }
            }
            MessageBox.Show("读取成功");
        }

        private void TextBoxWrite(bool now, int x, int y)
        {
            if (now)
            {
                TxboxComposInfo.AppendText("白子落子(" + x + "," + y + ")\r\n");
            }
            else
            {
                TxboxComposInfo.AppendText("黑子落子(" + x + "," + y + ")\r\n");
            }
        }

        private void 人机对战ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            botOn = true;
            Initial();
        }

        private void 人人对战ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            botOn = false;
            Initial();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time_black++;
            label1.Text = " 玩家已用时：" + timeTransfer(Time_black);
        }

        private string timeTransfer(int time)
        {
            float m = time/60;
            float s = time % 60;
            string t = Convert.ToInt32(m).ToString("00")
                + ":" + Convert.ToInt32(s).ToString("00");
            return t;
        }
    }   
}

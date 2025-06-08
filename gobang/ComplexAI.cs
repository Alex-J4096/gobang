using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static gobang.Chess_Composition;
namespace gobang
{
    class ComplexAI
    {
        int first = 2; // 本程序默认后手,执白棋
        int chooseX;    // AI下棋的位置的X坐标
        int chooseY;    // AI下棋的位置的Y坐标
        int[,] AIBoard; // 拷贝一个棋盘用来预估 
        int ROW;
        int COL;

        public int ChooseX { get => chooseX;  }
        public int ChooseY { get => chooseY;  }

        public ComplexAI(int[,] board)
        {
            AIBoard = ChessRecord;
            ROW = AIBoard.GetLength(0);
            COL = AIBoard.GetLength(1);
        }

        // 放置棋子
        public void putChess()
        {
            // Console.WriteLine(ChessRecord.GetLength(0) + "," + ChessRecord.GetLength(1));
           choose();
        }

        void choose()
        {
            int MAX = -1000000;  // 极大值先设置为最小
            Random rm = new Random();
            int i = 0, j = 0;
            for (i = 0; i < ROW; i++)
            {
                for (j = 0; j < COL; j++)
                {
                    if (AIBoard[i, j] == 0 && isAround(AIBoard, i, j))
                    {
                        // 如果该处没有棋子，并且周围有棋子 
                        AIBoard[i, j] = first;  // 放置棋子预测
                        if (getGoalOfChess(AIBoard, first) >= 100000)
                        {
                            MAX = 1000000 - rm.Next(0, 100);
                            chooseX = i;
                            chooseY = j;
                            AIBoard[i, j] = 0;  // 取消刚刚防止的棋子
                        }

                        int MIN = 1000000;  // 极小值先设为最小
                        bool cut1 = false;

                        int p = 0, q = 0;
                        for (p = 0; p < ROW; p++)
                        {
                            for (q = 0; q < COL; q++)
                            {
                                if (AIBoard[p, q] == 0 && isAround(AIBoard, p, q))
                                {
                                    AIBoard[i, j] = first - 1;  // 放置一个棋子 
                                    if (getGoalOfChess(AIBoard, first - 1) >= 100000 && getGoalOfChess(AIBoard, first - 1) < 10000)
                                    {
                                        // 如果对手赢，将极小值设为最小
                                        MIN = -1000000 + rm.Next(0, 100);
                                        cut1 = true;    // 跳出本次预测
                                        AIBoard[i, j] = 0;
                                        break;
                                    }

                                    int MAX_1 = -1000000;
                                    bool cut2 = false;

                                    int m = 0, n = 0;
                                    // 另起一层极大搜索
                                    for (m = 0; m < ROW; m++)
                                    {
                                        for (n = 0; n < COL; n++)
                                        {
                                            if (AIBoard[m, n] == 0 && isAround(AIBoard, m, n))
                                            {
                                                AIBoard[m, n] = first;
                                                if (MAX_1 < getGoalOfChess(AIBoard, first) - getGoalOfChess(AIBoard, first - 1))
                                                {
                                                    // 如果极大值小于启发式函数，就重新赋值 
                                                    MAX_1 = getGoalOfChess(AIBoard, first) - getGoalOfChess(AIBoard, first - 1);
                                                }
                                                AIBoard[m, n] = 0;  // 恢复棋盘
                                            }
                                            if (MIN < MAX_1)
                                            {
                                                cut2 = true;
                                                break;
                                            }
                                        }
                                        if (cut2)
                                        {
                                            break;
                                        }
                                    }
                                    if (MIN > MAX_1)
                                    {
                                        // 如果极小值大于倒推值，重新赋值 
                                        MIN = MAX_1;
                                    }
                                    AIBoard[p, q] = 0;  // 恢复棋盘
                                }
                                if (MAX > MIN)
                                {
                                    cut1 = true;
                                    break;
                                }
                            }
                            if (cut1) break;
                        }
                        if (MAX < MIN)
                        {
                            // 如果极大值小于倒推值 
                            MAX = MIN;      // 重新赋值 
                            chooseX = i;   // 改变放置的x，y坐标 
                            chooseY = j;
                        }
                        AIBoard[i, j] = 0;
                    }
                }
            }
        }

        int getGoalOfPoint(int[] a, int color)
        {
            if (a[0] == color && a[1] == color && a[2] == color && a[3] == color && a[4] == color) return 100000;  //五子 
            if (a[0] == 0 && a[1] == color && a[2] == color && a[3] == color && a[4] == color && a[5] == 0) return 10000;  //活四子 
            if (a[0] == 0 && a[1] == color && a[2] == color && a[3] == color && a[4] == 0) return 1000;             //活三子 
            if ((a[0] == -1 * color && a[1] == color && a[2] == color && a[3] == color && a[4] == color && a[5] == 0) ||
                (a[0] == 0 && a[1] == color && a[2] == color && a[3] == color && a[4] == color && a[5] == -1 * color)) return 1000; //死四子 
            if (a[0] == 0 && a[1] == color && a[2] == color && a[3] == 0) return 100;   //活二子 
            if ((a[0] == -1 * color && a[1] == color && a[2] == color && a[3] == color && a[4] == 0) ||
                (a[0] == 0 && a[1] == color && a[2] == color && a[3] == color && a[4] == -1 * color)) return 100;   //死三子 
            if (a[0] == 0 && a[1] == color && a[2] == 0) return 10; //活一子 
            if ((a[0] == -1 * color && a[1] == color && a[2] == color && a[3] == 0) ||
                (a[0] == 0 && a[1] == color && a[2] == color && a[3] == -1 * color)) return 10; //死二子 
            return 0;
        }

        int getGoalOfChess(int[,] board, int color)
        {
            int sumGoal = 0;

            int i, j;
            for (i = 0; i < ROW; i++)
            {
                for (j = 0; j < COL; j++)
                {
                    int[] line = new int[6];    // 记录该点出发的线，一个六个 
                    line[0] = board[i, j];  // 第一个当前的的点
                    // 朝四个方向变化的x，y坐标	
                    int x1 = i, y1 = j;
                    int x2 = i, y2 = j;
                    int x3 = i, y3 = j;
                    int x4 = i, y4 = j;

                    for (int it = 1; it < 6; it++)
                    {
                        y1--;
                        if (y1 >= 0) line[it] = board[i, y1];  // 如果有棋子，就赋值 
                        else line[it] = -2;     // 没有就赋一个无效值，下同 
                    }

                    sumGoal += getGoalOfPoint(line, color);		// 计算这一点的分值后相加 

                    for (int it = 1; it < 6; it++)
                    {
                        x2++; y2--;
                        if (y2 >= 0 && x2 < 13) line[it] = board[x2, y2];
                        else line[it] = -2;
                    }

                    sumGoal += getGoalOfPoint(line, color);

                    for (int it = 1; it < 6; it++)
                    {
                        x3++;
                        if (x3 < 13) line[it] = board[x3, y3];
                        else line[it] = -2;
                    }

                    sumGoal += getGoalOfPoint(line, color);

                    for (int it = 1; it < 6; it++)
                    {
                        x4++; y4++;
                        if (x4 < 13 && y4 < 13) line[it] = board[x4, y4];
                        else line[it] = -2;
                    }
                    sumGoal += getGoalOfPoint(line, color);
                }
            }
            return sumGoal;
        }

        bool isAround(int[,] board, int x, int y)
        {
            int i = 0, j = 0;
            // 判断周围8个点有没有棋子，有任意一个为真，都没有为假
            if (j - 1 >= 0 && board[i, j - 1] != 0) return true;

            if (j - 1 >= 0 && i + 1 < 13 && board[i + 1, j - 1] != 0) return true;

            if (i + 1 < 13 && board[i + 1, j] != 0) return true;

            if (j + 1 < 13 && i + 1 < 13 && board[i + 1, j + 1] != 0) return true;

            if (j + 1 < 13 && board[i, j + 1] != 0) return true;

            if (i - 1 >= 0 && j + 1 < 13 && board[i - 1, j + 1] != 0) return true;

            if (i - 1 >= 0 && board[i - 1, j] != 0) return true;

            if (i - 1 >= 0 && j - 1 >= 0 && board[i - 1, j - 1] != 0) return true;

            return false;

            for (i = x - 1; i <= x + 1; i++)
            {
                for (j = y - 1; j <= y + 1; j++)
                {
                    if (i < 0 || i > 13 || j < 0 || j > 13)
                    {
                        continue;
                    }
                    else if (i == x && j == y)
                    {
                        continue;
                    }
                    if (ChessRecord[x, y] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}

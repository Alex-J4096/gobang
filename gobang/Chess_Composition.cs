using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gobang
{
    class Chess_Composition
    {
        // 时间
        static int time_black;
        static int time_white;

        // 棋谱,1黑，2白
        static int[,] chessRecord = new int[13, 13];

        public static int Time_black { get => time_black; set => time_black = value; }
        public static int Time_white { get => time_white; set => time_white = value; }
        public static int[,] ChessRecord { get => chessRecord; set => chessRecord = value; }
    }
}

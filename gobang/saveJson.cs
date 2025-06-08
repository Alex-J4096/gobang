using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gobang
{
    class saveJson
    {
        // 时间剩余
        public static int save_time_black;
        public static int save_time_white;

        // 棋谱,1黑，2白
        public static int[,] saveBoard = new int[13, 13];
    }
}

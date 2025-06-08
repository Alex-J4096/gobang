using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gobang
{
    class Size
    {
        // 棋盘大小
        static int board_width = 300;
        static int board_height = 300;

        // 棋子大小
        static int chess_radious = 16;

        // 棋盘间隔
        static int board_gap = 25;
        public static int Board_width { get => board_width;  }
        public static int Board_height { get => board_height;  }
        public static int Chess_radious { get => chess_radious;  }
        public static int Board_gap { get => board_gap;  }
    }
}

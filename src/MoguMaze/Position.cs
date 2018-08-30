using System;
using System.Collections.Generic;
using System.Text;

namespace MoguMaze
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
            Z = 0;
        }

        public Position(int x, int y, int z) : this(x, y)
        {
            Z = z;
        }
    }
}

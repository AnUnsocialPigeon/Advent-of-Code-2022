using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Code.Day9 {
    internal class Pos {
        public Pos(int x, int y) {
            X = x;
            Y = y;
        }
        public Pos(Pos p) {
            X = p.X;
            Y = p.Y;
        }

        public int X;
        public int Y;
    }
}

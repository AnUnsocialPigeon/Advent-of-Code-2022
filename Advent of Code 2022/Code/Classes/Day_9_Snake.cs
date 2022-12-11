using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Code.Day9 {
    internal class Snake {
        public Pos Start { get; private set; }
        public Pos Head { get; private set; }
        public Pos Tail { get; private set; }

        public Snake() {
            Start = new(0, 0);
            Head = new(0, 0);
            Tail = new(0, 0);
        }

        public void MoveHead(Pos Offset) {
            Head.X += Offset.X;
            Head.Y += Offset.Y;

            UpdateTail();
        }

        private void UpdateTail() {
            // No need to move
            if (Math.Abs(Head.X - Tail.X) < 2 && Math.Abs(Head.Y - Tail.Y) < 2) return;

            // Need to move the tail
            // Need the last bit for the floor logic.
            Tail.X += (int)Math.Ceiling(Math.Abs((Head.X - Tail.X)) / 2f) * (Head.X - Tail.X < 0 ? -1 : 1); 
            Tail.Y += (int)Math.Ceiling(Math.Abs((Head.Y - Tail.Y)) / 2f) * (Head.Y - Tail.Y < 0 ? -1 : 1);
        }
    }
}

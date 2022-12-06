using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Code {
    internal class Day_6 : AdventOfCode {
        public Day_6(string[] input) : base(input) { }

        public override string Main() => ($"Part 1:\nFirst index [4]: {GetFirstAllUnique(4)}\nPart 2:\nFirst index [14]: {GetFirstAllUnique(14)}");

        private int GetFirstAllUnique(int subLength) {
            for (int i = 0; i < Input[0].Length - subLength; i++) {
                string sub = Input[0].Substring(i, subLength);
                if (!sub.Any(x => sub.Where(y => y == x).Count() > 1)) return i + subLength;
            }
            return -1;
        }
    }
}

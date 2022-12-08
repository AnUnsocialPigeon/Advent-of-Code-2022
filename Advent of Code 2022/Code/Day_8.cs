using Advent_of_Code_2022.Code.Day8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Code {
    internal class Day_8 : AdventOfCode {
        public Day_8(string[] input) : base(input) { }

        Forest Forest;
        public override string Main() {
            Forest = new(Input);
            int total = 0;
            int maxScenicScore = 0;
            for (int y = 0; y < Input.Length; y++) {
                for (int x = 0; x < Input[0].Length; x++) {
                    total += Forest.IsTreeVisable(x, y) ? 1 : 0;
                    maxScenicScore = Math.Max(Forest.ScenicScore(x, y), maxScenicScore);
                }
            }

            return $"\nPart 1:\nTrees Visable = {total}\n\nPart 2:\nMax Senic Score = {maxScenicScore}";
        }
    }
}

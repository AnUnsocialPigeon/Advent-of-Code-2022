using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Code {
    internal class Day_3 : AdventOfCode {
        public Day_3(string[] input) : base(input) { }

        private char[] Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".Select(x => x).ToArray();

        public override string Main() {
            int total1 = 0;
            // Part 1
            foreach (string bag in Input) {
                string pocket1 = bag.Substring(0, bag.Length / 2);
                string pocket2 = bag.Substring(bag.Length / 2);

                char same = pocket1.Where(x => pocket2.Contains(x)).ToArray()[0];

                total1 += Alphabet.ToList().FindIndex(x => same.Equals(x)) + 1;
            }

            int total2 = 0;
            // Part 2
            for (int elfGroupStartIndex = 0; elfGroupStartIndex < Input.Length; elfGroupStartIndex += 3) {
                string bag1 = Input[elfGroupStartIndex];
                string bag2 = Input[elfGroupStartIndex + 1];
                string bag3 = Input[elfGroupStartIndex + 2];

                char same = bag1.Where(x => bag2.Contains(x) && bag3.Contains(x)).ToArray()[0];

                total2 += Alphabet.ToList().FindIndex(x => same.Equals(x)) + 1;
            }

            return $"Part 1:\nTotal: {total1}\nPart 2:\nTotal: {total2}";
        }
    }
}

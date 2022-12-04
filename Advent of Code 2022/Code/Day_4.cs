using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Code {
    internal class Day_4 : AdventOfCode {
        public Day_4(string[] input) : base(input) { }

        public override string Main() {
            int total1 = 0;
            int total2 = 0;
            foreach (string pairing in Input) {
                int[] elf1 = pairing.Split(',')[0].Split('-').Select(x => int.Parse(x)).ToArray();
                int[] elf2 = pairing.Split(',')[1].Split('-').Select(x => int.Parse(x)).ToArray();

                // Part 1
                if (NXOR_SignBit(elf1[0] - elf2[0], elf1[1] - elf2[1]))
                    total1++;

                // Part 2 - probably a way to do it mathematically but oh well
                for (int i = elf1[0]; i <= elf1[1]; i++) {
                    if (elf2[0] <= i && elf2[1] >= i) {
                        total2++;
                        break;
                    }
                }
            }

            return $"Part 1\nTotal Pairs = {total1}\n\nPart 2\nTotal overlap = {total2}";
        }

        public bool NXOR_SignBit(int i1, int i2) => (i1 >= 0 && i2 <= 0) || (i1 <= 0 && i2 >= 0);
    }
}

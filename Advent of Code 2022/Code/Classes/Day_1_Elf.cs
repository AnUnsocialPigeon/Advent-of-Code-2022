using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Code.Day1 {
    internal class Elf {
        public Elf(int total, int number) { TotalCalories = total; Number = number; }
        public int TotalCalories = 0;
        public int Number = -1;
    }
}

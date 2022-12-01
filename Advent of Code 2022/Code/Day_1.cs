using Advent_of_Code_2022.Code.Day1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Code {
    internal class Day_1 : AdventOfCode {
        public Day_1(string[] input) : base(input) { }

        private List<Elf> Elves = new();

        /// <summary>
        /// Task: Find the elf with the most calories. Split by blank lines. 
        /// </summary>
        /// <returns>Amount of calories</returns>
        public override string Main() {
            int total = 0;
            int current = 1;
            foreach (string s in Input) {
                if (s == "") {
                    Elves.Add(new(total, current));
                    total = 0;
                    current++;
                    continue;
                }
                total += int.Parse(s);
            }

            Elves = Elves.OrderByDescending(x => x.TotalCalories).ToList();

            return $"Most Calories: {Elves[0].TotalCalories} (By Elf #{Elves[0].Number})\nTop 3: {Elves.Take(3).Sum(x => x.TotalCalories)}";
        }
    }
}

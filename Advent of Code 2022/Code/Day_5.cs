using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Code {
    internal class Day_5 : AdventOfCode {
        public Day_5(string[] input) : base(input) { }

        public List<Stack<char>>[] Crates = new List<Stack<char>>[2] { new(), new() };

        public override string Main() {
            int commandSplit = Input.ToList().IndexOf("");
            if (commandSplit == -1) return "Could not find command split";

            // Split the input into its 2 components
            string[] crateBlob = Input.Take(commandSplit - 1).ToArray();
            string[] commands = Input.Skip(commandSplit + 1).ToArray();

            // For ease, I assume there are 9 docks
            for (int i = 0; i < 9; i++) {
                Crates[0].Add(new());
                Crates[1].Add(new());
            }

            // Setting up the Crate Stack. Reverses the crates to add them easily.
            foreach (string s in crateBlob.Reverse()) {
                int index = 0;
                for (int i = 1; i < s.Length; i += 4) {
                    if (s[i] != ' ') {
                        Crates[0][index].Push(s[i]);
                        Crates[1][index].Push(s[i]);
                    }
                    index++;
                }
            }

            foreach (string command in commands) {
                string[] parts = command.Split(' ');
                int count = int.Parse(parts[1]);
                int from = int.Parse(parts[3]) - 1; // -1 to turn into index
                int to = int.Parse(parts[5]) - 1;   // ^^^^^^^^^^^^^^^^^^^^^ 

                // Part 1
                Move_Recursive(count, from, to);

                // Part 2
                Move_Multiple(count, from, to);
            }

            return $"Part 1:\nTop values: {string.Join("", Crates[0].Select(x => x.Peek().ToString()))}\n\n" +
                $"Part 2:\nTop values: {string.Join("", Crates[1].Select(x => x.Peek().ToString()))}";
        }

        /// <summary>
        /// Recursively moves a crate at a time, for part 1
        /// </summary>
        /// <param name="count">How many</param>
        /// <param name="from">From index</param>
        /// <param name="to">To index</param>
        public void Move_Recursive(int count, int from, int to) {
            for (int i = 0; i < count; i++)
                Crates[0][to].Push(Crates[0][from].Pop());
        }

        /// <summary>
        /// Moves a blob at a time
        /// </summary>
        /// <param name="count">How many</param>
        /// <param name="from">From index</param>
        /// <param name="to">To index</param>
        public void Move_Multiple(int count, int from, int to) {
            Stack<char> Buffer = new();
            // Push to buffer
            for (int i = 0; i < count; i++)
                Buffer.Push(Crates[1][from].Pop());

            // Pop from buffer
            for (int i = 0; i < count; i++) {
                Crates[1][to].Push(Buffer.Pop());
            }
        }
    }
}

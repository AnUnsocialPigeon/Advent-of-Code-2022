using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Code {
    internal class Day_10 : AdventOfCode {
        public Day_10(string[] input) : base(input) { }
        private int X = 1;
        private int SignalStrenght = 0;
        private int Cycles {
            get => _Cycles;
            set {
                // Part 2 -> Done before _Cycle re-assign
                Console.Write((_Cycles % 40 == 0 ? "\n" : "") + (X == _Cycles % 40 || X - 1 == _Cycles % 40 || X + 1 == _Cycles % 40 ? "#" : " "));

                _Cycles = value;
                // Part 1
                if (_Cycles % 40 == 20)
                    SignalStrenght += _Cycles * X;
            }
        }
        private int _Cycles { get; set; }

        public override string Main() {
            Console.Write("Part 2: ");
            foreach (string command in Input) {
                Cycles++;
                if (command == "noop") continue;

                Cycles++;
                X += int.Parse(command.Split(' ')[1]);
            }


            return $"\n\nPart 1:\nSignal Strenght: {SignalStrenght}\n\n";
        }
    }
}

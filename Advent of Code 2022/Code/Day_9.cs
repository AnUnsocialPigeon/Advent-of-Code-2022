using Advent_of_Code_2022.Code.Day9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Code {
    internal class Day_9 : AdventOfCode {
        public Day_9(string[] input) : base(input) { }

        private Snake Snake = new();
        private List<Snake> Snake10 = new();
        private Dictionary<char, Pos> ChangeInDirection = new() {
            {'U', new(0, 1) },
            {'D', new(0, -1) },
            {'R', new(1, 0) },
            {'L', new(-1, 0) }
        };
        private List<Pos> TailPositions = new();
        private List<Pos> TailPositions10 = new();



        public override string Main() {
            // Set up part 2 (10 snakes)
            for (int i = 0; i < 9; i++) Snake10.Add(new());

            foreach (string[] command in Input.Select(x => x.Split(' '))) {
                for (int i = 0; i < int.Parse(command[1]); i++) {
                    MoveHead(command[0][0]);
                }
            }

            return $"Part 1:\nTotal = {TailPositions.Count}\n\nPart 2:\nTotal = {TailPositions10.Count}";
        }

        private void MoveHead(char Direction) {
            // Part 1: Movement
            Snake.MoveHead(ChangeInDirection[Direction]);

            // Part 1: Add tail if not been?
            // .Contains doesn't seem to work...?
            if (!TailPositions.Where(x => x.X == Snake.Tail.X && x.Y == Snake.Tail.Y).Any())
                TailPositions.Add(new(Snake.Tail));


            // Part 2: Movement
            Snake10[0].MoveHead(ChangeInDirection[Direction]);
            for (int i = 1; i < Snake10.Count; i++) {
                Pos offset = new(Snake10[i - 1].Tail.X - Snake10[i].Head.X, Snake10[i - 1].Tail.Y - Snake10[i].Head.Y);
                Snake10[i].MoveHead(offset);
            }

            // Part 2: Add tail if not been
            if (!TailPositions10.Where(x => x.X == Snake10.Last().Tail.X && x.Y == Snake10.Last().Tail.Y).Any()) 
                TailPositions10.Add(new(Snake10.Last().Tail));
            
        }
    }
}

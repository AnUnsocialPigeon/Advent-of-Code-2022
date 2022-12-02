using Advent_of_Code_2022.Code.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Code {
    internal class Day_2 : AdventOfCode {
        public Day_2(string[] input) : base(input) { }

        public override string Main() {
            // Part 1
            int score1 = 0;
            int score2 = 0;
            foreach (string round in Input) {
                score1 += GetScore1(round.Split(' ')[0][0], round.Split(' ')[1][0]);
                score2 += GetScore2(round.Split(' ')[0][0], round.Split(' ')[1][0]);
            }

            return $"Part 1:\nTotal Score: {score1}\nPart 2:\nTotal Score: {score2}";
        }

        private int GetScore2(char Opponent, char Action) {
            int opponentIndex = new List<int> { 'A', 'B', 'C' }.FindIndex(x => x.Equals(Opponent));
            List<char> ActionToUser = Action == 'X' ? new() { 'Z', 'X', 'Y' } : Action == 'Y' ? new() { 'X', 'Y', 'Z' } : new() { 'Y', 'Z', 'X' };

            return GetScore1(Opponent, ActionToUser[opponentIndex]);
        }

        private int GetScore1(char Opponent, char Player) {
            // Get initial score for playing the hand
            int playerIndex = new List<int> { 'X', 'Y', 'Z' }.FindIndex(x => x.Equals(Player));
            int opponentIndex = new List<int> { 'A', 'B', 'C' }.FindIndex(x => x.Equals(Opponent));
            // Must add 1 to go index -> score
            return playerIndex + (playerIndex == opponentIndex ? 4 : playerIndex == (opponentIndex + 1) % 3 ? 7 : 1);
        }
    }
}

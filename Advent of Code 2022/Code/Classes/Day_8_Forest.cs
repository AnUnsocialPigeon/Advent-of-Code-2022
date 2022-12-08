using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Code.Day8 {
    internal class Forest {
        public List<List<int>> Map = new();
        public Forest(string[] Input) {
            Map = Input.Select(y => y.Select(x => int.Parse(x.ToString())).ToList()).ToList(); // y,x,
       
        }

        public bool IsTreeVisable(int x, int y) {
            return IsVisableNorth(x, y) == y || IsVisableEast(x, y) == Map[y].Count - x || IsVisableSouth(x, y) == Map.Count - y || IsVisableWest(x, y) == x;
        }

        public int ScenicScore(int x, int y) {
            return IsVisableNorth(x, y) * IsVisableEast(x, y) * IsVisableSouth(x, y) * IsVisableWest(x, y);
        }

        private int IsVisableNorth(int x, int y) {
            int score = 0;
            for (int Y = y - 1; Y >= 0; Y--) {
                score++;
                if (Map[y][x] <= Map[Y][x]) break;
            }
            return score;
        }
        private int IsVisableEast(int x, int y) {
            int score = 0;
            for (int X = x + 1; X < Map.Count; X++) {
                score++;
                if (Map[y][x] <= Map[y][X]) break;
            }
            return score;
        }
        private int IsVisableSouth(int x, int y) {
            int score = 0;
            for (int Y = y + 1; Y < Map[y].Count; Y++) {
                score++;
                if (Map[y][x] <= Map[Y][x]) break;
            }
            return score;
        }
        private int IsVisableWest(int x, int y) {
            int score = 0;
            for (int X = x - 1; X >= 0; X--) {
                score++;
                if (Map[y][x] <= Map[y][X]) break;
            }
            return score;
        }

    }
}

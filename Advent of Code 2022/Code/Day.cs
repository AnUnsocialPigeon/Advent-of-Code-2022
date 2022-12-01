namespace Advent_of_Code_2022.Code {
    abstract class AdventOfCode {
        public string[] Input;
        protected AdventOfCode(string[] input) => Input = input;
        public abstract string Main();

    }
}

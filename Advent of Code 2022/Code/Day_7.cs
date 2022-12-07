using Directory = Advent_of_Code_2022.Code.Day7.Directory;

namespace Advent_of_Code_2022.Code {
    internal class Day_7 : AdventOfCode {
        public Day_7(string[] input) : base(input) { }
        private Directory FileSystem = new("/");
        private List<int> AllFilesSizes = new();


        const int TotalSpace = 70000000;
        const int FreeSpaceRequired = 30000000;

        public override string Main() {
            foreach (string line in Input.Skip(1)) {
                if (line[0] == '$') {
                    Command(line);
                    continue;
                }
                // ls
                if (line.Split(' ')[0] == "dir") {
                    FileSystem.AddDirectory(line.Split(' ')[1]);
                    continue;
                }
                FileSystem.AddFile(line.Split(' ')[1], int.Parse(line.Split(' ')[0]));
            }

            // Traversal -> need to get parent
            while (FileSystem.Parent is not null) FileSystem = FileSystem.GetParent();
            GetAllFileSizes(FileSystem);

            while (FileSystem.Parent is not null) FileSystem = FileSystem.GetParent();
            int totalSpaceUsed = FileSystem.GetDirectorySize();
            int spaceToFreeUp = FreeSpaceRequired - (TotalSpace - FileSystem.GetDirectorySize());

            return $"Part 1:\nSum of all files = {AllFilesSizes.Where(x => x <= 100000).Sum()}\n\n" +
                $"Part 2:\nClosest to {spaceToFreeUp} = {AllFilesSizes.Aggregate(int.MaxValue, (closest, next) => next > spaceToFreeUp && next - spaceToFreeUp < closest ? next : closest)}";
        }

        private void GetAllFileSizes(Directory dir) {
            AllFilesSizes.Add(dir.GetDirectorySize());
            foreach (Directory d in dir.Directories) GetAllFileSizes(d);
        }

        private void Command(string line) {
            string cmd = line.Split(' ')[1];
            if (cmd == "ls") return;
            
            string args = line.Split(' ')[2];
            
            if (args == "..") {
                FileSystem = FileSystem.GetParent();
                return;
            }
            FileSystem = FileSystem.GetChild(args);
        }
    }
}

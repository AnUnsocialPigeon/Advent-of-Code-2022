namespace Advent_of_Code_2022.Code.Day7 {
    internal class Directory {
        public string Name;
        public List<Directory> Directories = new();
        public List<File> Files = new();
        public Directory? Parent;
        private int? Size = null;

        public Directory(string name, Directory? parent = null) {
            Name = name;
            Parent = parent;
        }
        public void AddDirectory(string Name) {
            Directories.Add(new(Name, this));
        }
        public void AddFile(string Name, int Size) {
            Files.Add(new(Name, Size));
        }
        public Directory GetParent() {
            if (Parent is null) throw new NullReferenceException();
            return Parent;
        }
        public Directory GetChild(string name) {
            foreach (Directory d in Directories)
                if (d.Name == name)
                    return d;
            throw new NullReferenceException();
        }

        public int GetDirectorySize() {
            if (Size is not null || Files.Count + Directories.Count == 0) return Size ?? 0;
            Size = Files.Sum(f => f.Size) + Directories.Sum(d => d.GetDirectorySize());
            return Size ?? 0;
        }

    }
}

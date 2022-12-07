using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.Code.Day7 {
    internal class File {
        public string Name { get; set; }
        public int Size { get; set; }
        public File(string name, int size) {
            Name = name;
            Size = size;
        }
    }
}

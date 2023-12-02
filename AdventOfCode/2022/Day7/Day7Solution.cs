using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AdventOFCode.Day7
{
    public class Day7Solution : BaseUtils
    {
        public Day7Solution() : base("input7.txt") { }
        private List<Directory> tree = new();
        public override void SolveIssue()
        {
            Solve(Data);
        }

        private void Solve(string data)
        {
            int index = 0;
            foreach (var command in data.SplitByEndOfLine())
            {
                if(command.StartsWith('$'))
                {
                    index = TraverseTree(index, command);
                }
                else if (command.StartsWith("dir"))
                {
                    CreateDirectory(index, command);
                }
                else
                {
                    CreateFile(index, command);
                }   
            }

            int sum = 0;
            foreach (Directory directory in tree)
            {
                int result = GetAllSize(directory);
                if (result < 100000)
                {
                    sum += result;
                }
            }
            Console.WriteLine(sum);

            int totalUsed = GetAllSize(tree.First(w => w.name == "/"));
            int placeToBeFound = (30000000 - (70000000 - totalUsed));
            List<Tuple<string, int>> directories = new List<Tuple<string, int>>();
            foreach (Directory directory in tree)
            {
                int result = GetAllSize(directory);
                if (result > placeToBeFound)
                {
                    directories.Add(new(directory.name, result));
                }
            }
            Console.WriteLine(directories.MinBy(w => w.Item2).Item2);

        }
        private void CreateDirectory(int index, string command)
        {
            var args = command.SplitBySpace();
            tree.Add(new Directory
            {
                name = args[1],
                parent = tree[index].guid,
                files = new List<File>(),
            });
        }
        private void CreateFile(int index, string command)
        {
            var args = command.SplitBySpace();
            tree[index].files.Add(new File(args[1], int.Parse(args[0])));
        }

        private int TraverseTree(int index, string command)
        {
            var args = command.SplitBySpace();
            if (args[1] == "ls")
            {
                return index;
            }
            else if (args[2] == "/")
            {
                tree.Add(new Directory());
                return index;
            }
            else if (args[2] == "..")
            {
                return tree.FindIndex(x => x.guid == tree[index].parent);
            }
            else
            {
                return tree.FindIndex(x => x.name == args[2] && x.parent == tree[index].guid);
            }
        }
        private int GetAllSize(Directory elem)
        {
            // size of this folder
            int i = elem.GetSize();
            foreach (Directory directory in tree.Where(w => w.parent == elem.guid))
            {
                i += GetAllSize(directory);
            }
            return i;
        }
    }

    public class Directory
    {
        public string name { get; set; }
        public Guid guid { get; set; }
        public Guid parent { get; set; }
        public List<File> files { get; set; }
        public Directory()
        {
            name = "/";
            guid = Guid.NewGuid();
            parent = Guid.Empty;
            files = new List<File>();
        }

        public int GetSize()
        {
            return files.Sum(x => x.size);
        }
    }
    public record File(string name, int size);
}

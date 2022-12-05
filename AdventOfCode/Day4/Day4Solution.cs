using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOFCode.Day4
{
    public class Day4Solution : BaseUtils
    {
        public Day4Solution() : base("input4.txt") { }
        public override void SolveIssue()
        {
            string[] parsedInput = Data.SplitByEndOfLine();
            SolvePartOne(parsedInput);
            SolvePartTwo(parsedInput);
        }

        private void SolvePartOne(string[] data)
        {
            int count = 0;
            foreach (string line in data)
            {
                string[] areas = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                IEnumerable<int> firstElf = GetNumbers(areas[0]);
                IEnumerable<int> secondelf = GetNumbers(areas[1]);

                if (firstElf.Union(secondelf).Count() == firstElf.Count() || secondelf.Union(firstElf).Count() == secondelf.Count())
                {
                    count += 1;
                }
            }
            Console.WriteLine($"Day4 part one: Found {count} areas");
        }
        private void SolvePartTwo(string[] data)
        {
            int count = 0;
            foreach (string line in data)
            {
                string[] areas = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                IEnumerable<int> firstElf = GetNumbers(areas[0]);
                IEnumerable<int> secondelf = GetNumbers(areas[1]);

                if (firstElf.Except(secondelf).Count() != firstElf.Count())
                {
                    count += 1;
                }
            }
            Console.WriteLine($"Day4 part two: Found {count} areas");
        }

        private IEnumerable<int> GetNumbers(string range)
        {
            string[] borders = range.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = int.Parse(borders[0]); i <= int.Parse(borders[1]); i++)
            {
                yield return i;
            }
        }
    }
}


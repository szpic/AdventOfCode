using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOFCode.Day3
{
    public class Day3Solution : BaseUtils
    {
        public Day3Solution() : base("input3.txt") { }
        private readonly string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public override void SolveIssue()
        {
            List<char> duplicates = new();
            string[] parsedInput = Data.SplitByEndOfLine();

            //Part one
            foreach (string rucksack in parsedInput)
            {
                int halfLength = rucksack.Length / 2;
                string left = rucksack[0..^halfLength];
                string right = rucksack[halfLength..^0];


                duplicates.Add(left.Intersect(right).First());
            }
            int sum = 0;
            foreach (char a in duplicates)
            {
                int location = letters.IndexOf(a);
                sum += (location + 1);
            }
            //part two
            duplicates.Clear();
            for (int i = 0; i < parsedInput.Length; i += 3)
            {
                HashSet<char> hashset = new(parsedInput[i]);
                hashset.IntersectWith(parsedInput[i + 1]);
                hashset.IntersectWith(parsedInput[i + 2]);
                duplicates.Add(hashset.First());
            }
            sum = 0;
            foreach (char a in duplicates)
            {
                int location = letters.IndexOf(a);
                sum += (location + 1);
            }
            Console.WriteLine($"Day3 part two: Sum of priorities is: {sum}");
        }
    }

}
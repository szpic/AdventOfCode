using AdventOFCode.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOFCode.Day1
{
    public class Day1Solution : BaseUtils
    {
        public Day1Solution() : base("input1.txt") { }

        public override void SolveIssue()
        {
            //Part One
            List<int> caloriesList = new();
            string[] AllElfsData = Data.SplitByEmptyLine();
            foreach (string elf in AllElfsData)
            {
                int calories = 0;
                string[] bagpack = elf.SplitByEndOfLine();
                foreach (string bagpackItem in bagpack)
                {
                    calories += int.Parse(bagpackItem);
                }
                caloriesList.Add(calories);
            }
            Console.WriteLine($"Day 1 part one: Biggest value of calories is {caloriesList.Max()} kcal");
            // Part Two
            Console.WriteLine($"Day 1 part two: Sum of top 3 calories is {caloriesList.OrderByDescending(x => x).Take(3).Sum()} kcal");
        }

    }
}
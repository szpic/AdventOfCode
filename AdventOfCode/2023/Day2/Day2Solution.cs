using AdventOFCode.Base;
using AdventOFCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOFCode2023.Day2
{
    public class Day2Solution : BaseUtils
    {
        public Day2Solution() : base("input2023_2.txt") { }


        public override void SolveIssue()
        {
            int sum = 0;
            int power = 0;
            foreach (var line in Data.SplitByEndOfLine())
            {
                var game = Parse(Regex.Matches(line, @"Game (\d+)")).First();
                var red = Parse(Regex.Matches(line, @"(\d+) red")).Max();
                var green = Parse(Regex.Matches(line, @"(\d+) green")).Max();
                var blue = Parse(Regex.Matches(line, @"(\d+) blue")).Max();

                if (red <= 12 && green<=13 && blue <= 14)
                {
                    sum += game;
                }
                power += (red * green * blue);
            }
            Console.WriteLine($"sum of games is {sum} and power is  {power}");
        }
        public IEnumerable<int>Parse(MatchCollection matches)
        {
            return matches.Select(i => int.Parse(i.Groups[1].Value));
        }
    }

}
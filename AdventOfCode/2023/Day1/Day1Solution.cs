using AdventOFCode.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOFCode2023.Day1
{
    public class Day1Solution : BaseUtils
    {
        public Day1Solution() : base("input2023_1.txt") { }


        public override void SolveIssue()
        {
            var regex = @"\d|one|two|three|four|five|six|seven|eight|nine";
            int sum = 0;
            foreach(var line in Data.SplitByEndOfLine())
            {
                var first = Regex.Match(line, regex);
                var last  = Regex.Match(line, regex, RegexOptions.RightToLeft);
                sum += (ParseMatch(first.Value) * 10 + ParseMatch(last.Value));
            }
            Console.WriteLine(sum);
        }

        int ParseMatch(string st) => st switch
        {
            "one" => 1,
            "two" => 2,
            "three" => 3,
            "four" => 4,
            "five" => 5,
            "six" => 6,
            "seven" => 7,
            "eight" => 8,
            "nine" => 9,
            var d => int.Parse(d)
        };
    }
}
using AdventOFCode.Base;
using AdventOFCode.Day9;
using AdventOFCode.Utils;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOFCode2023.Day3
{
    public class Day3Solution : BaseUtils
    {
        public Day3Solution() : base("input2023_3.txt") { }
        public override void SolveIssue()
        {
            string[] dataLines = Data.Split('\n');
            int sum = 0;
            var numbers = Parse(Data, new Regex(@"\d+"));
            var symbols = Parse(Data, new Regex(@"[^.0-9]"));
            foreach (var number in numbers)
            {
                if (symbols.Any(s => isNeighbour(s, number)))
                {
                    sum += int.Parse(number.Text);
                }
            }
            Console.WriteLine($"result part 1: {sum}");
            //part2
            sum = 0;
            var dots = Parse(Data, new Regex(@"\*"));
            foreach(var dot in dots)
            {
                //for each dot find numbers
                var neighbours =numbers.Where(w => isNeighbour(w, dot));
                if (neighbours.Count() == 2)
                {
                    sum += (int.Parse(neighbours.First().Text) * int.Parse(neighbours.Last().Text));
                }
            }
            Console.WriteLine($"result part 2: {sum}");


        }

        public bool isNeighbour(Part p1, Part p2)
        {
            if (Math.Abs(p2.row - p1.row) <= 1
                && p2.col <= p1.col + p1.Text.Length && 
                   p1.col <= p2.col + p2.Text.Length) 
            {
                return true;
            }
            return false;
        }

        public List<Part> Parse(string data, Regex regex)
        {
            List<Part> parts = new List<Part>();
            var lines = data.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                var matches = regex.Matches(lines[i]);
                foreach (Match match in matches)
                {
                    parts.Add(new Part(match.Value, i, match.Index));
                }
            }
            return parts;
        }

        public record Part(string Text, int row, int col);
    }
}
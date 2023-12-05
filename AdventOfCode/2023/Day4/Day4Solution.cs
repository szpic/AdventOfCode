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
using static AdventOFCode2023.Day4.Day4Solution;

namespace AdventOFCode2023.Day4
{
    public class Day4Solution : BaseUtils
    {
        public Day4Solution() : base("input2023_4.txt") { }
        public override void SolveIssue()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var games =Data.Split('\n').Select((s) =>
            {
                var line = s.Split(new[] { ':', '|' }, StringSplitOptions.RemoveEmptyEntries);
                return new Game(
                    int.Parse(Regex.Match(line[0], @"\d+").Value),
                    Regex.Matches(line[1], @"\d+").Select(s=> int.Parse(s.Value)).ToList(),
                    Regex.Matches(line[2], @"\d+").Select(s => int.Parse(s.Value)).ToList());
            }).ToList();

            var counts = games.Select(_ => 1).ToArray();
            double sum = 0;
            foreach (var game in games)
            {
                var hits = game.winningNumbers.Intersect(game.myNumbers).Count();
                if (hits > 0)
                    sum += (Math.Pow(2, hits - 1));
            }

            Console.WriteLine($"card is worth {sum}");


            for (int i =0; i< games.Count(); i++)
            {
                var hits = games[i].winningNumbers.Intersect(games[i].myNumbers).Count();
                for(int x = 0;x < counts[i]; x++)
                {
                    for (int j = 0; j < hits; j++)
                    {
                        counts[i + j + 1] += 1;
                    }
                }
            }
            watch.Stop();
            Console.WriteLine($"sum of cards is {counts.Sum()}  and logic took {watch.ElapsedMilliseconds} ms");
        }

        public record Game(int Id, List<int> winningNumbers, List<int>myNumbers);
    }
}
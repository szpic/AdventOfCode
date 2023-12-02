using AdventOFCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOFCode.Day11
{
    internal class Day11Solution : BaseUtils
    {
        public Day11Solution() : base("input11.txt") { }
        public override void SolveIssue()
        {
            string[] input = Data.SplitByEmptyLine();
            var monkes = input.Select(GetMonke).ToArray();
            //part1
            Solve(monkes, 20, w => w / 3);
            //part2
            monkes = input.Select(GetMonke).ToArray();
            long monkesDivider = monkes.Aggregate(1, (res, monke) => res * monke.Modulo);
            Solve(monkes, 10000, w => w % monkesDivider);
        }
        public void Solve(Monke[] monkes, int rounds, Func<long, long> operation)
        {
            for (int i = 0; i < monkes.Length * rounds; i++)
            {
                int index = i % monkes.Length;
                while (monkes[index].StartingItems.Count != 0)
                {
                    long item = monkes[index].StartingItems.Dequeue();
                    long worryLevel = (monkes[index].Operation(item));
                    worryLevel = operation(worryLevel);
                    if (worryLevel % monkes[index].Modulo == 0)
                    {
                        monkes[monkes[index].True].StartingItems.Enqueue(worryLevel);
                    }
                    else
                    {
                        monkes[monkes[index].False].StartingItems.Enqueue(worryLevel);
                    }
                    monkes[index].Inspections++;
                }
            }
            Console.WriteLine(monkes.OrderByDescending(w => w.Inspections).Take(2).Aggregate(1L, (res, monke) => res * monke.Inspections));
        }
        public Monke GetMonke(string input)
        {
            string[] lines = input.SplitByEndOfLine();
            return new Monke
            {
                StartingItems = GetQueue(lines[1]),
                Operation = GetOperation(lines[2]),
                Modulo = int.Parse(lines[3].Split("by")[1]),
                True = GetTargetMonkey(lines[4]),
                False = GetTargetMonkey(lines[5]),
                Inspections = 0
            };
        }
        private Queue<long> GetQueue(string input)
        {
            var queue = new Queue<long>();
            foreach (int i in input.Split(':')[1].Split(',').Select(s => int.Parse(s)))
            {
                queue.Enqueue(i); ;
            }
            return queue;
        }
        private Func<long, long> GetOperation(string input)
        {
            var operation = input.Split('=')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

            return operation switch
            {
                var x when operation[1] == "+" && operation[2] != "old" => ((val) => (val) + int.Parse(operation[2])),
                var x when operation[1] == "+" && operation[2] == "old" => ((val) => (val) * 2),
                var x when operation[1] == "*" && operation[2] != "old" => ((val) => (val) * int.Parse(operation[2])),
                var x when operation[1] == "*" && operation[2] == "old" => ((val) => (val) * val),
                _ => throw new ArgumentException()
            };
        }
        private int GetTargetMonkey(string input) => int.Parse(input.Split("monkey")[1]);
    }
    public class Monke
    {
        public Queue<long> StartingItems { get; set; }
        public Func<long, long> Operation { get; set; }
        public int Modulo { get; set; }
        public int True { get; set; }
        public int False { get; set; }
        public int Inspections { get; set; }
    }
}

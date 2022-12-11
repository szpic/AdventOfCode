using AdventOFCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
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
            for (int i = 0; i < monkes.Length*10000; i++)
            {
                int index = i % monkes.Length;
                while (monkes[index].StartingItems.Count != 0)
                {
                    var item = monkes[index].StartingItems.Dequeue();
                    int worryLevel = (int)((monkes[index].Operation(item)));
                    if (monkes[index].Test(worryLevel))
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
            var orderredMonkes = monkes.OrderByDescending(w => w.Inspections).Take(2);
            Console.WriteLine(orderredMonkes.First().Inspections* orderredMonkes.Last().Inspections);
        }
        public Monke GetMonke(string input)
        {
            string[] lines = input.SplitByEndOfLine();
            return new Monke
            {
                StartingItems = GetQueue(lines[1]),
                Operation = GetOperation(lines[2]),
                Test = GetTest(lines[3]),
                True = GetTargetMonkey(lines[4]),
                False = GetTargetMonkey(lines[5]),
                Inspections = 0
            };
        }
        private Queue<int> GetQueue(string input)
        {
            var queue = new Queue<int>();
            foreach(int i in  input.Split(':')[1].Split(',').Select(s => int.Parse(s)))
            {
                queue.Enqueue(i); ;
            }
            return queue;
        }
        private Func<int,int> GetOperation(string input)
        {
            var operation = input.Split('=')[1].Split(' ',StringSplitOptions.RemoveEmptyEntries);

            return operation switch
            {
                var x when operation[1]=="+"  && operation[2]!="old" => ((val) => (val) + int.Parse(operation[2])),
                var x when operation[1] == "+" && operation[2] == "old" => ((val) => (val) *2),
                var x when operation[1] == "*" && operation[2] != "old" => ((val) => (val) * int.Parse(operation[2])),
                var x when operation[1] == "*" && operation[2] == "old" => ((val) => (val) * val),
                _=> throw new ArgumentException()
            };
        }
        private Func<int, bool>GetTest(string input)
        {
            var line = input.Split("by");
            return (val) => val % int.Parse(line[1]) == 0;
        }
        private int GetTargetMonkey(string input) => int.Parse(input.Split("monkey")[1]);
    }
    public class Monke
    {
        public Queue<int> StartingItems { get; set; }
        public Func<int,int> Operation { get; set; }
        public Func<int,bool> Test { get; set; }
        public int True { get; set; }   
        public int False { get; set; }
        public int Inspections { get; set; }
    }
}

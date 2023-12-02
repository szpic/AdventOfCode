using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AdventOFCode.Day5
{
    public class Day5Solution : BaseUtils
    {
        public Day5Solution() : base("input5.txt") { }

        private record struct Command(int HowMany, Stack<char> From, Stack<char> To);
        public override void SolveIssue()
        {
            Solve(Data, Move9000);
            Solve(Data, Move9001);
        }

        private void Solve(string data, Action<Command> action)
        {
            var temp = data.SplitByEmptyLine();
            // building stacks:
            var stacksDef = temp.First().SplitByEndOfLine();
            var stacks = stacksDef.Last().Chunk(4).Select(chunk => new Stack<char>()).ToArray();
            //fill stacks
            foreach (var line in stacksDef.Reverse().Skip(1))
            {
                foreach (var (stack, item) in stacks.Zip(line.Chunk(4)))
                {
                    if (item[1] != ' ')
                    {
                        stack.Push(item[1]);
                    }
                }
            }

            //commands to be done
            foreach (string line in temp.Last().SplitByEndOfLine())
            {
                var groups = Regex.Match(line, @"move (\d+) from (\d+) to (\d+)").Groups;
                action(new Command(int.Parse(groups[1].Value), stacks[int.Parse(groups[2].Value) - 1], stacks[int.Parse(groups[3].Value) - 1]));
            }

            StringBuilder result = new StringBuilder();
            // Write results
            foreach (Stack<char> s in stacks)
            {
                if (s.Count != 0)
                {
                    
                    result.Append(s.Pop());
                }
            }
            Console.WriteLine(result.ToString());
        }
        private void Move9000(Command command)
        {

            for (int i = 0; i < command.HowMany; i++)
            {
                command.To.Push(command.From.Pop());
            }
        }

        private void Move9001(Command command)
        {
            Stack<char> localStack = new();
            for (int i = 0; i < command.HowMany; i++)
            {
                localStack.Push(command.From.Pop());
            }

            for (int i = 0; i < command.HowMany; i++)
            {
                command.To.Push(localStack.Pop());
            }
        }
    }
}

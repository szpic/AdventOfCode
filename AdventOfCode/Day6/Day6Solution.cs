using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AdventOFCode.Day6
{
    public class Day6Solution : BaseUtils
    {
        public Day6Solution() : base("input6.txt") { }

        public override void SolveIssue()
        {
            Solve(Data, 4, "Start of packet marker index");
            Solve(Data, 14, "Start of message marker index");
        }

        private void Solve(string data, int length, string message)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data.Substring(i, length).Distinct().Count() == length)
                {
                    Console.WriteLine($"{message} : {i + length}");
                    break;
                }
            }
        }
    }
}

using AdventOFCode.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOFCode.Day2
{
    public class Day2Solution : BaseUtils
    {
        public Day2Solution() : base("input2.txt") { }
        public override void SolveIssue()
        {
            string[] matches = Data.SplitByEndOfLine();
            int points = 0;
            //Part One
            foreach (string match in matches)
            {
                string[] vs = match.SplitBySpace();
                // i know that this
                int result = vs switch
                {

                    string[] when vs[0] == "A" && vs[1] == "X" => 1 + 3,
                    string[] when vs[0] == "A" && vs[1] == "Y" => 2 + 6,
                    string[] when vs[0] == "A" && vs[1] == "Z" => 3 + 0,

                    string[] when vs[0] == "B" && vs[1] == "X" => 1 + 0,
                    string[] when vs[0] == "B" && vs[1] == "Y" => 2 + 3,
                    string[] when vs[0] == "B" && vs[1] == "Z" => 3 + 6,

                    string[] when vs[0] == "C" && vs[1] == "X" => 1 + 6,
                    string[] when vs[0] == "C" && vs[1] == "Y" => 2 + 0,
                    string[] when vs[0] == "C" && vs[1] == "Z" => 3 + 3,
                    _ => 0
                };
                points += result;
            }
            Console.WriteLine($"Tournament result is {points} points");
            //Part Two
            points = 0;
            foreach (string match in matches)
            {
                string[] vs = match.SplitBySpace();
                int result = vs switch
                {

                    string[] when vs[0] == "A" && vs[1] == "X" => 3 + 0,
                    string[] when vs[0] == "A" && vs[1] == "Y" => 1 + 3,
                    string[] when vs[0] == "A" && vs[1] == "Z" => 2 + 6,

                    string[] when vs[0] == "B" && vs[1] == "X" => 1 + 0,
                    string[] when vs[0] == "B" && vs[1] == "Y" => 2 + 3,
                    string[] when vs[0] == "B" && vs[1] == "Z" => 3 + 6,

                    string[] when vs[0] == "C" && vs[1] == "X" => 2 + 0,
                    string[] when vs[0] == "C" && vs[1] == "Y" => 3 + 3,
                    string[] when vs[0] == "C" && vs[1] == "Z" => 1 + 6,
                    _ => 0
                };
                points += result;
            }
            Console.WriteLine($"Tournament second round result is {points} points");
        }

    }
}
/*
 *  A Rock
 *  B Paper
 *  C Scissors
 *  
 *  X Rock 1
 *  Y Paper 2
 *  Z Scissors 3
 *  
 *  0 przegrana
 *  1 remis
 *  6 wygrana
 *  
 */
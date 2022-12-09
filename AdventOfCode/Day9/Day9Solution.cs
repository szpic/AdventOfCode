using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOFCode.Day9
{
    public  class Day9Solution : BaseUtils
    {
        public Day9Solution() : base("input9.txt") { }

        static Direction Left = new Direction(0, -1);
        static Direction Right = new Direction(0, 1);
        static Direction Up = new Direction(-1, 0);
        static Direction Down = new Direction(1, 0);
        public override void SolveIssue()
        {
            HashSet<string> visitedPlaces = new();
            visitedPlaces.Add("00");
            var commands = Data.SplitByEndOfLine();
            Location head,tail = new();
            foreach (var line in commands)
            {
                var command = line.SplitBySpace();

            }
        }
    }
    record Direction(int x, int y);

    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Location()
        {
            X = 0;
            Y = 0;
        }
    }

}

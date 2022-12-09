using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOFCode.Day9
{
    public class Day9Solution : BaseUtils
    {
        public Day9Solution() : base("input9.txt") { }

        static Direction Left = new Direction(0, -1);
        static Direction Right = new Direction(0, 1);
        static Direction Up = new Direction(1, 0);
        static Direction Down = new Direction(-1, 0);
        HashSet<string> visitedPlaces = new();
        public override void SolveIssue()
        {
            var commands = Data.SplitByEndOfLine();
            Location head = new();
            Location tail = new();
            visitedPlaces.Add(tail.ToString());
            foreach (var line in commands)
            {
                var command = line.SplitBySpace();
                if (command[0] == "R")
                    MakeMove(head, tail, Right, command[1]);
                else if (command[0] == "D")
                    MakeMove(head, tail, Down, command[1]);
                else if (command[0] == "U")
                    MakeMove(head, tail, Up, command[1]);
                else
                    MakeMove(head, tail, Left, command[1]);
            }
            Console.WriteLine($"tail visited {visitedPlaces.Count} unique places");
        }

        public void MakeMove(Location head, Location tail, Direction direction, string count)
        {
            for (int i = 0; i < int.Parse(count); i++)
            {
                head.X += direction.x;
                head.Y += direction.y;
                double distance = CheckDistance(head, tail);
                if (distance == 2)
                {
                    
                    visitedPlaces.Add(tail.ToString());
                }
                else if(distance<)
;
            }
        }
        public double CheckDistance(Location head, Location tail)
        {
            return (Math.Sqrt(Math.Pow((head.X - tail.X), 2) + Math.Pow((head.Y - tail.Y), 2)));
        }
    }
    public record Direction(int x, int y);

    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Location()
        {
            X = 0;
            Y = 0;
        }
        public override string ToString()
        {
            return X.ToString() + Y.ToString();
        }
    }

}

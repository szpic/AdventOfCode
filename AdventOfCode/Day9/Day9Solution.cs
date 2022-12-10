using System;
using System.Collections.Generic;
using System.IO;
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
        HashSet<Direction> visitedPlaces = new();
        public override void SolveIssue()
        {
            var commands = Data.SplitByEndOfLine();
            SolvePart(commands, 2);
            visitedPlaces.Clear();
            SolvePart(commands, 10);

        }
        private void SolvePart(string[] commands, int length)
        {
            var rope = Enumerable.Range(0, length).Select(_ => new Location()).ToArray();
            visitedPlaces.Add(new Direction(1, 1));
            foreach (var line in commands)
            {
                var command = line.SplitBySpace();
                if (command[0] == "R")
                    MakeMove(rope, Right, int.Parse(command[1]), length);
                else if (command[0] == "D")
                    MakeMove(rope, Down, int.Parse(command[1]), length);
                else if (command[0] == "U")
                    MakeMove(rope, Up, int.Parse(command[1]), length);
                else
                    MakeMove(rope, Left, int.Parse(command[1]), length);
            }
            Console.WriteLine($"tail visited {visitedPlaces.Count} unique places");
        }

        public void MakeMove(Location[] rope, Direction direction, int count, int length)
        {
            for (int i = 0; i < count; i++)
            {
                rope[0].X += direction.x;
                rope[0].Y += direction.y;
                //move all tales
                for (int x = 1; x < rope.Length; x++)
                {
                    double distance = CheckDistance(rope[x - 1], rope[x]);
                    if (distance == 2)
                    {
                        (int x1, int x2) = GetMove(rope[x - 1], rope[x]);
                        rope[x].X += x1;
                        rope[x].Y += x2;
                    }
                    else if (distance > 2)
                    {
                        (int x1, int x2) = GetDiagonalMove(rope[x - 1], rope[x]);
                        rope[x].X += x1;
                        rope[x].Y += x2;

                    }
                }
                visitedPlaces.Add(new Direction(rope[length - 1].X, rope[length - 1].Y));

            }
        }

        private (int x, int y) GetDiagonalMove(Location head, Location tail)
        {
            if(head.X> tail.X)
            {
                //upper part
                if(head.Y> tail.Y)
                {
                    return (1, 1);
                }
                return (1, -1);
            }
            else
            {
                //lower part
                if (head.Y > tail.Y)
                {
                    return (-1, 1);
                }
                return (-1, -1);
            }
        }
        private (int x, int y) GetMove(Location head, Location tail)
        {
            if (head.X == tail.X)
            {
                if (head.Y > tail.Y)
                {
                    return (0, 1);
                }
                return (0, -1);
            }
            else
            {
                //lower part
                if (head.X > tail.X)
                {
                    return (1, 0);
                }
                return (-1, 0);
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
            X = 1;
            Y = 1;
        }
        public override string ToString()
        {
            return X.ToString() + "*" + Y.ToString();
        }
    }
}

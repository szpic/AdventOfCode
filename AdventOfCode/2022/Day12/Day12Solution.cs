using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AdventOFCode.Day12
{
    internal class Day12Solution : BaseUtils
    {

        public Day12Solution() : base("input12.txt") { }

        public record Point(int x, int y);
        public record PointsButWithDistance(int x, int y, int distance);
        public override void SolveIssue()
        {

            var data = Data.SplitByEndOfLine().Select(s => s.ToCharArray()).ToArray();
            int rows = data.Length;
            int cols = data[0].Count();

            Console.WriteLine(SolvePartOne(data, rows, cols));
            data = Data.SplitByEndOfLine().Select(s => s.ToCharArray()).ToArray();
            Console.WriteLine(SolvePartTwo(data, rows, cols));
        }
        public int SolvePartOne(char[][] data, int rows, int cols)
        {
            Point start = new Point(0, 0), end = new Point(0, 0);
            for (int i = 0; i < rows; i++)
            {
                for (int y = 0; y < cols; y++)
                {
                    if (data[i][y] == 'S')
                    {
                        start = new Point(i, y);
                        data[i][y] = 'a';
                    }
                    if (data[i][y] == 'E')
                    {
                        end = new Point(i, y);
                        data[i][y] = 'z';
                    }
                }
            }
            return BFS(data, start, end, data.Length, data[0].Count());
        }
        public int SolvePartTwo(char[][] data, int rows, int cols)
        {
            List<Point> points = new List<Point>();
            Point end = new Point(0, 0);
            for (int i = 0; i < rows; i++)
            {
                for (int y = 0; y < cols; y++)
                {
                    if (data[i][y] == 'S' || data[i][y] == 'a')
                    {
                        points.Add(new Point(i, y));
                        data[i][y] = 'a';
                    }
                    if (data[i][y] == 'E')
                    {
                        end = new Point(i, y);
                        data[i][y] = 'z';
                    }
                }
            }
           return points.Select(p=>BFS(data,p,end,rows,cols)).Where(w=>w!=-1).Min();
        }

        public int BFS(char[][] graphs, Point start, Point target, int rows, int cols)
        {
            Queue<PointsButWithDistance> queue = new Queue<PointsButWithDistance>();
            var visited = new bool[rows, cols];
            //mark first as visited
            visited[start.x, start.y] = true;
            queue.Enqueue(new PointsButWithDistance(start.x, start.y, 0));
            while (queue.Any())
            {
                var v = queue.Dequeue();
                if (v.x == target.x && v.y == target.y)
                {
                    return v.distance;
                }
                var edges = GetAdjacentEdges(v, graphs, rows, cols);
                for (int i = 0; i < edges.Count(); i++)
                {
                    var p = edges[i];
                    if (visited[p.x, p.y] != true)
                    {
                        visited[p.x, p.y] = true;
                        queue.Enqueue(p);
                    }
                }
            }
            return -1;
        }
        List<PointsButWithDistance> GetAdjacentEdges(PointsButWithDistance start, char[][] graph, int rows, int cols)
        {
            List<PointsButWithDistance> edges = new List<PointsButWithDistance>();
            //left
            if (start.y - 1 >= 0 && (graph[start.x][start.y - 1] - graph[start.x][start.y] <= 1))
            {
                edges.Add(new PointsButWithDistance(start.x, start.y - 1, start.distance + 1));
            }
            if (start.y + 1 < cols && (graph[start.x][start.y + 1] - graph[start.x][start.y] <= 1))
            {
                edges.Add(new PointsButWithDistance(start.x, start.y + 1, start.distance + 1));
            }
            if (start.x - 1 >= 0 && (graph[start.x - 1][start.y] - graph[start.x][start.y] <= 1))
            {
                edges.Add(new PointsButWithDistance(start.x - 1, start.y, start.distance + 1));
            }
            if (start.x + 1 < rows && (graph[start.x + 1][start.y] - graph[start.x][start.y] <= 1))
            {
                edges.Add(new PointsButWithDistance(start.x + 1, start.y, start.distance + 1));
            }
            return edges;
        }



    }
}

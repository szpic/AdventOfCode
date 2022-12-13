using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace AdventOFCode.Day13
{
    internal class Day13Solution : BaseUtils
    {
        public Day13Solution() : base("input13.txt") { }
        public override void SolveIssue()
        {
            Console.WriteLine(GetInput(Data).Chunk(2).Select((p, i) => Compare(p[0], p[1]) < 1 ? i + 1 : 0).Sum());
            var input = GetInput(Data).ToList();
            var divider = (GetInput("[[2]]\r\n[[6]]")).ToList();
            var result=input.Concat(divider).ToList();
            result.Sort(Compare);
            Console.WriteLine((result.IndexOf(divider[0]) + 1) * (result.IndexOf(divider[1]) + 1));
        }
        IEnumerable<JsonNode> GetInput(string data)
        {
            var a = data.SplitByEmptyLine().SelectMany(s => s.SplitByEndOfLine());
            return a.Select(s => JsonNode.Parse(s));
        }

        int Compare(JsonNode nodeA, JsonNode nodeB)
        {
            if (nodeA is JsonValue && nodeB is JsonValue)
            {
                return (int)nodeA - (int)nodeB;
            }
            else
            {
                var left = nodeA as JsonArray ?? new JsonArray((int)nodeA);
                var right = nodeB as JsonArray ?? new JsonArray((int)nodeB);

                return Enumerable.Zip(left, right).Select(s => Compare(s.First, s.Second))
                    .FirstOrDefault(c => c != 0, left.Count - right.Count);
            };
        }
    }
}

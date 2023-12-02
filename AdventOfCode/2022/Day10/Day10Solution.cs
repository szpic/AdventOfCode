using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOFCode.Day10
{
    internal class Day10Solution : BaseUtils
    {
        public Day10Solution() : base("input10.txt")
        {

        }

        public override void SolveIssue()
        {
            var commands = Data.SplitByEndOfLine();
            List<Cycle> cycles = new List<Cycle>();
            //initial load
            cycles.Add(new Cycle("noop", 1));
            for(int i = 0; i < commands.Count(); i++)
            {
                var command = commands[i].SplitBySpace();
                if (command[0]== "noop")
                {
                    cycles.Add(new Cycle(command[0], 0));
                }
                else
                {
                    cycles.Add(new Cycle(command[0], 0));
                    cycles.Add(new Cycle(command[0], int.Parse(command[1])));
                }
            }
            var signal = 0;
            for(int i = 20; i <= 220; i += 40)
            {
                signal += cycles.Take(i).Sum(w => w.operation) * i;
            }
            Console.WriteLine(signal);
            int registryValue = 1;
            foreach(var chunk in cycles.Skip(1).Chunk(40))
            {
                registryValue =PrintLine(chunk, registryValue);
            }
        }
        private int PrintLine(Cycle[] cycles, int registryValue)
        {
            string spritePosition = "###".PadLeft(registryValue + 2, '.').PadRight(40, '.');
            StringBuilder screenline = new StringBuilder();
            for(int i = 0; i < cycles.Length; i++)
            {
                //draw 
                screenline.Append(spritePosition[i]);
                //move
                if (cycles[i].operation != 0)
                {
                    registryValue += cycles[i].operation;
                    spritePosition = "###".PadLeft(registryValue+2,'.').PadRight(40,'.');
                    
                }
            }
            Console.WriteLine(screenline.ToString());
            return registryValue;
        }
        record Cycle(string name, int operation);
    }
}

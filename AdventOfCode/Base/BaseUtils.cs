using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOFCode.Base
{
    public abstract class BaseUtils
    {
        private string Path { get; init; }
        public string Data => ReadData();
        public BaseUtils(string filename)
        {
            Path = filename;
        }
        private string ReadData()
        {
            string fullPath = $"./Inputs/{Path}";
            if (File.Exists(fullPath))
            {
                return File.ReadAllText(fullPath);
            }
            else
            {
                throw new FileNotFoundException("Input file is missing", Path);
            }
            
        }

        public abstract void SolveIssue();

    }
}

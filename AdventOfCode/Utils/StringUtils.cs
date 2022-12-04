using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOFCode.Utils
{
    public static class StringUtils
    {
        public static string[] SplitBySpace(this string str)
        {
            return str.Split(new char[] { ' ' });
        }

        public static string[] SplitByEmptyLine(this string str)
        {
            return str.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string[] SplitByEndOfLine(this string str)
        {
            return str.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}

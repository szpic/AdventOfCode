using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AdventOFCode.Day8
{
    public class Day8Solution : BaseUtils
    {
        public Day8Solution() : base("input8.txt") { }
        private int columns = 0;
        private int rows = 0;
        public override void SolveIssue()
        {
            var data = GetForest(Data);

            Console.WriteLine(GetVisibleTreesCount(data).ToString());
            Console.WriteLine(GetBestScenicScore(data).ToString());
        }


        private int[,] GetForest(string data)
        {
            string[] lines = data.SplitByEndOfLine();
            columns = lines[0].Length;
            rows = lines.Count();
            int[,] wood = new int[columns, rows];
            for (int i = 0; i < lines.Count(); i++)
            {
                for(int y=0; y< lines[0].Length; y++)
                {
                    wood[i, y] = int.Parse(lines[i][y].ToString());
                }
            }
            return wood;
        }

        private int GetVisibleTreesCount(int[,] forest)
        {
            int visibleCount = columns * 2 +((rows-2)*2);
            for(int row = 1; row < rows - 1; row++)
            {
                for (int column = 1; column < columns - 1; column++)
                {
                    if(IsVisible(row, column, forest))
                    {
                        visibleCount++;
                    }
                }
            }
            return visibleCount;
        }

        private int GetBestScenicScore(int[,] forest)
        {
            int topscore = 0;
            for (int row = 1; row < rows - 1; row++)
            {
                for (int column = 1; column < columns - 1; column++)
                {
                    int score = GetScenicScore(row, column, forest);
                    if (score > topscore)
                    {
                        topscore = score;
                    }
                }
            }
            return topscore;
        }

        private bool IsVisible(int row, int column, int[,] forest)
        {
            //up
            bool result = false;
            for(int i = row-1 ;i >= 0; i--)
            {
                if (forest[row,column] > forest[i, column])
                {
                    result = true;
                    
                }
                else
                {
                    result = false;
                    break;
                }
            }
            if (result)
                return result;

            //down
            for (int i = row + 1; i <= rows-1; i++)
            {
                if (forest[row, column] > forest[i, column])
                {
                    result = true;
                }
                else
                {
                    result = false;
                    break;
                }
            }
            if (result)
                return result;

            //left
            for (int i = column-1; i >= 0; i--)
            {
                if (forest[row, column] > forest[row, i])
                {
                    result = true;
                }
                else
                {
                    result = false;
                    break;
                }
            }
            if (result)
                return result;

            //right
            for (int i = column + 1; i <= columns - 1; i++)
            {
                if (forest[row, column] > forest[row, i])
                {
                    result = true;
                }
                else
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        private int GetScenicScore(int row, int column, int[,] forest)
        {
            int scenicScore = 1;
            int treeCount = 0;
            //up
            for (int i = row - 1; i >= 0; i--)
            {
                treeCount++;
                if (forest[row, column] <= forest[i, column])
                {
                    break;
                }
            }
            scenicScore *= treeCount;
            treeCount = 0;
            //down
            for (int i = row + 1; i <= rows - 1; i++)
            {
                treeCount++;
                if (forest[row, column] <= forest[i, column])
                {
                    
                    break;
                }
            }
            scenicScore *= treeCount;
            treeCount = 0;
            //left
            for (int i = column - 1; i >= 0; i--)
            {
                treeCount++;
                if (forest[row, column] <= forest[row, i])
                {
                    break;
                }
            }
            scenicScore *= treeCount;
            treeCount = 0;

            //right
            for (int i = column + 1; i <= columns - 1; i++)
            {
                treeCount++;
                if (forest[row, column] <= forest[row, i])
                {
                    break;
                }
            }
            return scenicScore* treeCount;
        }

    }
}

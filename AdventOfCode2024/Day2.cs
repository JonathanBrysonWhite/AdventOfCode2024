using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal class Day2
    {
        List<List<int>> levels;
        public Day2(string input)
        {
            levels = new List<List<int>>();
            string[] lines = input.Split("\r\n");
            foreach( string line in lines)
            {
                List<int> level = new List<int>();
                string[] levelValues = line.Split(' ');
                foreach(string levelValue in levelValues)
                {
                    level.Add(int.Parse(levelValue));
                }
                levels.Add(level);
            }
        }

        public void Solve1()
        {
            int safeLevels = 0;
            foreach(List<int> level in levels)
            {
                if (IsSafe(level))
                    safeLevels++;
            }
            Console.WriteLine(safeLevels);
        }

        public void Solve2()
        {
            int safeLevels = 0;
            foreach(List<int> level in levels)
            {
                if (IsSafe(level))
                {
                    safeLevels++;
                }
                else
                {
                    for(int i = 0; i < level.Count; i++)
                    {
                        List<int> temp = new List<int>(level);
                        temp.RemoveAt(i);
                        if(IsSafe(temp))
                        {
                            safeLevels++;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(safeLevels);
        }

        private bool IsSafe(List<int> level)
        {
            bool increasing = level[1] > level[0];
            for (int i = 0; i < level.Count - 1; i++)
            {
                if (increasing)
                {
                    if (level[i + 1] - level[i] < 1 || level[i + 1] - level[i] > 3)
                        return false;
                }

                else
                {
                    if (level[i] - level[i + 1] < 1 || level[i] - level[i + 1] > 3)
                        return false;
                }

            }
            return true;
        }
    }
}

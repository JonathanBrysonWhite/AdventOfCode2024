using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal class Day9
    {
        private List<string>fileBlock;
        public Day9(string input)
        {
            fileBlock = new List<string>();
            int i = 0;
            int id = 0;
            foreach(char c in input)
            {
                int blockSize = (int)char.GetNumericValue(c);
                if(i % 2 == 1)
                {
                    List<string> freeSpace = Enumerable.Repeat(".", blockSize).ToList();
                    fileBlock.AddRange(freeSpace);
                    i++;
                }
                else
                {
                    List<string> fileToAdd = Enumerable.Repeat(id.ToString(), blockSize).ToList();
                    fileBlock.AddRange(fileToAdd);
                    i++;
                    id++;
                }
            }
            Console.WriteLine("test");
        }
    }
}

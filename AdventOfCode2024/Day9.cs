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
        }

        public void Solve1()
        {
            int i = fileBlock.Count - 1;
            while(i >= 0)
            {
                string  currentData = fileBlock[i];
                if (currentData != ".")
                {
                    int firstEmptySpotPtr = fileBlock.IndexOf(".");
                    if(firstEmptySpotPtr < i)
                    {
                        fileBlock[firstEmptySpotPtr] = currentData;
                        fileBlock[i] = ".";
                    }
                }
                i--;
            }
            long rVal = 0;
            for(i = 0; i < fileBlock.Count; i++)
            {
                string fileData = fileBlock[i];
                if (fileData.Equals("."))
                {
                    continue;
                }
                rVal += int.Parse(fileData) * i;
            }
            Console.WriteLine(rVal);
        }
    }
}

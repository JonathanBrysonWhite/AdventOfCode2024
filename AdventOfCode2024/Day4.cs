using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal class Day4
    {
        List<List<char>> wordSearch;
        public Day4(string input)
        {
            wordSearch = new List<List<char>>();
            string[] lines = input.Split("\r\n");
            foreach (string line in lines)
            {
                List<char> searchLine = new List<char>();
                foreach (char c in line)
                {
                    searchLine.Add(c);
                }
                wordSearch.Add(searchLine);
            }
        }

        public void Solve2()
        {
            int hits = 0;
            for(int i = 0; i < wordSearch[0].Count; i++)
            {
                for(int j = 0; j < wordSearch.Count; j++)
                {
                    if(i > 0 && i < wordSearch[0].Count - 1 && j > 0 && j < wordSearch.Count - 1 && wordSearch[i][j] == 'A')
                    {
                        bool backSlash = false;
                        bool forwardSlash = false;
                        // Check \ for 'M.S'
                        if (wordSearch[i - 1][j - 1] == 'M' && wordSearch[i + 1][j + 1] == 'S')
                        {
                            backSlash = true;
                        }
                        // Check \ for 'S.M'
                        else if (wordSearch[i - 1][j - 1] == 'S' && wordSearch[i + 1][j + 1] == 'M')
                        {
                            backSlash = true;
                        }
                        // Check / for 'M.S'
                        if (wordSearch[i + 1][j - 1] == 'M' && wordSearch[i - 1][j + 1] == 'S')
                        {
                            forwardSlash = true;
                        }
                        // Check / for 'S.M'
                        else if (wordSearch[i + 1][j - 1] == 'S' && wordSearch[i - 1][j + 1] == 'M')
                        {
                            forwardSlash = true;
                        }
                        if ( backSlash && forwardSlash)
                        {
                            hits++;
                        }
                    }
                }
            }
            Console.WriteLine(hits);
        }
        public void Solve1()
        {
            int hits = 0;
            for(int i = 0; i < wordSearch[0].Count; i++)
            {
                for(int j = 0; j < wordSearch.Count; j++)
                {
                    if (wordSearch[i][j] == 'X')
                    {
                        //check backwards
                        if(i >= 3 && wordSearch[i - 1][j] == 'M' && wordSearch[i - 2][j] == 'A' && wordSearch[i - 3][j] == 'S')
                        {
                            hits++;
                        }
                        //check up/left
                        if(j >= 3 && i >= 3 && wordSearch[i - 1][j - 1] == 'M' && wordSearch[i - 2][j - 2] == 'A' && wordSearch[i - 3][j - 3] == 'S')
                        {
                            hits++;
                        }
                        //check up
                        if (j >= 3 && wordSearch[i][j - 1] == 'M' && wordSearch[i][j - 2] == 'A' && wordSearch[i][j - 3] == 'S')
                        {
                            hits++;
                        }
                        //check up/right
                        if(j >= 3 && i < wordSearch[0].Count - 3 && wordSearch[i + 1][j - 1] == 'M' && wordSearch[i + 2][j - 2] == 'A' && wordSearch[i + 3][j - 3] == 'S')
                        {
                            hits++;
                        }
                        //check right
                        if(i < wordSearch[0].Count - 3 && wordSearch[i + 1][j] == 'M' && wordSearch[i + 2][j] == 'A' && wordSearch[i + 3][j] == 'S')
                        {
                            hits++;
                        }
                        //check down/right
                        if(i < wordSearch[0].Count - 3 && j < wordSearch.Count - 3 && wordSearch[i + 1][j + 1] == 'M' && wordSearch[i + 2][j + 2] == 'A' && wordSearch[i + 3][j + 3] == 'S')
                        {
                            hits++;
                        }
                        //check down
                        if(j < wordSearch.Count - 3 && wordSearch[i][j + 1] == 'M' && wordSearch[i][j + 2] == 'A' && wordSearch[i][j + 3] == 'S')
                        {
                            hits++;
                        }
                        //check down/left
                        if(i >= 3 && j < wordSearch.Count - 3 && wordSearch[i - 1][j + 1] == 'M' && wordSearch[i - 2][j + 2] == 'A' && wordSearch[i - 3][j + 3] == 'S')
                        {
                            hits++;
                        }
                    }
                }
            }
            Console.WriteLine(hits);
        }
    }
}

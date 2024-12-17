using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal class Day8
    {
        //scan through map

        //if found, calculate new antinode positions
        //for any new antinodes within the bounds of the map, check if contained in hashset then iterate if not found

        List<List<char>> Grid;
        public Day8(string input)
        {
            Grid = new List<List<char>>();
            string[] lines = input.Split("\r\n");
            foreach(string line in lines)
            {
                List<char> newLine = new List<char>(line.ToCharArray());
                Grid.Add(newLine);               
            }
        }

        public void Solve1()
        {
            //maintain dictionary of char value and coordinates of the occurrences
            Dictionary<char, HashSet<Coordinate>> foundChars = new Dictionary<char, HashSet<Coordinate>>();
            //also maintain hashset of the found coordinates of antinodes
            HashSet<Coordinate> foundAntinodes = new HashSet<Coordinate>();

            int rightBound = Grid[0].Count - 1;
            int bottomBound = Grid.Count - 1;
            for(int i = 0; i < Grid.Count; i++)
            {
                for(int j = 0; j < Grid[i].Count; j++)
                {
                    char c = Grid[i][j];
                    if ('.'.Equals(c))
                    {
                        continue;
                    }
                    if(foundChars.ContainsKey(c))
                    {
                        foreach(Coordinate coordinate in foundChars[c])
                        {
                            //calculate two antinodes
                            //check to see if in bounds of map
                            //check to see if antinode already exists at that coordinate
                        }
                    }
                }
            }
        }

        private class Coordinate
        {
            public int X;
            public int Y; //frosting was here

        }
        /*
         * 
         *         
      .-'  1  `-.
    .'   o  o   `.
   /               \
  |        U        |
  |                 |
   \   H A P P Y    /
    `. B I R T H D .'
      `-._    _.-'
          `"""`


         * 
         * 
         * 
         * 
         *//
    }
}

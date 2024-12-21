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
                    if (foundChars.ContainsKey(c))
                    {
                        foreach (Coordinate coordinate in foundChars[c])
                        {
                            //calculate two antinodes
                            int dx = coordinate.X - j;
                            int dy = coordinate.Y - i;

                            Coordinate antiNode1 = new Coordinate(coordinate.X + dx, coordinate.Y + dy);
                            Coordinate antiNode2 = new Coordinate(j - dx, i - dy);

                            //check to see if in bounds of map
                            //check to see if antinode already exists at that coordinate
                            if (antiNode1.X >= 0 && antiNode1.X <= rightBound && antiNode1.Y >= 0 && antiNode1.Y <= bottomBound)
                            {
                                foundAntinodes.Add(antiNode1);
                            }
                            if (antiNode2.X >= 0 && antiNode2.X <= rightBound && antiNode2.Y >= 0 && antiNode2.Y <= bottomBound)
                            {
                                foundAntinodes.Add(antiNode2);
                            }
                        }
                        foundChars[c].Add(new Coordinate(j, i));
                    }
                    else
                    {
                        foundChars[c] = new HashSet<Coordinate> { new Coordinate(j, i) };
                    }
                }
            }
            Console.WriteLine(foundAntinodes.Count);
        }


        public void Solve2()
        {
            //maintain dictionary of char value and coordinates of the occurrences
            Dictionary<char, HashSet<Coordinate>> foundChars = new Dictionary<char, HashSet<Coordinate>>();
            //also maintain hashset of the found coordinates of antinodes
            HashSet<Coordinate> foundAntinodes = new HashSet<Coordinate>();

            int rightBound = Grid[0].Count - 1;
            int bottomBound = Grid.Count - 1;
            for (int i = 0; i < Grid.Count; i++)
            {
                for (int j = 0; j < Grid[i].Count; j++)
                {
                    char c = Grid[i][j];
                    if ('.'.Equals(c))
                    {
                        continue;
                    }
                    if (foundChars.ContainsKey(c))
                    {
                        foreach (Coordinate coordinate in foundChars[c])
                        {
                            //calculate two antinodes
                            int dx = coordinate.X - j;
                            int dy = coordinate.Y - i;


                            int greatestCommonDenominator = gcd(dx, dy);
                            dx = dx / greatestCommonDenominator;
                            dy = dy / greatestCommonDenominator;

                            int x1 = coordinate.X;
                            int y1 = coordinate.Y;
                            foundAntinodes.Add(new Coordinate(x1, y1));
                            while(x1 >= 0 && x1 <= rightBound && y1 >= 0 && y1 <= bottomBound)
                            {
                                foundAntinodes.Add(new Coordinate(x1, y1));
                                x1 += dx;
                                y1 += dy;
                            }
                            int x2 = coordinate.X;
                            int y2 = coordinate.Y;
                            
                            while(x2 >= 0 && x2 <= rightBound && y2 >= 0 && y2 <= bottomBound)
                            {
                                foundAntinodes.Add(new Coordinate(x2, y2));
                                x2 -= dx;
                                y2 -= dy;
                            }
      
                        }
                        foundChars[c].Add(new Coordinate(j, i));
                    }
                    else
                    {
                        foundChars[c] = new HashSet<Coordinate> { new Coordinate(j, i) };
                    }
                }
            }
            Console.WriteLine(foundAntinodes.Count);
        }

        private int gcd (int a, int b)
        {
            if (a == 0)
                return b;
            return gcd(b % a, a);
        }

        private class Coordinate
        {
            public override int GetHashCode()
            {
                string str = $"{X}{Y}";
                return int.Parse(str);
            }
            public override bool Equals(object? obj)
            {
                if(obj is Coordinate c)
                {
                    return X == c.X && Y == c.Y;
                }
                return false;
            }
            public Coordinate(int x, int y)
            {
                X = x;
                Y = y;
            }
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
         */
    }
}

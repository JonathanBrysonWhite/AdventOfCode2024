using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal class Day3
    {
        public Day3() { }

        public void Solve1(string input)
        {
            MatchCollection matches = Regex.Matches(input, "mul\\(\\d+,\\d+\\)");

            int total = 0;
            foreach(Match match in matches)
            {
                string expression = match.Value;
                total += Eval(expression);
            }
            Console.WriteLine(total);
        }

        public void Solve2(string input)
        {
            string buffer = "";
            string filteredString = "";
            bool doEnabled = true;
            foreach(char c in input)
            {
                //build buffer
                buffer += c;
                if(buffer.Contains("don't()"))
                {
                    doEnabled = false;
                    buffer = "";
                }
                if(buffer.Contains("do()"))
                {
                    doEnabled = true;
                    buffer = "";
                }

                if (doEnabled)
                    filteredString += c;
            }

            Solve1(filteredString);
        }

        public int Eval(string input)
        {
            string[] parts = input.Split(',');
            string num1 = parts[0].Replace("mul(", "");
            string num2 = parts[1].Replace(")", "");
            int n1 = int.Parse(num1);
            int n2 = int.Parse(num2);
            return n1 * n2;
        }
    }
}

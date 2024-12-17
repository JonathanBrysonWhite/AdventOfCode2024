using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal class Day1
    {
        private List<int> list1;
        private List<int> list2;
        public Day1(string input)
        {
            list1 = new List<int>();
            list2 = new List<int>();
            string[] lines = input.Split("\r\n");
            foreach(string line in lines)
            {
                string[] nums = line.Split("   ");
                list1.Add(int.Parse(nums[0]));
                list2.Add(int.Parse(nums[1]));
            }
            list1.Sort();
            list2.Sort();
        }


        public void Solve()
        {
            int diff = 0;
            for(int i = 0; i < list1.Count; i++)
            {
                diff += Math.Abs(list1[i] - list2[i]);
            }
            Console.WriteLine(diff);
        }

        public void Solve2()
        {
            int similarityScore = 0;
            foreach(int n in list1)
            {
                List<int> matches = list2.Where(num => num == n).ToList();
                similarityScore += matches.Count * n;
            }
            Console.WriteLine(similarityScore);
        }
    }
}

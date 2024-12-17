using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    internal class PageRule
    {
        public PageRule(string before, string after)
        {
            Before = int.Parse(before);
            After = int.Parse(after);
        }
        public int Before { get; set; }
        public int After { get; set; }
    }
    internal class Day5
    {
        public HashSet<PageRule> rules;
        public List<List<int>> updates;
        public Day5(string input)
        {
            rules = new HashSet<PageRule>();
            updates = new List<List<int>>();
            string buffer = "";
            foreach(char c in input)
            {
                buffer += c;
                if(buffer.EndsWith("\r\n") && buffer.Contains('|'))
                {
                    string[] intStrings = buffer.Split('|');
                    PageRule rule = new PageRule(intStrings[0], intStrings[1]);
                    rules.Add(rule);
                    buffer = "";
                }
                else if (buffer.EndsWith("\r\n") && buffer.Contains(','))
                {
                    List<int> update = new List<int>();
                    string[] intStrings = buffer.Split(',');
                    foreach(string str in intStrings)
                    {
                        update.Add(int.Parse(str));
                    }
                    updates.Add(update);
                    buffer = "";
                }
            }
        }

        public void Solve1()
        {
            int ans = 0;
            foreach(List<int> update in updates)
            {
                bool followsRules = true;
                List<PageRule> relevantRules = rules.Where(p => update.Contains(p.Before) && update.Contains(p.After)).ToList();
                foreach (PageRule rule in relevantRules)
                {
                    int beforeIndex = update.IndexOf(rule.Before);
                    int afterIndex = update.IndexOf(rule.After);
                    if(beforeIndex > afterIndex)
                    {
                        followsRules = false;
                        break;
                    }
                }
                if (followsRules)
                {
                    int mid = update.Count / 2;
                    ans += update[mid];
                }
            }
            Console.WriteLine(ans);
        }
    }
}

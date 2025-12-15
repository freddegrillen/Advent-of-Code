using System;
using System.Collections.Generic;
using System.Text;

namespace Day1
{
    internal static class Day7
    {
        public static void Execute()
        {
            List<string> rows = new();
            int splitCount = 0;

            string input = Console.ReadLine();
            while (input != "")
            {
                rows.Add(input);
                input = Console.ReadLine();
            }

            List<int> prevIndices = new();
            prevIndices.Add(rows[0].IndexOf('S'));

            for(int i = 1; i < rows.Count; i++)
            {
                List<int> provisional = prevIndices.ToList();
                foreach (var index in prevIndices)
                {
                    
                    if (rows[i][index] == '^')
                    {
                        provisional.Remove(index);
                        provisional.Add(index - 1);
                        provisional.Add(index + 1);
                        splitCount++;
                    }
                }
                prevIndices = provisional.Distinct().ToList();
                Console.WriteLine($"Row: {i} splitcount: {splitCount}");
            }
            Console.WriteLine(splitCount);

        }

    }
}

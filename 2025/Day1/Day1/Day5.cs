using System;
using System.Collections.Generic;
using System.Text;

namespace Day1
{

    internal class Range
    {
        internal Int64 from;
        internal Int64 to;
    }
    internal static class Day5
    {
        internal static void Execute()
        {
            int freshCount = 0;
            List<Range> ranges = new();
            List<Int64> ingredientIds = new();


            string input = Console.ReadLine();
            while (input != "")
            {
                var nums = input.Split('-');
                ranges.Add(new Range { from = Int64.Parse(nums[0]), to = Int64.Parse(nums[1]) });
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "")
            {
                ingredientIds.Add(Int64.Parse(input));
                input = Console.ReadLine();
            }

            var fresh = ingredientIds.Where(x => ranges.Where(r => r.from <= x && r.to >= x).Any()).ToList();
            Console.WriteLine(fresh.Count);
            
        }
    }    
}

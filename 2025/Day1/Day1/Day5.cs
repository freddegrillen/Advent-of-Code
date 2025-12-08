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
            Int64 freshCount = 0;
            List<Range> ranges = new();
            //List<Int64> ingredientIds = new();


            string input = Console.ReadLine();
            while (input != "")
            {
                var nums = input.Split('-');
                ranges.Add(new Range { from = Int64.Parse(nums[0]), to = Int64.Parse(nums[1]) });
                input = Console.ReadLine();
            }
            //input = Console.ReadLine();
            //while (input != "")
            //{
            //    ingredientIds.Add(Int64.Parse(input));
            //    input = Console.ReadLine();
            //}

            //var fresh = ingredientIds.Where(x => ranges.Where(r => r.from <= x && r.to >= x).Any()).ToList();
            //Console.WriteLine(fresh.Count);
            ranges = ranges.OrderBy(x => x.from).ToList();
            ranges = MergeRanges(ranges);
   

            foreach (Range range in ranges)
            {
                Console.WriteLine($"From:{range.from} - To: {range.to}");
                freshCount += (range.to - range.from + 1);
            }
            Console.WriteLine( freshCount);
            
        }

        private static List<Range> MergeRanges( List<Range> ranges)
        {
            if (ranges.Count <= 1) return ranges;

            List<Range> temp = new();

            if (ranges[0].to >= ranges[1].from)
            {
                if (ranges[0].to > ranges[1].to)
                {
                    ranges.RemoveAt(1);
                    return MergeRanges(ranges);
                }

                temp.Add(new Range { from = ranges[0].from, to = ranges[1].to });

                temp.AddRange(ranges.GetRange(2, ranges.Count - 2));
                return MergeRanges(temp);
            }
            else
            {
                temp.Add(ranges[0]);
                temp.AddRange(MergeRanges(ranges.GetRange(1,ranges.Count-1)));
                return temp;
            }

        }
    }    
}

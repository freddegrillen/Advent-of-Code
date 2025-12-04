using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Day1
{
    internal static class Day2
    {
        internal static void Execute()
        {
            Int64 result = 0;
            string input = Console.ReadLine();
            var spans = input.Split(',');
            foreach ( var s in spans)
            {
                var stringSpan = s.Split("-");

                Int64 from = Int64.Parse(stringSpan[0]);
                Int64 to = Int64.Parse(stringSpan[1]);

                for (Int64 i = from; i <= to; i++)
                {
                    var iString = i.ToString();
                    if (Regex.IsMatch(iString, "^(.+)\\1+$"))
                    {
                        result += i;
                    }
                }
            }
            Console.WriteLine(result);
        }

    }
}

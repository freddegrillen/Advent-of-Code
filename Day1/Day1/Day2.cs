using System;
using System.Collections.Generic;
using System.Text;

namespace Day1
{
    internal static class Day2
    {
        internal static void Execute()
        {
            Int64 result = 0;
            string input = Console.ReadLine();
            var strings = input.Split(',');
            foreach ( var s in strings)
            {
                var stringSpan = s.Split("-");

                Int64 from = Int64.Parse(stringSpan[0]);
                Int64 to = Int64.Parse(stringSpan[1]);

                for (Int64 i = from; i <= to; i++)
                {
                    var iString = i.ToString();
                    if (iString.Length % 2 == 0)
                    {
                        int half = (iString.Length / 2);

                        if(iString.Substring(0,half) == iString.Substring(half))
                        {
                            result += i;
                        }

                    }
                }
            }
            Console.WriteLine(result);
        }

    }
}

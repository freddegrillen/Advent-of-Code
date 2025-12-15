using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;

namespace Day1
{
    internal class Day7
    {
        private readonly IMemoryCache _memoryCache;

        public Day7(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Execute()
        {
            List<string> rows = new();
            Int64 splitCount = 1;

            string input = Console.ReadLine();
            while (input != "")
            {
                rows.Add(input);
                input = Console.ReadLine();
            }

            int index = rows[0].IndexOf('S');
            splitCount += Calculate(rows, index);

            Console.WriteLine(splitCount);

        }

        private Int64 Calculate(List<string> rows, int index)
        {
            var hash = (rows.Count, index).GetHashCode();
            if (_memoryCache.TryGetValue(hash, out long stored))
            {
                return stored;
            }

            if (rows.Count == 0)
            {
                return 0;
            }


            var next = rows.TakeLast(rows.Count - 1).ToList();
            if (rows[0][index] == '^')
            {
                var splits = Calculate(next, index + 1) + Calculate(next, index - 1) + 1;
                _memoryCache.Set(hash, splits);
                return splits;
            }
            else
            {
                var splits = Calculate(next, index);
                _memoryCache.Set(hash, splits);
                return splits;
            }
        }

    }
}
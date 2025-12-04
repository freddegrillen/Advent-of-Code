using System;
using System.Collections.Generic;
using System.Text;

namespace Day1
{
    internal static class Day3
    {

        internal static void Execute()
        {
            int total = 0;
            List<string> banks = new();

            string input = Console.ReadLine();
            while(input != "")
            {
                banks.Add(input);
                input = Console.ReadLine();
            }

           foreach(string bank in banks)
            {
                var fstIndex = bank.IndexOf(bank.Substring(0, bank.Length - 1).Max());
                var fstMax = bank[fstIndex];
                var sndMax = bank.Substring(fstIndex + 1,bank.Length - (fstIndex + 1)).Max();
                int maxJolt = int.Parse(string.Concat(fstMax, sndMax));
                total += maxJolt;
                Console.WriteLine($"Maxjolt: {maxJolt}");
            }

            Console.WriteLine($" Final total: {total}");


        }
    }
}

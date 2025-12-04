using System;
using System.Collections.Generic;
using System.Text;

namespace Day1
{
    internal static class Day3
    {

        internal static void Execute()
        {
            Int64 total = 0;
            List<string> banks = new();

            string input = Console.ReadLine();
            while(input != "")
            {
                banks.Add(input);
                input = Console.ReadLine();
            }

           foreach(string bank in banks)
            {
                var prevIndex = -1;
                string bankMax = "";
                for(int i = 12; i > 0; i--)
                {
                    var available = bank.Substring(prevIndex + 1, bank.Length - (i + prevIndex));
                    //var fstIndex = available.IndexOf(available.Max()) + (i == 12 ? 0:prevIndex);
                    var fstIndex = available.IndexOf(available.Max()) + (prevIndex + 1);
                    var fstMax = bank[fstIndex];
                    bankMax += fstMax;
                    prevIndex = fstIndex;
                }



               
                total += Int64.Parse(bankMax);
                Console.WriteLine($"BankMax: {bankMax}");
            }

            Console.WriteLine($" Final total: {total}");


        }
    }
}

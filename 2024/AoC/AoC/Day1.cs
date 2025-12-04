using System;
using System.Collections.Generic;
using System.Text;

namespace AoC
{
    internal static class Day1
    {
        internal static void Execute()
        {
            List<int> firstList = new();
            List<int> secondList = new();
            int total = 0;

            var input = Console.ReadLine();

            while (input != "")
            {
                var inputs = input.Split("   ");
                firstList.Add(int.Parse(inputs[0]));
                secondList.Add(int.Parse(inputs[1]));
                input = Console.ReadLine();
            }

            firstList.Sort();
            secondList.Sort();

            for(int i = 0; i < firstList.Count; i++)
            {
                //int diff = int.Abs(secondList[i] - firstList[i]);
                //total += diff;
                //Console.WriteLine($"Fst: {firstList[i]} Snd:{secondList[i]} Difference:{diff}");


                int count = secondList.Select(x => x).Where(y => y == firstList[i]).Count();
                total += (firstList[i] * count);

            }
            Console.WriteLine(total);


        }
    }
}

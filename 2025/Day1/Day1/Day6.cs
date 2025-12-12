using System;
using System.Collections.Generic;
using System.Text;

namespace Day1
{
    internal static class Day6
    {
        internal static void Execute()
        {
            List<List<string>> inputLists = new();
            Int64 finalResult = 0;

            string input = Console.ReadLine();
            while (input != "")
            {
                var list = input.Split(' ').ToList();
                list = list.Where(x => !string.IsNullOrEmpty(x)).ToList();
                inputLists.Add(list);
                input = Console.ReadLine();
            }

            List<string> operations = inputLists.Last();
            inputLists.RemoveAt(inputLists.Count - 1);

            for(int i  = 0; i < operations.Count; i++)
            {
                Int64 result;
                if (operations[i] == "+")
                {
                    result = 0;
                    foreach(var row in inputLists)
                    {
                        result += Int64.Parse(row[i]);
                    }
                    finalResult += result;
                }
                else
                {
                    result = 1;
                    foreach (var row in inputLists)
                    {
                        result *= Int64.Parse(row[i]);
                    }
                    finalResult += result;

                }

            }
            Console.WriteLine(finalResult);




        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Day1
{
    internal static class Day6
    {
        internal static void Execute()
        {
            List<string> inputStrings = new();
            Int64 finalResult = 0;

            string input = Console.ReadLine();
            while (input != "")
            {
                inputStrings.Add(input);
                input = Console.ReadLine();
            }

            string operations = inputStrings.Last();
            inputStrings.RemoveAt(inputStrings.Count - 1);

            List<string> numbers = new();
            for (int i  = operations.Length - 1; i >= 0 ; i--)
            {
                
                Int64 result = 0;

                string current = "";
                foreach(var row in inputStrings)
                {
                    current += row[i];

                }
                if (!string.IsNullOrEmpty(current.Trim()))
                {
                    numbers.Add(current);
                }               

                if (operations[i] == '+')
                {
                    foreach (var number in numbers)
                    {
                        result += Int64.Parse(number);
                    }
                    Console.WriteLine($"result: {result}");
                    finalResult += result;
                    numbers.Clear();
                }
                else if (operations[i] == '*')
                {
                    result = 1;
                    foreach (var number in numbers)
                    {                       
                        result *= Int64.Parse(number);
                    }
                    Console.WriteLine($"result: {result}");
                    finalResult += result;
                    numbers.Clear();
                }

            }
            Console.WriteLine(finalResult);




        }

    }
}

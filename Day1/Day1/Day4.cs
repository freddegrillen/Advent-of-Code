using System;
using System.Collections.Generic;
using System.Text;

namespace Day1
{
    internal static class Day4
    {
        internal static void Execute()
        {
            int total = 0;
            List<string> rows = new();
            List<string> debugIllustration = new();

            string input = Console.ReadLine();
            while (input != "")
            {
                rows.Add(input);
                input = Console.ReadLine();
            }

            for(int row = 0; row < rows.Count; row++)
            {
                int current = 0; // for debug
                string rowIllsustration = "";

                for(int roll = 0; roll < rows[row].Length; roll++)
                {
                    if (rows[row][roll] != '@')
                    {
                        rowIllsustration += '.';
                        continue;
                    }
                    int adjacent = -1; //-1 to only count adjacent, removes current roll.

                    if (row != 0)
                    {
                        adjacent += CountRolls(GetSubString(row - 1, roll, rows));
                    }

                    adjacent += CountRolls(GetSubString(row, roll, rows));

                    if (row != rows.Count -1)
                    {
                        adjacent += CountRolls(GetSubString(row + 1, roll, rows));
                    }

                    if(adjacent < 4)
                    {
                        rowIllsustration += "X";
                        total++;
                        current++;
                    }
                    else
                    {
                        rowIllsustration += "@";
                    }

                }
                //debugIllustration.Add(rowIllsustration);
                Console.WriteLine($"{rowIllsustration} - {current}");
                //Console.WriteLine($"Row: {row +1} - available: {current}");
            }

            Console.WriteLine($"Total: {total}");

        }

        private static string GetSubString(int row, int roll, List<string> rows)
        {
            return rows[row].Substring((roll == 0 ? 0 : roll - 1), ((roll == 0 || roll == rows[row].Length - 1) ? 2 : 3));
        }

        private static int CountRolls(string input)
        {
            return input.Where(c => c == '@').Count();
        }
    }
}

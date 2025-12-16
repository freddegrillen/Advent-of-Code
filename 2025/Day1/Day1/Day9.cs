using System;
using System.Collections.Generic;
using System.Text;

namespace Day1
{
    internal class Tile
    {
        public int row;
        public int column;
    }
    internal class Area
    {
        public Tile tile1;
        public Tile tile2;
        public long area;

    }
    internal static class Day9
    {
        public static void Execute()
        {
            List<Tile> tiles = new();

            string input = Console.ReadLine();
            while (input != "")
            {
                var coords = input.Split(',');
                tiles.Add(new Tile {row = int.Parse(coords[0]), column = int.Parse(coords[1])});
                input = Console.ReadLine();
            }

            Area largestArea = GetArea(tiles[0], tiles[1]);
            for(int i = 1; i < tiles.Count; i++)
            {
                for(int j = i+1;  j < tiles.Count; j++)
                {
                    var area = GetArea(tiles[i], tiles[j]);
                    if (area.area > largestArea.area)
                    {
                        largestArea = area;
                    }
                }
            }

            Console.WriteLine(largestArea.area);




        }

        private static Area GetArea(Tile tile1, Tile tile2)
        {
            long area = (long)(Math.Abs(tile1.row - tile2.row) + 1) * (long)(Math.Abs(tile1.column - tile2.column) +1);
            return new Area
            {
                tile1 = tile1,
                tile2 = tile2,
                area = area
            };
        }
    }
}

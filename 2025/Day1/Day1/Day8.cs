using System;
using System.Collections.Generic;
using System.Text;

namespace Day1
{
    internal class Box
    {
        public int id;
        public int x;
        public int y;
        public int z;
    }
    internal class Distance
    {
        public Box box1;
        public Box box2;
        public double distance;
    }
    internal class Connection
    {
        public Box box1;
        public Box box2;
    }
    internal class Circuit
    {
        public List<Box> boxes;
    }


    internal static class Day8
    {
        public static void Execute()
        {
            List<Box> boxes = new();
            int id = 0;

            string input = Console.ReadLine();
            while (input != "")
            {
                var coords = input.Split(',');
                boxes.Add(new Box { id = id, x = int.Parse(coords[0]), y = int.Parse(coords[1]), z = int.Parse(coords[2]), });
                id++;
                input = Console.ReadLine();
            }

            List<Distance> distances = new();
            for(int i = 0; i < boxes.Count ; i++)
            {
                for(int j = i+1; j < boxes.Count; j++)
                {
                    distances.Add(GetDistance(boxes[i], boxes[j]));
                }
            }

            distances = distances.OrderBy(dist => dist.distance).Take(1000).ToList(); //Take 10 for example data

            List<Circuit> circuits = new();
            foreach(var box in boxes)
            {
                circuits.Add(new Circuit { boxes = new List<Box> { box } });
            }


            foreach(var distance in distances)
            {
                var matches = circuits.Where(c => c.boxes.Contains(distance.box1) || c.boxes.Contains(distance.box2)).ToList();

                if(matches.Count == 2)
                {
                    circuits = circuits.Where(c => !(c.boxes.Contains(distance.box1) || c.boxes.Contains(distance.box2))).ToList();
                    var merged = matches[0].boxes.Union(matches[1].boxes).ToList();
                    circuits.Add(new Circuit { boxes = merged });
                }

               
            }

            var chosen = circuits.OrderByDescending(c => c.boxes.Count).ToList().Take(3);

            Int64 result = 1;
            foreach(var circ in chosen)
            {
                result *= circ.boxes.Count;
            }
            Console.WriteLine( result);

        }

        private static Distance GetDistance(Box box1, Box box2)
        {
            var delta = (Math.Pow((box1.x - box2.x), 2) + Math.Pow((box1.y - box2.y), 2) + Math.Pow((box1.z - box2.z), 2));
            return new Distance
            {
                box1 = box1,
                box2 = box2,
                distance = Math.Sqrt(delta)
            };
        }
    }
}

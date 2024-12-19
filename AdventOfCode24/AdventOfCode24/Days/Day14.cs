using AdventOfCode24.Interfaces;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace AdventOfCode24.Days
{
    internal class Day14 : IDay
    {
        private readonly string[] input;
        private readonly List<(int x, int y, int vx, int vy)> robots = [];
        private readonly Dictionary<(int, int), int> newRobs = [];
        private readonly int gridX = 101;
        private readonly int gridY = 103;

        public Day14()
        {
            input = File.ReadAllLines("input14-2024.txt");
            Parse();
        }

        private void Parse()
        {
            string pattern = @"p=(\d+),(\d+) v=(\-?\d+),(\-?\d+)";

            foreach (string line in input)
            {
                Match match = Regex.Match(line, pattern);

                if (match.Success)
                {
                    int x = int.Parse(match.Groups[1].Value);
                    int y = int.Parse(match.Groups[2].Value);
                    int vx = int.Parse(match.Groups[3].Value);
                    int vy = int.Parse(match.Groups[4].Value);

                    robots.Add((x, y, vx, vy));
                }

            }
        }

        public void Part1()
        {
            int seconds = 100;

            foreach (var (x, y, vx, vy) in robots)
            {
                int newY = y + vy * seconds;
                int newX = x + vx * seconds;

                while (newY >= gridY)
                {
                    newY -= gridY;
                }
                while (newX >= gridX)
                {
                    newX -= gridX;
                }
                while (newY < 0)
                {
                    newY += gridY;
                }
                while (newX < 0)
                {
                    newX += gridX;
                }

                if (newRobs.ContainsKey((newY, newX)))
                {
                    newRobs[(newY, newX)]++;
                }
                else
                {
                   newRobs[(newY, newX)] = 1;
                }
            }

            int Q1 = 0;
            int Q2 = 0;
            int Q3 = 0;
            int Q4 = 0;

            foreach (var entry in newRobs)
            {
                

                var (y, x) = entry.Key;
                int value = entry.Value;


                if (y >= 0 && y < (gridY - 1) / 2 && x >= 0 && x < ((gridX - 1) / 2))
                {
                    Q1 += value;
                }
                else if (y >= 0 && y < (gridY - 1) / 2 && x > ((gridX - 1) / 2) && x < gridX)
                {
                    Q2 += value;
                }
                else if (y > (gridY - 1) / 2 && y < gridY && x >= 0 && x < ((gridX - 1) / 2))
                {
                    Q3 += value;
                }
                else if (y > (gridY - 1) / 2 && y < gridY && x > ((gridX - 1) / 2) && x < gridX)
                {
                    Q4 += value;
                }
            }

            Console.WriteLine($"Day 14 Part 1 answer: {Q1 * Q2 * Q3 * Q4}");
        }

        public void Part2()
        {
            int seconds = 7132;

            foreach (var (x, y, vx, vy) in robots)
            {
                int newY = y + vy * seconds;
                int newX = x + vx * seconds;

                while (newY >= gridY)
                {
                    newY -= gridY;
                }
                while (newX >= gridX)
                {
                    newX -= gridX;
                }
                while (newY < 0)
                {
                    newY += gridY;
                }
                while (newX < 0)
                {
                    newX += gridX;
                }

                if (newRobs.ContainsKey((newY, newX)))
                {
                    newRobs[(newY, newX)]++;
                }
                else
                {
                    newRobs[(newY, newX)] = 1;
                }
            }
            //for (int y = 0; y < gridY; y++)
            //{
            //    for (int x = 0; x < gridX; x++)
            //    {
            //        if (newRobs.ContainsKey((y, x)))
            //        {
            //            Console.Write("# ");
            //        }
            //        else { Console.Write(". "); }
            //    }
            //    Console.WriteLine();
            //}

            Console.WriteLine($"Day 14 Part 2 answer: {seconds}");
        }

        //Helper methods:
    }
}

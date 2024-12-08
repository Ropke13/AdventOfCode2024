using AdventOfCode24.Interfaces;
using System.Collections.Generic;
using System.IO;
using System;

namespace AdventOfCode24.Days
{
    internal class Day8 : IDay
    {
        private readonly string[] input;

        public Day8()
        {
            input = File.ReadAllLines("input8-2024.txt");
        }

        public void Part1()
        {
            var uniquePositions = new HashSet<string>();

            for (int y = 0; y < input.Length; y++)
            {
                for (int x = 0; x < input[y].Length; x++)
                {
                    if (input[y][x] == '.') continue;

                    char antenna = input[y][x];

                    for (int otherY = 0; otherY < input.Length; otherY++)
                    {
                        for (int otherX = 0; otherX < input[otherY].Length; otherX++)
                        {
                            if (antenna != input[otherY][otherX] || (otherY == y && otherX == x)) continue;

                            int deltaY = otherY - y;
                            int deltaX = otherX - x;

                            int newY = otherY + deltaY;
                            int newX = otherX + deltaX;

                            if (IsValidPosition(newY, newX))
                            {
                                uniquePositions.Add($"{newY}|{newX}");
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Day 8 Part 1 answer: {uniquePositions.Count}");
        }

        public void Part2()
        {
            var uniquePositions = new HashSet<string>();

            for (int y = 0; y < input.Length; y++)
            {
                for (int x = 0; x < input[y].Length; x++)
                {
                    if (input[y][x] == '.') continue;

                    char antenna = input[y][x];

                    for (int otherY = 0; otherY < input.Length; otherY++)
                    {
                        for (int otherX = 0; otherX < input[otherY].Length; otherX++)
                        {
                            if (antenna != input[otherY][otherX] || (otherY == y && otherX == x)) continue;

                            uniquePositions.Add($"{y}|{x}");

                            int deltaY = otherY - y;
                            int deltaX = otherX - x;

                            int newY = otherY + deltaY;
                            int newX = otherX + deltaX;

                            while (IsValidPosition(newY, newX))
                            {
                                uniquePositions.Add($"{newY}|{newX}");
                                newY += deltaY;
                                newX += deltaX;
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Day 8 Part 2 answer: {uniquePositions.Count}");
        }

        //Helper methods:
        private bool IsValidPosition(int y, int x)
        {
            return y >= 0 && y < input.Length && x >= 0 && x < input[0].Length;
        }
    }
}

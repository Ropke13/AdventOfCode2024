using AdventOfCode24.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode24.Days
{
    internal class Day9 : IDay
    {
        private readonly string input;
        private readonly List<int> Disk;

        public Day9()
        {
            input = File.ReadAllText("input9-2024.txt");
            Disk = ParseInput(input);
        }

        private static List<int> ParseInput(string input)
        {
            var disk = new List<int>();
            int index = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int value = int.Parse(input[i].ToString());
                if (i % 2 == 0)
                {
                    disk.AddRange(Enumerable.Repeat(index++, value));
                }
                else
                {
                    disk.AddRange(Enumerable.Repeat(-1, value));
                }
            }

            return disk;
        }

        public void Part1()
        {
            var diskCopy = Disk.ToList();
            long sum = 0;

            for (int i = diskCopy.Count - 1; i >= 0; i--)
            {
                int selected = diskCopy[i];
                if (selected == -1) continue;

                diskCopy[i] = -1;

                for (int j = 0; j < diskCopy.Count; j++)
                {
                    if (diskCopy[j] == -1)
                    {
                        diskCopy[j] = selected;
                        break;
                    }
                }
            }

            sum = diskCopy
                .TakeWhile(val => val != -1)
                .Select((val, idx) => (long)idx * val)
                .Sum();

            Console.WriteLine($"Day 9 Part 1 answer: {sum}");
        }

        public void Part2()
        {
            long sum = 0;
            int maxNumber = Disk.Max();

            for (int currentNumber = maxNumber; currentNumber > 0; currentNumber--)
            {
                int count = Disk.Count(n => n == currentNumber);

                int index = FindFirstValidSlot(Disk, count);
                if (index >= 0)
                {
                    ReplaceDiskValues(Disk, currentNumber, index, count);
                }
            }

            sum = Disk
                .Select((val, idx) => val == -1 ? 0 : (long)idx * val)
                .Sum();

            Console.WriteLine($"Day 9 Part 2 answer: {sum}");
        }

        private static int FindFirstValidSlot(List<int> disk, int count)
        {
            for (int i = 0; i <= disk.Count - count; i++)
            {
                if (disk.Skip(i).Take(count).All(x => x == -1))
                {
                    return i;
                }
            }
            return -1;
        }

        private static void ReplaceDiskValues(List<int> disk, int value, int startIndex, int count)
        {
            for (int i = 0; i < disk.Count; i++)
            {
                if (disk[i] == value)
                {
                    disk[i] = -1;
                }
            }

            for (int i = 0; i < count; i++)
            {
                disk[startIndex + i] = value;
            }
        }
    }
}

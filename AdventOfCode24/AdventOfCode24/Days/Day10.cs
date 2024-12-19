using AdventOfCode24.Interfaces;

namespace AdventOfCode24.Days
{
    internal class Day10 : IDay
    {
        private readonly string[] input;
        private HashSet<(int x, int y)> score = [];
        private readonly List<(int x, int y)> scorePart2 = [];

        public Day10()
        {
            input = File.ReadAllLines("input10-2024.txt");
        }

        public void Part1()
        {
            int sum = 0;
            for (int y = 0; y < input.Length; y++)
            {
                for(int x = 0; x < input[y].Length; x++) 
                { 
                    if (input[y][x] == '0')
                    {
                        BFS(y, x, 0);
                        sum += score.Count;
                        score = [];
                    }
                }
            }

            Console.WriteLine($"Day 10 Part 1 answer: {sum}");
        }

        public void Part2()
        {
            Console.WriteLine($"Day 10 Part 2 answer: {scorePart2.Count}");
        }

        //Helper methods:
        private void BFS(int y, int x, int step)
        {
            if (step == 9)
            {
                score.Add((y, x));
                scorePart2.Add((y, x));
                return;
            }

            step++;
            if (IsValidPosition(y + 1, x) && input[y + 1][x] == Char.Parse(step.ToString())) 
            {
                BFS(y + 1, x, step);
            }
            if (IsValidPosition(y - 1, x) && input[y - 1][x] == Char.Parse(step.ToString()))
            {
                BFS(y - 1, x, step);
            }
            if (IsValidPosition(y, x + 1) && input[y][x + 1] == Char.Parse(step.ToString()))
            {
                BFS(y, x + 1, step);
            }
            if (IsValidPosition(y, x - 1) && input[y][x - 1] == Char.Parse(step.ToString()))
            {
                BFS(y, x - 1, step);
            }

            return;
        }

        private bool IsValidPosition(int y, int x)
        {
            return y >= 0 && y < input.Length && x >= 0 && x < input[0].Length;
        }
    }
}

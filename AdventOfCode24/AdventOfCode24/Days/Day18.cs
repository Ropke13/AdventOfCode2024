using AdventOfCode24.Interfaces;

namespace AdventOfCode24.Days
{
    internal class Day18 : IDay
    {
        private readonly List<(int x, int y)> bytePositions;
        private const int GridSize = 70; // Adjusted to full problem scale.
        private readonly HashSet<(int, int)> corruptedMemory = new();
        private readonly (int x, int y) start = (0, 0);
        private readonly (int x, int y) end = (70, 70);

        public Day18()
        {
            var input = File.ReadAllLines("input18-2024.txt");
            bytePositions = input.Select(ParseCoordinate).ToList();
        }

        private static (int x, int y) ParseCoordinate(string line)
        {
            var parts = line.Split(',');
            return (int.Parse(parts[0]), int.Parse(parts[1]));
        }

        public void Part1()
        {
            SimulateBytesFalling(1024);
            int steps = FindShortestPath();
            Console.WriteLine($"Day 18 Part 1 answer: {steps}");
        }

        public void Part2()
        {
            SimulateBytesFalling(1024);

            for (int i = 1024; i < bytePositions.Count; i++)
            {
                corruptedMemory.Add(bytePositions[i]);
                int steps = FindShortestPath();
                if ( steps < 0 )
                {
                    Console.WriteLine($"Day 18 Part 2 answer:{bytePositions[i].x},{bytePositions[i].y}");
                    break;
                }
            }
            
        }

        private void SimulateBytesFalling(int count)
        {
            for (int i = 0; i < Math.Min(count, bytePositions.Count); i++)
            {
                corruptedMemory.Add(bytePositions[i]);
            }
        }

        private int FindShortestPath()
        {
            var directions = new[] { (0, 1), (1, 0), (0, -1), (-1, 0) }; // Right, Down, Left, Up
            var queue = new Queue<((int x, int y) position, int steps)>();
            var visited = new HashSet<(int, int)> { start };

            queue.Enqueue((start, 0));

            while (queue.Count > 0)
            {
                var (current, steps) = queue.Dequeue();

                if (current == end)
                    return steps;

                foreach (var (dx, dy) in directions)
                {
                    var next = (current.x + dx, current.y + dy);

                    if (IsValid(next) && !visited.Contains(next))
                    {
                        visited.Add(next);
                        queue.Enqueue((next, steps + 1));
                    }
                }
            }

            return -1; // No path found.
        }

        private bool IsValid((int x, int y) position)
        {
            return position.x >= 0 && position.x <= GridSize &&
                   position.y >= 0 && position.y <= GridSize &&
                   !corruptedMemory.Contains(position);
        }
    }
}

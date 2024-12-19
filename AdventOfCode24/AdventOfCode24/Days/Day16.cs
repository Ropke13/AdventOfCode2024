using AdventOfCode24.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode24.Days
{
    internal class Day16 : IDay
    {
        private readonly string[] input;
        private char[,]? maze;
        private (int x, int y) start;
        private (int x, int y) end;

        public Day16()
        {
            input = File.ReadAllLines("input16-2024.txt");
            Parse();
        }

        private void Parse()
        {
            int rows = input.Length;
            int cols = input[0].Length;
            maze = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    maze[r, c] = input[r][c];
                    if (maze[r, c] == 'S')
                        start = (c, r);
                    else if (maze[r, c] == 'E')
                        end = (c, r);
                }
            }
        }

        public void Part1()
        {
            int result = FindShortestPath();
            Console.WriteLine($"Day 16 Part 1 answer: {result}");
        }

        public void Part2()
        {
            //var bestPathTiles = FindTilesInBestPaths();
            Console.WriteLine($"Day 16 Part 2 answer: ");
        }


        private int FindShortestPath()
        {
            // Direction vectors: [0] = East, [1] = North, [2] = West, [3] = South
            (int dx, int dy)[] directions = [(1, 0), (0, -1), (-1, 0), (0, 1)];

            // Priority queue: (cost, x, y, direction)
            var pq = new PriorityQueue<(int cost, int x, int y, int dir), int>();
            var visited = new HashSet<(int x, int y, int dir)>();

            // Start at the initial position facing East (direction = 0)
            pq.Enqueue((0, start.x, start.y, 0), 0);

            while (pq.Count > 0)
            {
                var (cost, x, y, dir) = pq.Dequeue();

                // If reached the end, return the cost
                if ((x, y) == end)
                    return cost;

                // Skip if already visited
                if (visited.Contains((x, y, dir)))
                    continue;
                visited.Add((x, y, dir));

                // Try moving forward
                int nx = x + directions[dir].dx;
                int ny = y + directions[dir].dy;
                if (IsInBounds(nx, ny) && maze![ny, nx] != '#')
                {
                    pq.Enqueue((cost + 1, nx, ny, dir), cost + 1);
                }

                // Try rotating clockwise and counterclockwise
                for (int turn = -1; turn <= 1; turn += 2) // -1 for CCW, +1 for CW
                {
                    int newDir = (dir + turn + 4) % 4; // Ensure the direction wraps correctly
                    pq.Enqueue((cost + 1000, x, y, newDir), cost + 1000);
                }

                //for (int yy = 0; yy < maze.GetLength(1); yy++)
                //{
                //    for (int xx = 0; xx < maze.GetLength(0); xx++)
                //    {
                //        if (visited.Contains((xx, yy, 0)) || visited.Contains((xx, yy, 1)) || visited.Contains((xx, yy, 2)) || visited.Contains((xx, yy, 3))){
                //            Console.Write("O");
                //        }
                //        else { Console.Write(maze[yy,xx]); }
                //    }
                //    //Console.WriteLine();
                //}

                ////Console.ReadLine();
            }

            throw new InvalidOperationException("No path found to the target.");
        }

        private bool IsInBounds(int x, int y)
        {
            return x >= 0 && x < maze!.GetLength(1) && y >= 0 && y < maze!.GetLength(0);
        }
    }
}

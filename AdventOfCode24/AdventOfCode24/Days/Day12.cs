using AdventOfCode24.Interfaces;

namespace AdventOfCode24.Days
{
    internal class Day12 : IDay
    {
        private readonly string[] input;

        public Day12()
        {
            input = File.ReadAllLines("input11-2024.txt");
        }

        public void Part1()
        {
            int totalPrice = CalculateTotalPrice(input);
            Console.WriteLine($"Day 12 Part 1 answer: {totalPrice}");
        }

        public void Part2()
        {
            Console.WriteLine($"Day 12 Part 2 answer:");
        }

        // Helper methods
        private static int CalculateTotalPrice(string[] gardenMap)
        {
            int rows = gardenMap.Length;
            int cols = gardenMap[0].Length;
            bool[,] visited = new bool[rows, cols];
            int totalPrice = 0;

            int[] dRow = [-1, 1, 0, 0];
            int[] dCol = [0, 0, -1, 1];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (!visited[row, col])
                    {
                        char plantType = gardenMap[row][col];
                        var (area, perimeter) = CalculateAreaAndPerimeter(row, col, plantType);
                        int price = area * perimeter;
                        totalPrice += price;
                    }
                }
            }

            return totalPrice;

            (int, int) CalculateAreaAndPerimeter(int row, int col, char plantType)
            {
                int area = 0;
                int perimeter = 0;
                Queue<(int, int)> queue = new();
                queue.Enqueue((row, col));
                visited[row, col] = true;

                while (queue.Count > 0)
                {
                    var (curRow, curCol) = queue.Dequeue();
                    area++;

                    for (int i = 0; i < 4; i++)
                    {
                        int newRow = curRow + dRow[i];
                        int newCol = curCol + dCol[i];

                        if (newRow < 0 || newRow >= rows || newCol < 0 || newCol >= cols)
                        {
                            perimeter++;
                        }
                        else if (gardenMap[newRow][newCol] != plantType)
                        {
                            perimeter++;
                        }
                        else if (!visited[newRow, newCol])
                        {
                            visited[newRow, newCol] = true;
                            queue.Enqueue((newRow, newCol));
                        }
                    }
                }

                return (area, perimeter);
            }
        }
    }
}

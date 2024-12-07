namespace AdventOfCode24
{
    internal class Day4 : IDay
    {
        private int count = 0;
        private readonly string[] input;
        private readonly List<(int a, int b)> DirectionsPart1 =
        [
            (0, 1),  // Right
            (1, 0),  // Down
            (0, -1), // Left
            (-1, 0), // Up
            (1, 1),  // Down-Right (Diagonal)
            (-1, 1), // Up-Right (Diagonal)
            (1, -1), // Down-Left (Diagonal)
            (-1, -1) // Up-Left (Diagonal)
        ];

        private static readonly List<(int a, int b)> DirectionsPart2A =
        [
            (1, 1),  // Down-Right (Diagonal)       
            (-1, -1) // Up-Left (Diagonal)
        ];
        private static readonly List<(int a, int b)> DirectionsPart2B =
        [
            (-1, 1), // Up-Right (Diagonal)
            (1, -1), // Down-Left (Diagonal)
        ];

        public Day4()
        {
            input = File.ReadAllLines("input4-2024.txt");
        }

        public void Part1()
        {
            for (int y = 0; y < input.Length; y++)
            {
                for (int x = 0; x < input[y].Length; x++)
                {
                    if (input[y][x] == 'X')
                    {
                        FindXmassPart1(y, x);
                    }
                }
            }

            Console.WriteLine($"Day 4 Part 1 answer: {count}");
            count = 0;
        }

        public void Part2()
        {
            for (int y = 0; y < input.Length; y++)
            {
                for (int x = 0; x < input[y].Length; x++)
                {
                    if (input[y][x] == 'A')
                    {
                        FindXmassPart2(y, x);
                    }
                }
            }

            Console.WriteLine($"Day 4 Part 2 answer: {count}");
        }

        //Helper methods:
        private void FindXmassPart1(int y, int x)
        {
            const string target = "XMAS";
            int targetLength = target.Length;
            int inputHeight = input.Length;
            int inputWidth = input[0].Length;

            foreach (var (dy, dx) in DirectionsPart1)
            {
                bool isMatch = true;

                for (int i = 0; i < targetLength; i++)
                {
                    int newY = y + dy * i;
                    int newX = x + dx * i;

                    if (newY < 0 || newY >= inputHeight || newX < 0 || newX >= inputWidth || input[newY][newX] != target[i])
                    {
                        isMatch = false;
                        break;
                    }
                }

                if (isMatch) count++;
            }
        }

        private void FindXmassPart2(int y, int x)
        {
            int inputHeight = input.Length;
            int inputWidth = input[0].Length;

            bool diagonal1Match = CheckDiagonal(y, x, DirectionsPart2A, inputHeight, inputWidth);
            bool diagonal2Match = CheckDiagonal(y, x, DirectionsPart2B, inputHeight, inputWidth);

            if (diagonal1Match && diagonal2Match)
                count++;
        }

        private bool CheckDiagonal(int y, int x, List<(int a, int b)> directions, int height, int width)
        {
            foreach (var (dy, dx) in directions)
            {
                int newY1 = y + dy;
                int newX1 = x + dx;
                int newY2 = y - dy;
                int newX2 = x - dx;

                if (newY1 >= 0 && newY1 < height && newX1 >= 0 && newX1 < width &&
                    newY2 >= 0 && newY2 < height && newX2 >= 0 && newX2 < width)
                {
                    char char1 = input[newY1][newX1];
                    char char2 = input[newY2][newX2];

                    if ((char1 == 'M' && char2 == 'S') || (char1 == 'S' && char2 == 'M'))
                        return true;
                }
            }

            return false;
        }
    }
}


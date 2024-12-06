namespace AdventOfCode24
{
    internal class Day6
    {
        private readonly string[] input;
        private readonly HashSet<(int a, int b)> Visited = [];
        private readonly Dictionary<string, int> loops = [];
        private readonly List<(int a, int b)> DirectionsPart1 =
            [
               (0, 1),  // Right
               (1, 0),  // Down
               (0, -1), // Left
               (-1, 0), // Up
            ];
        int currectDirection = 3;

        public Day6()
        {
            input = File.ReadAllLines("input6-2024.txt");
        }

        public void Part1()
        {
            (int startY, int startX) = StartingCords();

            while (true)
            {
                Visited.Add((startY, startX));
                if (IsOutOfBounds(startY + DirectionsPart1[currectDirection].a, startX + DirectionsPart1[currectDirection].b)){
                    Console.WriteLine($"Day 6 Part 1 answer: {Visited.Count}");
                    break;
                }
                if (input[startY + DirectionsPart1[currectDirection].a][startX + DirectionsPart1[currectDirection].b] == '#')
                {
                    if (currectDirection == 3) currectDirection = 0;
                    else currectDirection++;
                }
                else
                {
                    startY += DirectionsPart1[currectDirection].a;
                    startX += DirectionsPart1[currectDirection].b;
                }
            }
        }

        public void Part2()
        {
            (int startYSave, int startXSave) = StartingCords();
            int answer = 0;
            var Visits = Visited.ToList();
            string[] tempInput = [.. input];

            object lockObject = new();

            Parallel.For(0, Visits.Count, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, i =>
            {
                string[] localTempInput = [.. tempInput];
                var localLoops = new Dictionary<string, int>();
                int localAnswer = 0;

                (int a, int b) = Visits[i];

                localTempInput[a] = localTempInput[a].Remove(b, 1).Insert(b, "#");

                (int startY, int startX) = (startYSave, startXSave);
                int localDirection = 3;

                while (true)
                {
                    int nextY = startY + DirectionsPart1[localDirection].a;
                    int nextX = startX + DirectionsPart1[localDirection].b;

                    if (IsOutOfBounds(nextY, nextX))
                    {
                        localTempInput = [.. tempInput];
                        localLoops.Clear();
                        localDirection = 3;
                        break;
                    }

                    if (localTempInput[nextY][nextX] == '#')
                    {
                        localDirection = (localDirection + 1) % 4;
                    }
                    else
                    {
                        startY = nextY;
                        startX = nextX;

                        string key = $"{startY},{startX},{localDirection}";

                        if (localLoops.TryGetValue(key, out int value))
                        {
                            localLoops[key] = value + 1;
                        }
                        else
                        {
                            localLoops[key] = 1;
                        }

                        if (localLoops[key] > 1)
                        {
                            localAnswer++;
                            localTempInput = [.. tempInput];
                            localLoops.Clear();
                            localDirection = 3;
                            break;
                        }
                    }
                }

                lock (lockObject)
                {
                    answer += localAnswer;
                }
            });

            Console.WriteLine($"Day 6 Part 2 answer: {answer}");
        }


        //Helper methods:
        private (int y, int x) StartingCords()
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (input[i][j] == '^') return (i, j);
                }
            }

            return (-10, -10);
        }

        private bool IsOutOfBounds(int y, int x)
        {
            return y < 0 || y >= input.Length || x < 0 || x >= input[0].Length;
        }
    }
}

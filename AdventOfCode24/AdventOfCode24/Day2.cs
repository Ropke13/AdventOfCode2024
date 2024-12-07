namespace AdventOfCode24
{
    internal class Day2 : IDay
    {
        private readonly string[] input;

        public Day2()
        {
            input = File.ReadAllLines("input2-2024.txt");
        }

        public void Part1()
        {
            int count = 0;
            foreach (var row in input)
            {
                List<int> itemsInRow = row.Split(' ').Select(int.Parse).ToList();

                if (IsSafe(itemsInRow))
                {
                    count++;
                }
            }

            Console.WriteLine($"Day 2 Part 1 answer: {count}");
        }

        public void Part2()
        {
            int count = 0;
            foreach (var row in input)
            {
                List<int> itemsInRow = row.Split(' ').Select(int.Parse).ToList();

                for (int i = -1; i < itemsInRow.Count; i++)
                {
                    if (i == -1)
                    {
                        if (IsSafe(itemsInRow))
                        {
                            count++;
                            break;
                        }
                    }
                    else
                    {
                        List<int> temp = [.. itemsInRow];
                        temp.RemoveAt(i);

                        if (IsSafe(temp))
                        {
                            count++;
                            break;
                        }
                    }
                    
                }
                
            }

            Console.WriteLine($"Day 2 Part 2 answer: {count}");
        }

        //Helper methods:
        public static bool IsSafe(List<int> itemsInRow)
        {
            bool isIncreasing;
            bool discard = false;

            if (itemsInRow[0] - itemsInRow[1] > 0) isIncreasing = false;
            else if (itemsInRow[0] - itemsInRow[1] < 0) isIncreasing = true;
            else return false;

            for (int i = 0; i < itemsInRow.Count - 1; i++)
            {
                int set = itemsInRow[i] - itemsInRow[i + 1];
                if (!isIncreasing && set > 0 && set < 4)
                {
                    continue;
                }
                else if (isIncreasing && set < 0 && set > -4)
                {
                    continue;
                }
                else
                {
                    discard = true;
                    break;
                }
            }

            if (!discard)
            {
                return true;
            }
            return false;
        }
    }
}

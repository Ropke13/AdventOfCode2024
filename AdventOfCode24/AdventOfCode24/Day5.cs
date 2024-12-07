namespace AdventOfCode24
{
    internal class Day5 : IDay
    {
        private readonly string[] input;
        private List<(int a, int b)> rules = [];
        private List<List<int>> updates = [];
        private (int a, int b) swap;

        public Day5()
        {
            input = File.ReadAllLines("input5-2024.txt");
            Parse();
        }

        private void Parse()
        {
            var blankLineIndex = Array.IndexOf(input, "");
            var pairsPart = input.Take(blankLineIndex).ToArray();
            var groupsPart = input.Skip(blankLineIndex + 1).ToArray();

            rules = pairsPart
                .Select(line => line.Split('|'))
                .Select(parts => (a: int.Parse(parts[0]), b: int.Parse(parts[1])))
                .ToList();

            updates = groupsPart
                .Select(line => line.Split(',').Select(int.Parse).ToList())
                .ToList();
        }

        public void Part1()
        {
            int sum = 0;

            foreach (var update in updates)
            {
                if (IsCorrect(update))
                {
                    int middleValue = update[update.Count / 2];
                    sum += middleValue;
                }
            }

            Console.WriteLine($"Day 5 Part 1 answer: {sum}");
        }

        public void Part2()
        {
            int sum = 0;
            int mistakes = 0;
            
            foreach (var update in updates)
            {
                while (!IsCorrect(update)){
                    mistakes++;
                    int x = update.IndexOf(swap.a);
                    int y = update.IndexOf(swap.b);

                    update[x] = swap.b;
                    update[y] = swap.a;
                }

                if (mistakes > 0) 
                {
                    int middleValue = update[update.Count / 2];
                    sum += middleValue;
                    mistakes = 0;
                }
            }
            

            Console.WriteLine($"Day 5 Part 2 answer: {sum}");
        }

        //Helper methods:
        private bool IsCorrect(List<int> update)
        {
            bool skipUpdate = false;
            foreach (var number in update)
            {
                foreach (var rule in rules)
                {
                    if (rule.a == number)
                    {
                        foreach (var item in update)
                        {
                            if (number.Equals(item))
                            {
                                break;
                            }
                            else if (rule.b.Equals(item))
                            {
                                skipUpdate = true;
                                swap = rule;
                                break;
                            }
                        }

                        if (skipUpdate)
                        {
                            return false;
                        }
                    }
                }
                if (skipUpdate)
                {
                    return false;
                }
            }
            return true;
        }
    }
}


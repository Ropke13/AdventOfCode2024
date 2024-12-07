using AdventOfCode24.Interfaces;

namespace AdventOfCode24.Days
{
    internal class Day1 : IDay
    {
        private readonly string[] input;
        private readonly List<int> number1 = [];
        private readonly List<int> number2 = [];

        public Day1()
        {
            input = File.ReadAllLines("input1-2024.txt");
            Parse();
        }

        private void Parse()
        {
            foreach (var item in input)
            {
                string[] split = item.Split("   ");
                number1.Add(int.Parse(split[0]));
                number2.Add(int.Parse(split[1]));
            }

            number1.Sort();
            number2.Sort();
        }

        public void Part1()
        {
            int sum = 0;
            for (int i = 0; i < number1.Count; i++)
            {
                sum += Math.Abs(number1[i] - number2[i]);
            }

            Console.WriteLine($"Day 1 Part 1 answer: {sum}");
        }

        public void Part2()
        {
            int sumPart2 = 0;

            for (int i = 0; i < number1.Count; i++)
            {
                int selected = number1[i];

                sumPart2 += number2.Count(item => item == selected) * selected;
            }

            Console.WriteLine($"Day 1 Part 2 answer: {sumPart2}");
        }
    }
}

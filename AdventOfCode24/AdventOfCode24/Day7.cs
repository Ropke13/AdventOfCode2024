using System.ComponentModel;

namespace AdventOfCode24
{
    internal class Day7
    {
        private readonly string[] input;
        private readonly Dictionary<long, List<int>> ParsedInput = [];

        public Day7()
        {
            input = File.ReadAllLines("input7-2024.txt");
            Parse();
        }

        private void Parse()
        {
            foreach (var line in input)
            {
                string[] splits = line.Split(": ");
                long answer = long.Parse(splits[0]);
                List<int> numbers = splits[1].Split(' ').Select(int.Parse).ToList();

                ParsedInput[answer] = numbers;
            }
        }

        public void Part1()
        {
            long totalCalibrationResult = 0;

            Parallel.For(0, ParsedInput.Count, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, i =>
            {
                var item = ParsedInput.ElementAt(i);
                if (CanMakeEquationTrue(item.Key, item.Value))
                {
                    totalCalibrationResult += item.Key;
                }
            });

            Console.WriteLine($"Day 7 Part 1 answer: {totalCalibrationResult}");
        }

        public void Part2()
        {
            long totalCalibrationResult = 0;

            Parallel.For(0, ParsedInput.Count, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, i =>
            {
                var item = ParsedInput.ElementAt(i);
                if (CanMakeEquationTruePart2(item.Key, item.Value))
                {
                    totalCalibrationResult += item.Key;
                }
            });

            Console.WriteLine($"Day 7 Part 2 answer: {totalCalibrationResult}");
        }

        //Helper methods:
        static bool CanMakeEquationTrue(long testValue, List<int> numbers)
        {
            return EvaluatePart1(numbers, testValue, 0, numbers[0]);
        }

        static bool CanMakeEquationTruePart2(long testValue, List<int> numbers)
        {
            return EvaluatePart2(numbers, testValue, 0, numbers[0]);
        }

        static bool EvaluatePart1(List<int> numbers, long target, int index, long current)
        {
            if (index == numbers.Count - 1)
            {
                return current == target;
            }

            long nextNumber = numbers[index + 1];
            return EvaluatePart1(numbers, target, index + 1, current + nextNumber) ||
                   EvaluatePart1(numbers, target, index + 1, current * nextNumber);
        }

        static bool EvaluatePart2(List<int> numbers, long target, int index, long current)
        {
            if (index == numbers.Count - 1)
            {
                return current == target;
            }

            long nextNumber = numbers[index + 1];
            return EvaluatePart2(numbers, target, index + 1, current + nextNumber) ||
                   EvaluatePart2(numbers, target, index + 1, current * nextNumber) ||
                   EvaluatePart2(numbers, target, index + 1, long.Parse($"{current}{nextNumber}"));
        }
    }
}

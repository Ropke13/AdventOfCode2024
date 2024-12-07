using System.Text.RegularExpressions;
using AdventOfCode24.Interfaces;

namespace AdventOfCode24.Days
{
    internal class Day3 : IDay
    {
        private readonly string input;
        private readonly string pattern1 = @"mul\((\d{1,3}),(\d{1,3})\)";
        private readonly string pattern2 = @"mul\((\d{1,3}),(\d{1,3})\)|do\(\)|don\'t\(\)";

        private List<(int a, int b)> matches = [];
        private List<(int a, int b)> matches2 = [];

        public Day3()
        {
            input = File.ReadAllText("input3-2024.txt");
            Parse();
        }

        private void Parse()
        {
            matches = FindAndParseMatches(pattern1, input);
            matches2 = FindAndParseMatches2(pattern2, input);
        }

        public void Part1()
        {
            Console.WriteLine($"Day 3 Part 1 answer: {SumAnswer(matches)}");
        }

        public void Part2()
        {
            SumAnswer(matches2);
            Console.WriteLine($"Day 3 Part 2 answer: {SumAnswer(matches2)}");
        }

        //Helper methods:
        private static List<(int a, int b)> FindAndParseMatches(string pattern, string input)
        {
            List<(int a, int b)> result = [];

            Regex regex = new(pattern);
            MatchCollection matchCollection = regex.Matches(input);

            foreach (Match match in matchCollection.Cast<Match>())
            {
                if (match.Success)
                {
                    int a = int.Parse(match.Groups[1].Value);
                    int b = int.Parse(match.Groups[2].Value);

                    result.Add((a, b));
                }
            }

            return result;
        }

        private static List<(int a, int b)> FindAndParseMatches2(string pattern, string input)
        {
            bool isEnabled = true;
            List<(int a, int b)> result = [];

            Regex regex = new(pattern);
            MatchCollection matchCollection = regex.Matches(input);

            foreach (Match match in matchCollection.Cast<Match>())
            {
                if (match.Value == "do()")
                {
                    isEnabled = true;
                    continue;
                }
                else if (match.Value == "don't()")
                {
                    isEnabled = false;
                    continue;
                }

                if (isEnabled && match.Success)
                {
                    int a = int.Parse(match.Groups[1].Value);
                    int b = int.Parse(match.Groups[2].Value);

                    result.Add((a, b));
                }
            }

            return result;
        }

        private static int SumAnswer(List<(int a, int b)> matches)
        {
            int total = 0;

            foreach (var (a, b) in matches)
            {
                total += a * b;
            }

            return total;
        }
    }
}

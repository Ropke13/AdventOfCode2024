using AdventOfCode24.Interfaces;
using System.Text.RegularExpressions;

namespace AdventOfCode24.Days
{
    internal partial class Day13 : IDay
    {
        private readonly string[] input;

        public Day13()
        {
            input = File.ReadAllLines("input13-2024.txt");
        }

        public void Part1()
        {
            Console.WriteLine($"Day 13 Part 1 answer:{SolveTokens()}");
        }

        public void Part2()
        {
            Console.WriteLine($"Day 13 Part 2 answer: {SolveTokens(10000000000000)}");
        }

        //Helper methods:

        private long SolveTokens(long part2 = 0)
        {
            long sum = 0;
            for (int i = 0; i < input.Length; i += 3)
            {
                string lineA = input[i];
                string lineB = input[i + 1];
                string lineC = input[i + 2];
                var match = LineABRegex().Match(lineA);
                var match2 = LineABRegex().Match(lineB);
                var match3 = AnserRegex().Match(lineC);

                decimal A1 = decimal.Parse(match.Groups[1].Value);
                decimal A2 = decimal.Parse(match.Groups[2].Value);

                decimal B1 = decimal.Parse(match2.Groups[1].Value);
                decimal B2 = decimal.Parse(match2.Groups[2].Value);

                decimal y1 = decimal.Parse(match3.Groups[1].Value) + part2;
                decimal y2 = decimal.Parse(match3.Groups[2].Value) + part2;

                i++;

                decimal B = (A1 * y2 - A2 * y1) / ((-1 * A2) * B1 + A1 * B2);
                decimal A = (y1 - B1 * B) / A1;

                if (part2 == 0 && B == Math.Floor(B) && A == Math.Floor(A) && B <= 100 && A <= 100 && A >= 0 && B >= 0)
                    sum += (long)A * 3 + (long)B;

                else if (B == Math.Floor(B) && A == Math.Floor(A) && A >= 0 && B >= 0)
                    sum += (long)A * 3 + (long)B;
            }

            return sum;
        }

        [GeneratedRegex(@"X=(\d+), Y=(\d+)")]
        private static partial Regex AnserRegex();
        [GeneratedRegex(@"X\+(\d+), Y\+(\d+)")]
        private static partial Regex LineABRegex();
    }
}

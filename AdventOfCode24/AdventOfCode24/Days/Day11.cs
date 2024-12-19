using AdventOfCode24.Interfaces;
using System.Numerics;

namespace AdventOfCode24.Days
{
    internal class Day11 : IDay
    {
        private readonly string input;

        public Day11()
        {
            input = File.ReadAllText("input11-2024.txt");
        }

        public void Part1()
        {
            List<BigInteger> stones = input.Split(' ')
                                  .Select(BigInteger.Parse)
                                  .ToList();

            var cache = new Dictionary<(BigInteger, BigInteger), BigInteger>();

            Console.WriteLine($"Day 11 Part 1 answer: {RecursivelyBlink(stones, 25, cache)}");
        }

        public void Part2()
        {
            List<BigInteger> stones = input.Split(' ')
                                  .Select(BigInteger.Parse)
                                  .ToList();

            var cache = new Dictionary<(BigInteger, BigInteger), BigInteger>();

            Console.WriteLine($"Day 11 Part 2 answer: {RecursivelyBlink(stones, 75, cache)}");
        }

        // Helper methods
        private static BigInteger RecursivelyBlink(List<BigInteger> stones, int timesToBlink, Dictionary<(BigInteger, BigInteger), BigInteger> cache)
        {
            if (timesToBlink == 0) return stones.Count;

            BigInteger count = 0;
            foreach (var stone in stones)
            {
                if (cache.TryGetValue((stone, timesToBlink), out BigInteger value))
                {
                    count += value;
                    continue;
                }

                BigInteger singleStoneResult = RecursivelyBlink(Blink(stone), timesToBlink - 1, cache);
                cache.Add((stone, timesToBlink), singleStoneResult);

                count += singleStoneResult;
            }

            return count;
        }

        private static List<BigInteger> Blink(BigInteger stone)
        {
            var stoneBag = new List<BigInteger>();
            if (stone == 0)
            {
                return [1];
            }

            BigInteger stoneLength = stone.ToString().Length;
            if ((stoneLength & 1) == 0)
            {
                BigInteger halfLen = stoneLength / 2;
                int divider = (int)Math.Pow(10, (double)halfLen);

                BigInteger topHalf = stone / divider;
                BigInteger bottomHalf = stone % divider;

                stoneBag.Add(topHalf);
                stoneBag.Add(bottomHalf);
                return stoneBag;
            }

            stoneBag.Add(stone * 2024);

            return stoneBag;
        }
    }
}
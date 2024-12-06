using System.Diagnostics;

namespace AdventOfCode24
{
    internal static class Init
    {
        public static void DaysDisplay(int[] days)
        {
            foreach (int day in days)
            {
                Console.WriteLine("==================================");
                Stopwatch stopwatch = new();
                stopwatch.Start();
                switch (day)
                {
                    case 1:
                        var selectedDay1 = new Day1();
                        selectedDay1.Part1();
                        selectedDay1.Part2();
                        break;
                    case 2:
                        var selectedDay2 = new Day2();
                        selectedDay2.Part1();
                        selectedDay2.Part2();
                        break;
                    case 3:
                        var selectedDay3 = new Day3();
                        selectedDay3.Part1();
                        selectedDay3.Part2();
                        break;
                    case 4:
                        var selectedDay4 = new Day4();
                        selectedDay4.Part1();
                        selectedDay4.Part2();
                        break;
                    case 5:
                        var selectedDay5 = new Day5();
                        selectedDay5.Part1();
                        selectedDay5.Part2();
                        break;
                    case 6:
                        var selectedDay6 = new Day6();
                        selectedDay6.Part1();
                        selectedDay6.Part2();
                        break;

                    default:
                        Console.WriteLine($"Day {day} is not implemented.");
                        break;
                }
                stopwatch.Stop();

                if (stopwatch.ElapsedMilliseconds < 1000) Console.ForegroundColor = ConsoleColor.Green;
                else Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"Execution Time of the Day: {stopwatch.ElapsedMilliseconds} ms");
                Console.ResetColor();
            }
        }
    }
}

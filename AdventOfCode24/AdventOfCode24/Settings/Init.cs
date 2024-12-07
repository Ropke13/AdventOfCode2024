using AdventOfCode24.Interfaces;
using AdventOfCode24.Settings;
using System.Diagnostics;
using System.Reflection;

internal static class Init
{
    public static void DaysDisplay(int[] days)
    {
        foreach (int day in days)
        {
            Console.WriteLine("==================================");
            Stopwatch stopwatch = new();
            stopwatch.Start();

            IDay? dayInstance = DayFactory.GetDayInstance(day);

            if (dayInstance != null)
            {
                dayInstance.Part1();
                dayInstance.Part2();
            }
            else
            {
                Console.WriteLine($"Day {day} is not implemented.");
                stopwatch.Stop();
                continue;
            }

            stopwatch.Stop();

            if (stopwatch.ElapsedMilliseconds < 1000) Console.ForegroundColor = ConsoleColor.Green;
            else Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"Execution Time of the Day: {stopwatch.ElapsedMilliseconds} ms");
            Console.ResetColor();
        }
    }
}
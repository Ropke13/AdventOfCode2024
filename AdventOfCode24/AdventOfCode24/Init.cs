namespace AdventOfCode24
{
    internal static class Init
    {
        public static void DaysDisplay(int[] days)
        {
            foreach (int day in days)
            {
                Console.WriteLine("==================================");
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
                        var selectedDay5 = new Day4();
                        selectedDay5.Part1();
                        selectedDay5.Part2();
                        break;

                    default:
                        Console.WriteLine($"Day {day} is not implemented.");
                        break;
                }
            }
        }
    }
}

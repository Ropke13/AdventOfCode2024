namespace AdventOfCode24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input1-2024.txt");

            var selectedDay = new Day1();

            selectedDay.Parse(input);
            selectedDay.Part1();
            selectedDay.Part2();

            Console.Read();
        }
    }
}

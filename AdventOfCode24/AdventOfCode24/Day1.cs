using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System; 
using System.Threading.Tasks;

namespace AdventOfCode24
{
    internal class Day1
    {
        public List<int> number1 = [];
        public List<int> number2 = [];
        public void Parse(string[] input)
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

            Console.WriteLine(sum);
        }

        public void Part2()
        {
            int sumPart2 = 0;

            for (int i = 0; i < number1.Count; i++)
            {
                int selected = number1[i];

                sumPart2 += number2.Count(item => item == selected) * selected;
            }

            Console.WriteLine(sumPart2);
        }
    }
}

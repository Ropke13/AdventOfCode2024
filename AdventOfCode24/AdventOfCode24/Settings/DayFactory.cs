using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode24.Interfaces;

namespace AdventOfCode24.Settings
{
    internal static class DayFactory
    {
        public static IDay? GetDayInstance(int day)
        {
            string className = $"AdventOfCode24.Days.Day{day}";
            Type? type = Assembly.GetExecutingAssembly().GetType(className);

            if (type != null && typeof(IDay).IsAssignableFrom(type))
            {
                return Activator.CreateInstance(type) as IDay;
            }

            return null;
        }
    }
}

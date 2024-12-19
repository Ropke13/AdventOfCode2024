using AdventOfCode24.Interfaces;
using System.Text;

namespace AdventOfCode24.Days
{
    internal class Day15 : IDay
    {
        private readonly string[] input;
        private string[] mapL;
        private string robCommands;
        private (int y, int x) RobCoords;

        public Day15()
        {
            input = File.ReadAllLines("input15-2024.txt");
            Parse();
            RobCoords = StartingCords();
        }

        private void Parse()
        {
            List<string> map = [];
            List<string> commands = [];

            bool isMap = true; 
            foreach (string line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    isMap = false;
                    continue;
                }

                if (isMap)
                    map.Add(WidenString(line));
                else
                    commands.Add(line);
            }

            mapL = [.. map];
            robCommands = string.Join("", commands);
        }
        private static string WidenString(string input)
        {
            // Use a StringBuilder for efficient string manipulation.
            StringBuilder widened = new();

            foreach (char c in input)
            {
                if (c == 'O')
                {
                    widened.Append("[]");
                }
                else if (c == '@')
                {
                    widened.Append("@.");
                }
                else
                {
                    widened.Append(c);
                    widened.Append(c); // Duplicate all other characters.
                }
            }

            return widened.ToString();
        }

        public void Part1()
        { }
        //<vv>^<v^>v>^vv^v>v<
        //public void Part1()
        //{
        //    foreach (char c in robCommands)
        //    {
        //        if (c == '<')
        //        {
        //            if (Move(RobCoords.y, RobCoords.x - 1, c, '@'))
        //            {
        //                mapL[RobCoords.y] = mapL[RobCoords.y].Remove(RobCoords.x, 1).Insert(RobCoords.x, ".");
        //                RobCoords = StartingCords();
        //            }
        //        }
        //        else if (c == 'v')
        //        {
        //            if (Move(RobCoords.y + 1, RobCoords.x, c, '@'))
        //            {
        //                mapL[RobCoords.y] = mapL[RobCoords.y].Remove(RobCoords.x, 1).Insert(RobCoords.x, ".");
        //                RobCoords = StartingCords();
        //            }
        //        }
        //        else if (c == '^')
        //        {
        //            if (Move(RobCoords.y - 1, RobCoords.x, c, '@'))
        //            {
        //                mapL[RobCoords.y] = mapL[RobCoords.y].Remove(RobCoords.x, 1).Insert(RobCoords.x, ".");
        //                RobCoords = StartingCords();
        //            }
        //        }
        //        else if (c == '>')
        //        {
        //            if (Move(RobCoords.y, RobCoords.x + 1, c, '@'))
        //            {
        //                mapL[RobCoords.y] = mapL[RobCoords.y].Remove(RobCoords.x, 1).Insert(RobCoords.x, ".");
        //                RobCoords = StartingCords();
        //            }
        //        }
        //    }

        //    int sum = 0;
        //    for(int i = 0; i < mapL.Length; i++)
        //    {
        //        for(int j = 0; j < mapL[i].Length; j++) 
        //        {
        //            Console.Write(mapL[i][j]);
        //            if(mapL[i][j] == 'O')
        //            {
        //                sum += 100 * i + j;
        //            }
        //        }
        //        Console.WriteLine();
        //    }

        //Console.WriteLine($"Day 15 Part 1 answer: {sum}");
        //}

        public void Part2()
        {
            int movenr = 0;
            foreach (char c in robCommands)
            {
                //for (int i = 0; i < mapL.Length; i++)
                //{
                //    for (int j = 0; j < mapL[i].Length; j++)
                //    {
                //        Console.Write(mapL[i][j]);
                //    }
                //    Console.WriteLine();
                //}
                Console.WriteLine($"{movenr}/{robCommands.Count()}");
                movenr++;
                //Console.ReadLine();
                if (c == '<')
                {
                    if (Move(RobCoords.y, RobCoords.x - 1, c, '@'))
                    {
                        mapL[RobCoords.y] = mapL[RobCoords.y].Remove(RobCoords.x, 1).Insert(RobCoords.x, ".");
                        RobCoords = StartingCords();
                    }
                }
                else if (c == 'v')
                {
                    if (IsValid(RobCoords.y + 1, RobCoords.x, c, '@') && Move(RobCoords.y + 1, RobCoords.x, c, '@'))
                    {
                        mapL[RobCoords.y] = mapL[RobCoords.y].Remove(RobCoords.x, 1).Insert(RobCoords.x, ".");
                        RobCoords = StartingCords();
                    }
                }
                else if (c == '^') 
                { 
                    if (IsValid(RobCoords.y - 1, RobCoords.x, c, '@') && Move(RobCoords.y - 1, RobCoords.x, c, '@'))
                    {
                        mapL[RobCoords.y] = mapL[RobCoords.y].Remove(RobCoords.x, 1).Insert(RobCoords.x, ".");
                        RobCoords = StartingCords();
                    }
                }
                else if (c == '>')
                {
                    if (Move(RobCoords.y, RobCoords.x + 1, c, '@'))
                    {
                        mapL[RobCoords.y] = mapL[RobCoords.y].Remove(RobCoords.x, 1).Insert(RobCoords.x, ".");
                        RobCoords = StartingCords();
                    }
                }

                

                
            }

            int sum = 0;
            for (int i = 0; i < mapL.Length; i++)
            {
                for (int j = 0; j < mapL[i].Length; j++)
                {
                    Console.Write(mapL[i][j]);
                    if (mapL[i][j] == 'O')
                    {
                        sum += 100 * i + j;
                    }
                }
                Console.WriteLine();
            }

            int sums = 0;
            for (int i = 0; i < mapL.Length; i++)
            {
                for (int j = 0; j < mapL[i].Length; j++)
                {
                    Console.Write(mapL[i][j]);
                    if (mapL[i][j] == '[')
                    {
                        sums += 100 * i + j;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Day 15 Part 2 answer:{sums}");
        }

        //Helper methods:
        private bool IsValid(int y, int x, char c, char Gives, char Gives2 = '.')
        {
            bool isDouble1 = true;
            bool isDouble2 = true;

            if (mapL[y][x] == '[')
            {
                if (c == 'v')
                {
                    isDouble1 = IsValid(y + 1, x, c, '[');
                    isDouble2 = IsValid(y + 1, x + 1, c, ']');
                }
                else if (c == '^')
                {
                    isDouble1 = IsValid(y - 1, x, c, '[');
                    isDouble2 = IsValid(y - 1, x + 1, c, ']');
                }
            }
            else if (mapL[y][x] == ']')
            {
 
                if (c == 'v')
                {
                    isDouble1 = IsValid(y + 1, x, c, ']');
                    isDouble2 = IsValid(y + 1, x - 1, c, '[');
                }
                else if (c == '^')
                {
                    isDouble1 = IsValid(y - 1, x, c, ']');
                    isDouble2 = IsValid(y - 1, x - 1, c, '[');
                }
            }
            else if (mapL[y][x] == '#')
            {
                return false;
            }
            else if (mapL[y][x] == '.')
            {
                return true;
            }

            if (isDouble1 && isDouble2) return true;

            return false;
        }
        private bool Move(int y, int x, char c, char Gives, char Gives2 = '.')
        {
            bool moveChain = false;
            bool isDouble1 = false;
            bool isDouble2 = false;

            if (mapL[y][x] == '[')
            {
                if (c == '<')
                {
                    moveChain = Move(y, x - 1, c, '[');
                }
                else if (c == 'v')
                {
                    isDouble1 = Move(y + 1, x, c, '[');
                    isDouble2 = Move(y + 1, x + 1, c, ']');
                }
                else if (c == '^')
                {
                    isDouble1 = Move(y - 1, x, c, '[');
                    isDouble2 = Move(y - 1, x + 1, c, ']');
                }
                else if (c == '>')
                {
                    moveChain = Move(y, x + 1, c, '[');
                }
            }
            else if (mapL[y][x] == ']')
            {
                if (c == '<')
                {
                    moveChain = Move(y, x - 1, c, ']');
                }
                else if (c == 'v')
                {
                    isDouble1 = Move(y + 1, x, c, ']');
                    isDouble2 = Move(y + 1, x - 1, c, '[');
                }
                else if (c == '^')
                {
                    isDouble1 = Move(y - 1, x, c, ']');
                    isDouble2 = Move(y - 1, x - 1, c, '[');
                }
                else if (c == '>')
                {
                    moveChain = Move(y, x + 1, c, ']');
                }
            }
            else if (mapL[y][x] == '#')
            {
                return false;
            }
            else if (mapL[y][x] == '.')
            {
                mapL[y] = mapL[y].Remove(x, 1).Insert(x, Gives.ToString());
                return true;
            }

            if (isDouble1 && isDouble2 && mapL[y][x] == '[')
            {
                mapL[y] = mapL[y].Remove(x, 1).Insert(x, Gives.ToString());
                mapL[y] = mapL[y].Remove(x+1, 1).Insert(x+1, Gives2.ToString());

                return true;
            }
            else if (isDouble1 && isDouble2 && mapL[y][x] == ']')
            {
                mapL[y] = mapL[y].Remove(x, 1).Insert(x, Gives.ToString());
                mapL[y] = mapL[y].Remove(x-1, 1).Insert(x-1, Gives2.ToString());

                return true;
            }
            else if (moveChain)
            {
                mapL[y] = mapL[y].Remove(x, 1).Insert(x, Gives.ToString());

                return true;
            }

            return false;
        }

        private (int y, int x) StartingCords()
        {
            for (int i = 0; i < mapL.Length; i++)
            {
                for (int j = 0; j < mapL[i].Length; j++)
                {
                    if (mapL[i][j] == '@') return (i, j);
                }
            }

            return (-10, -10);
        }
    }
}

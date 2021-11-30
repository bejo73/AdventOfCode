using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    class Day24
    {
        public static void Run()
        {
            string line;
            StreamReader file = new StreamReader(@"./Data/Day24.txt");

            HashSet<string> black = new HashSet<string>();

            while ((line = file.ReadLine()) != null)
            {
                int x = 0;
                int y = 0;

                for (int i = 0; i < line.Length; i++)
                {
                    char c = line[i];
                    char d;

                    switch (c)
                    {
                        case 'e':
                            x += 2;
                            break;
                        case 's':
                            d = line[++i];
                            if (d == 'e')
                            {
                                x += 1;
                                y -= 1;
                            }
                            else
                            {
                                x -= 1;
                                y -= 1;
                            }
                            break;
                        case 'w':
                            x -= 2;
                            break;
                        case 'n':
                            d = line[++i];
                            if (d == 'e')
                            {
                                x += 1;
                                y += 1;
                            }
                            else
                            {
                                x -= 1;
                                y += 1;
                            }
                            break;
                    }
                }

                string pos = x + "," + y;
                if (black.Contains(pos))
                {
                    black.Remove(pos);
                }
                else
                {
                    black.Add(pos);
                }
            }

            Console.WriteLine("Day24 (1): " + black.Count());
            Console.WriteLine("      (2): " + "TBD");
        }

    }

}
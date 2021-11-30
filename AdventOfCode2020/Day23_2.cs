using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    class Day23_2
    {
        public static void Run()
        {
            //string testCups = "389125467";
            string testCups = "925176834";
            Dictionary<int, int> cups = new Dictionary<int, int>();

            int next;
            int current;

            for (int i = 0; i < testCups.Length; i++)
            {
                if (i < (testCups.Length - 1))
                {
                    current = Convert.ToInt32(testCups[i].ToString());
                    next = Convert.ToInt32(testCups[i + 1].ToString());
                    cups.Add(current, next);
                }
                else
                {
                    current = Convert.ToInt32(testCups[i].ToString());
                    next = 10;
                    cups.Add(current, next);
                }
            }

            for (int y = 10; y <= 1000000; y++)
            {
                if (y == 1000000)
                {
                    next = Convert.ToInt32(testCups[0].ToString());
                    cups.Add(y, next);
                }
                else
                {
                    cups.Add(y, y + 1);
                }
            }


            int numberOfRounds = 10000001;

            current = Convert.ToInt32(testCups[0].ToString());

            for (int r = 1; r <= numberOfRounds; r++)
            {
                // Pick cups
                int cup1 = cups[current];
                int cup2 = cups[cup1];
                int cup3 = cups[cup2];
                int nxt = cups[cup3];
                int[] threeCups = new int[] { cup1, cup2, cup3 };

                // # Pick destination
                int dest = current - 1;

                while (true)
                {
                    if (!threeCups.Contains(dest) && dest >= 1)
                        break;
                    else
                    {
                        if (threeCups.Contains(dest)) dest -= 1;
                        if (dest < 1) dest = cups.Keys.Max();
                    }
                }
                
                cups[current] = cups[cup3];
                cups[cup3] = cups[dest];
                cups[dest] = cup1;

                current = nxt;
            }

            Console.WriteLine(cups[1]);
            Console.WriteLine(cups[cups[1]]);

            UInt64 p = UInt64.Parse(cups[1].ToString()) * UInt64.Parse(cups[cups[1]].ToString());

            Console.WriteLine("Day23 (1): ");
            Console.WriteLine("      (2): " + p);
        }
    }
}
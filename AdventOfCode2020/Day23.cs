using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    class Day23
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
                current = Convert.ToInt32(testCups[i].ToString());
                if (i == testCups.Length - 1)
                {
                    next = Convert.ToInt32(testCups[0].ToString());
                    cups.Add(current, next);
                }
                else
                {
                    next = Convert.ToInt32(testCups[i + 1].ToString());
                    cups.Add(current, next);
                }                
            }

            bool destinationFound = false;
            int numberOfRounds = 101;

            current = Convert.ToInt32(testCups[0].ToString());

            int nextThreeCupsStart;

            for (int r = 1; r <= numberOfRounds; r++)
            {
                int debugCurrent = current;
                Console.Write("R="+ r + ", " + debugCurrent);
                for (int a = 0; a < cups.Count - 1; a++)
                {
                    Console.Write(cups[debugCurrent]);
                    debugCurrent = cups[debugCurrent];
                }
                Console.WriteLine();
                Console.WriteLine();

                Dictionary<int, int> nextThreeCups = new Dictionary<int, int>();
                next = cups[current];
                nextThreeCupsStart = next;

                for (int i = 0; i < 3; i++)
                {
                    nextThreeCups.Add(next, cups[next]);
                    next = cups[next];
                }

                foreach (var c in nextThreeCups)
                {
                    cups.Remove(c.Key);
                }

                int possibleDestination = next;
                cups[current] = next;

                int afterPossibleDestination;

                while (!destinationFound)
                {
                    if (cups.Count(c => c.Key < current) == 0)
                    {
                        destinationFound = true;
                        possibleDestination = cups.Keys.Max();
                        afterPossibleDestination = cups[possibleDestination];
                        cups[possibleDestination] = nextThreeCupsStart;
                        next = nextThreeCupsStart;
                        for (int i = 0; i < 3; i++)
                        {
                            if (i == 2)
                            {
                                cups.Add(next, afterPossibleDestination);
                            }
                            else
                            {
                                cups.Add(next, nextThreeCups[next]);
                            }

                            next = nextThreeCups[next];
                        }

                    }
                    else
                    {
                        for (int i = 1; i < current ; i++)
                        {
                            possibleDestination = cups.FirstOrDefault(c => c.Key == current - i).Key;

                            if (possibleDestination == current - i)
                            {

                                destinationFound = true;
                                afterPossibleDestination = cups[possibleDestination];
                                cups[possibleDestination] = nextThreeCupsStart;

                                next = nextThreeCupsStart;
                                for (int j = 0; j < 3; j++)
                                {
                                    if (j == 2)
                                    {
                                        cups.Add(next, afterPossibleDestination);
                                    }
                                    else
                                    {
                                        cups.Add(next, nextThreeCups[next]);
                                    }

                                    next = nextThreeCups[next];
                                }
                                break;
                            }
                        }
                    }


                   
                    
                    //cups.FirstOrDefault(f => f.CompareTo() )
                    //LinkedListNode<int> destination = current.Next.Next.Next;
                }

                destinationFound = false;
                current = cups[current];

            }

            


            Console.WriteLine("Day10 (1): " + "TBD");
            Console.WriteLine("      (2): " + "TBD");
        }
    }
}
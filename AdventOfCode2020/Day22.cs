using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    class Day22
    {
        public static void Run()
        {
            string line;
            StreamReader file = new StreamReader(@"./Data/Day22.txt");

            List<int> p1 = new List<int>();
            List<int> p2 = new List<int>();

            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("Player 1"))
                {
                    while ((line = file.ReadLine()) != null && line.Length > 0)
                    {
                        p1.Add(int.Parse(line));
                    }
                }

                if (line.StartsWith("Player 2"))
                {
                    while ((line = file.ReadLine()) != null && line.Length > 0)
                    {
                        p2.Add(int.Parse(line));
                    }
                }
            }

            List<int> p1_2 = new List<int>(p1);
            List<int> p2_2 = new List<int>(p2);

            int rounds = 0;
            while (p1.Count > 0 && p2.Count > 0)
            {
                int c1 = p1[0];
                int c2 = p2[0];

                if (c1 > c2)
                {
                    p2.RemoveAt(0);
                    p1.RemoveAt(0);
                    p1.Add(c1);
                    p1.Add(c2);
                }
                else
                {
                    p1.RemoveAt(0);
                    p2.RemoveAt(0);
                    p2.Add(c2);
                    p2.Add(c1);
                }
                rounds++;
            }

            int score = 0;
            if (p1.Count > 0)
            {
                p1.Reverse();
                for (int i = 1; i <= p1.Count; i++)
                {
                    score += i * p1[i - 1];
                }
            }
            else
            {
                p2.Reverse();
                for (int i = 1; i <= p2.Count; i++)
                {
                    score += i * p2[i - 1];
                }
            }

            int player = 0;
            int score2 = GetScore(p1_2, p2_2, out player);

            Console.WriteLine("Day10 (1): " + score);
            Console.WriteLine("      (2): " + score2);
        }

        public static int GetScore(List<int> p1, List<int> p2, out int player)
        {
            int score = 0;

            HashSet<string> prevRounds1 = new HashSet<string>();
            HashSet<string> prevRounds2 = new HashSet<string>();

            int rounds = 0;
            while (p1.Count > 0 && p2.Count > 0)
            {
                if (prevRounds1.Contains(string.Join("", p1.ToArray())) || prevRounds2.Contains(string.Join("", p2.ToArray())))
                {
                    p2.Clear();
                    break;
                }

                prevRounds1.Add(string.Join("", p1.ToArray()));
                prevRounds2.Add(string.Join("", p2.ToArray()));

                int c1 = p1[0];
                int c2 = p2[0];

                p1.RemoveAt(0);
                p2.RemoveAt(0);

                if (c1 <= p1.Count && c2 <= p2.Count)
                {
                    int tmpPlayer = 0;
                    List<int> tmpP1 = new List<int>(p1.Take(c1));
                    List<int> tmpP2 = new List<int>(p2.Take(c2));
                    int tmpScore = GetScore(tmpP1, tmpP2, out tmpPlayer);
                    if (tmpPlayer == 1)
                    {
                        p1.Add(c1);
                        p1.Add(c2);
                    }
                    else
                    {
                        p2.Add(c2);
                        p2.Add(c1);
                    }
                }
                else if (c1 > c2)
                {
                    p1.Add(c1);
                    p1.Add(c2);
                }
                else
                {   
                    p2.Add(c2);
                    p2.Add(c1);
                }

                rounds++;
            }

            if (p1.Count > 0)
            {
                player = 1;
                p1.Reverse();
                for (int i = 1; i <= p1.Count; i++)
                {
                    score += i * p1[i - 1];
                }
            }
            else
            {
                player = 2;
                p2.Reverse();
                for (int i = 1; i <= p2.Count; i++)
                {
                    score += i * p2[i - 1];
                }
            }

            //Console.WriteLine("Rounds: " + rounds);
            //Console.WriteLine("Score: " + score);

            return score;
        }
    }

}
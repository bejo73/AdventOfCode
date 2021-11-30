using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    class Day18
    {
        public static void Run()
        {
            string line;
            StreamReader file = new StreamReader(@"./Data/Day18_Test.txt");

            long a = 0;
            while ((line = file.ReadLine()) != null)
            {
                //Console.WriteLine(GetResult(line.Replace(" ", "")));
                //a += GetResult(line.Replace(" ", ""));
                a += GetResult2(line.Replace(" ", ""));
            }
          
            Console.WriteLine("Day10 (1): " + a);
            Console.WriteLine("      (2): " + "TBD");
        }

        public static long GetResult(string str)
        {
            long result = 0;

            StringBuilder num = new StringBuilder();

            bool first = true;
            bool second = true;
            long num1 = 0;
            long num2 = 0;
            char operand = '+';

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                switch (c)
                {
                    case '(':



                        var stack = new Stack<int>();
                        bool leave = false;



                        for (; i < str.Length; i++)
                        {
                            char ic = str[i];
                            switch (ic)
                            {
                                case '(':
                                    stack.Push(i);
                                    break;
                                case ')':
                                    int index = stack.Any() ? stack.Pop() : -1;
                                    string p = str.Substring(index + 1, i - (index + 1));
                                    //int g = GetResult(p);
                                    num2 = GetResult(p);


                                    num.Clear();
                                    num.Append(num2);

                                    if (!stack.Any())
                                    {
                                        leave = true;
                                    }



                                    break;
                                default:
                                    break;
                            }

                            if (leave)
                            {
                                break;
                            }

                        }
                        break;
                    case ')':
                        Console.WriteLine(")");
                        break;
                    case '+':
                        if (first)
                        {
                            num1 = int.Parse(num.ToString());
                            num.Clear();
                            first = false;
                        }
                        else
                        {
                            num2 = int.Parse(num.ToString());
                            num.Clear();
                            if (operand == '+')
                            {
                                num1 = num1 + num2;
                            }
                            else
                            {
                                num1 = num1 * num2;
                            }
                        }
                        operand = '+';
                        break;
                    case '*':
                        if (first)
                        {
                            num1 = int.Parse(num.ToString());
                            num.Clear();
                            first = false;
                        }
                        else
                        {
                            num2 = int.Parse(num.ToString());
                            num.Clear();
                            if (operand == '+')
                            {
                                num1 = num1 + num2;
                            }
                            else
                            {
                                num1 = num1 * num2;
                            }
                        }
                        operand = '*';
                        break;
                    default:
                        num.Append(str[i]);
                        break;
                }
            }

            if (operand == '+')
            {
                result = num1 + int.Parse(num.ToString());
                num.Clear();
            }
            else
            {
                result = num1 * int.Parse(num.ToString());
                num.Clear();
            }

            return result;
        }

        static List<long> mult = new List<long>();

        public static long GetResult2(string str)
        {
            long result = 0;

            StringBuilder num = new StringBuilder();

            bool first = true;
            bool second = true;
            long num1 = 0;
            long num2 = 0;
            long numAddTmp = 0;
            char operand = '+';

            

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                switch (c)
                {
                    case '(':
                        var stack = new Stack<int>();
                        bool leave = false;

                        for (; i < str.Length; i++)
                        {
                            char ic = str[i];
                            switch (ic)
                            {
                                case '(':
                                    stack.Push(i);
                                    break;
                                case ')':
                                    int index = stack.Any() ? stack.Pop() : -1;
                                    string p = str.Substring(index + 1, i - (index + 1));
                                    num2 = GetResult2(p);
                                    num.Clear();
                                    num.Append(num2);

                                    if (!stack.Any())
                                    {
                                        leave = true;
                                    }

                                    break;
                                default:
                                    break;
                            }

                            if (leave)
                            {
                                break;
                            }

                        }
                        break;
                    case ')':
                        Console.WriteLine(")");
                        break;
                        
                    case '+':
                        if (first)
                        {
                            num1 = int.Parse(num.ToString());
                            num.Clear();
                            first = false;
                        }
                        else
                        {
                            num2 = int.Parse(num.ToString());
                            num.Clear();
                            if (operand == '+')
                            {
                                numAddTmp = numAddTmp + num2;
                            }
                            else
                            {
                                numAddTmp = num2;
                                //num1 = num1 * num2;
                            }
                        }
                        operand = '+';
                        break;
                    case '*':
                        // 2*3+2*4
                        if (first)
                        {
                            num1 = int.Parse(num.ToString());
                            num.Clear();
                            first = false;
                            mult.Add(num1);
                        }
                        else
                        {
                            num2 = int.Parse(num.ToString());
                            num.Clear();
                            if (operand == '+')
                            {
                                num1 = num1 + numAddTmp;
                            }
                            else
                            {
                                mult.Add(num2);
                                num1 = num1 * num2;
                            }
                        }
                        operand = '*';
                        break;
                    default:
                        num.Append(str[i]);
                        break;
                }
            }

            if (operand == '+')
            {
                result = num1 + int.Parse(num.ToString());
                num.Clear();
            }
            else
            {
                result = num1 * int.Parse(num.ToString());
                num.Clear();
            }

            return result;
        }
    }
}
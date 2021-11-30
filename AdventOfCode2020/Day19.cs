using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    class Day19
    {
        public static List<Node> nodes = new List<Node>();

        public static void Run()
        {
            string line;
            StreamReader file = new StreamReader(@"./Data/Day19.txt");

            List<string> messages = new List<string>();

            Regex r = new Regex("(([0-9]*): ([ 0-9]+)[|]{0,1}([ 0-9]*))|(([0-9]*): \"([ab]{1,1})\")");

            while ((line = file.ReadLine()) != "")
            {
                Match m = r.Match(line);
                if (m.Success)
                {
                    Node n = new Node();
                    if (m.Groups[2].Value.Trim().Length > 0)
                    {
                        n.Id = int.Parse(m.Groups[2].Value);

                        // First rule
                        if (m.Groups[3].Value.Trim().Length > 0)
                        {
                            string[] ruleStringIds = m.Groups[3].Value.Trim().Split(' ');
                            List<int> ids = ruleStringIds.ToList().ConvertAll(int.Parse);
                            n.PrimaryRuleIds = ids;
                        }

                        // Second rule
                        if (m.Groups[4].Value.Trim().Length > 0)
                        {
                            string[] ruleStringIds = m.Groups[4].Value.Trim().Split(' ');
                            List<int> ids = ruleStringIds.ToList().ConvertAll(int.Parse);
                            n.SecondaryRuleIds = ids;
                        }
                    }
                    else if (m.Groups[6].Value.Trim().Length > 0)
                    {
                        n.Id = int.Parse(m.Groups[6].Value);
                        n.PrimaryRule = m.Groups[7].Value;
                    }
                    nodes.Add(n);
                }
            }

            while ((line = file.ReadLine()) != null)
            {
                if (line.Trim().Length > 0)
                    messages.Add(line);
            }

            Node nodeZero = nodes.FirstOrDefault(n => n.Id == 0);

            List<string> rules = GetListOfRules(nodeZero);

            int part1Counter = 0;

            foreach (string rule in rules)
            {
                if (messages.Contains(rule))
                {
                    part1Counter++;
                }
            }

            Console.WriteLine("Day10 (1): " + part1Counter);
            Console.WriteLine("      (2): " + "TBD");
        }

        public static List<string> GetListOfRules(Node node)
        {
            List<string> rules = new List<string>();

            List<string> subRulesPrim = new List<string>();
            List<string> subRulesSec = new List<string>();

            if (node.PrimaryRuleIds != null)
            {
                foreach (int id in node.PrimaryRuleIds)
                {
                    Node n = nodes.FirstOrDefault(i => i.Id == id);

                    List<string> nodeRules = GetListOfRules(n);
                    List<string> subRulesTmp = new List<string>();

                    if (subRulesPrim.Count == 0)
                    {
                        subRulesPrim = nodeRules.ToList();
                    }
                    else
                    {
                        foreach (var sr in subRulesPrim)
                        {
                            foreach (var nr in nodeRules)
                            {
                                subRulesTmp.Add(sr + nr);
                            }
                        }
                        subRulesPrim = subRulesTmp.ToList();
                    }
                }

                if (node.SecondaryRuleIds != null)
                {
                    foreach (int id in node.SecondaryRuleIds)
                    {
                        Node n = nodes.FirstOrDefault(i => i.Id == id);

                        List<string> nodeRules = GetListOfRules(n);
                        List<string> subRulesTmp = new List<string>();

                        if (subRulesSec.Count == 0)
                        {
                            subRulesSec = nodeRules.ToList();
                        }
                        else
                        {
                            foreach (var sr in subRulesSec)
                            {
                                foreach (var nr in nodeRules)
                                {
                                    subRulesTmp.Add(sr + nr);
                                }
                            }
                            subRulesSec = subRulesTmp.ToList();
                        }
                    }
                }
                rules = subRulesPrim.Concat(subRulesSec).ToList();
            }
            else
            {
                rules.Add(node.PrimaryRule);
            }

            return rules;
        }
    }

    public class Node
    {
        public int Id { get; set; }
        public List<int> PrimaryRuleIds { get; set; }
        public List<int> SecondaryRuleIds { get; set; }
        public string PrimaryRule { get; set; }
    }
}
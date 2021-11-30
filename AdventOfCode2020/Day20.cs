using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    class Day20
    {
        public static void Run()
        {
            string line;
            StreamReader file = new StreamReader(@"./Data/Day20.txt");

            List<Tile> tiles = new List<Tile>();

            Regex r = new Regex("Tile ([0-9]*):");
            while ((line = file.ReadLine()) != null)
            {
                Match m = r.Match(line);
                if (m.Success)
                {
                    Tile t = new Tile()
                    {
                        Id = int.Parse(m.Groups[1].Value)
                    };

                    List<string> lines = new List<string>();
                    while (!string.IsNullOrEmpty(line = file.ReadLine()))
                    {
                        lines.Add(line);
                    }

                    t.RawLines = lines;
                    t.DefineSides();
                    tiles.Add(t);
                }
            }

            long part1 = 1;

            int matches = 0;
            for (int i = 0; i < tiles.Count; i++)
            {
                foreach (var s in tiles[i].Sides)
                {
                    for (int j = 0; j < tiles.Count; j++)
                    {
                        foreach (var js in tiles[j].Sides)
                        {
                            if (s.Pattern == js.ReversePattern || s.Pattern == js.Pattern)
                            {
                                matches++;
                            }
                        }
                    }
                }

                if ((matches - 4) < 3)
                {
                    part1 = part1 * tiles[i].Id;
                }

                matches = 0;
            }

            Console.WriteLine("Day10 (1): " + part1);
            Console.WriteLine("      (2): TBD");
        }
    }

    class Tile
    {
        public int Id { get; set; }
        public List<string> RawLines { get; set; }
        public List<Side> Sides { get; set; }
        //public bool IsBorder { get; set; }
        //public bool IsCorner { get; set; }
        public void DefineSides()
        {
            this.Sides = new List<Side>();

            // Side 0 - Up
            Side s = new Side();
            string binarySideStr = RawLines[0].Replace('.', '0').Replace('#', '1');
            s.Pattern = Convert.ToInt32(binarySideStr, 2);

            char[] array = binarySideStr.ToCharArray();
            Array.Reverse(array);
            string reversedString = new String(array);
            s.ReversePattern = Convert.ToInt32(reversedString, 2);
            this.Sides.Add(s);

            // Side 1 - Right
            s = new Side();
            StringBuilder tmpSb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                tmpSb.Append(RawLines[i][9]);
            }
            binarySideStr = tmpSb.ToString().Replace('.', '0').Replace('#', '1');
            s.Pattern = Convert.ToInt32(binarySideStr, 2);

            array = binarySideStr.ToCharArray();
            Array.Reverse(array);
            reversedString = new String(array);
            s.ReversePattern = Convert.ToInt32(reversedString, 2);
            this.Sides.Add(s);

            // Side 2 - Down
            s = new Side();
            binarySideStr = RawLines[9].Replace('.', '0').Replace('#', '1');
            s.ReversePattern = Convert.ToInt32(binarySideStr, 2);

            array = binarySideStr.ToCharArray();
            Array.Reverse(array);
            reversedString = new String(array);
            s.Pattern = Convert.ToInt32(reversedString, 2);
            this.Sides.Add(s);

            // Side 3 - Left
            s = new Side();
            tmpSb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                tmpSb.Append(RawLines[i][0]);
            }
            binarySideStr = tmpSb.ToString().Replace('.', '0').Replace('#', '1');
            s.ReversePattern = Convert.ToInt32(binarySideStr, 2);

            array = binarySideStr.ToCharArray();
            Array.Reverse(array);
            reversedString = new String(array);
            s.Pattern = Convert.ToInt32(reversedString, 2);
            this.Sides.Add(s);
        }
    }

    class Side
    {
        public int Pattern { get; set; }
        public int ReversePattern { get; set; }
        //public bool IsBorder { get; set; }
    }
}
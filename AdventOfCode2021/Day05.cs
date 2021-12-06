class Day05
{
    public static void Run()
    {
        
        List<string> lines = File.ReadAllLines(@"./Data/Day05.txt").ToList();

        int size = 1000;
        int[,] grid1 = new int[size,size];
        int[,] grid2 = new int[size,size];

        foreach (string line in lines)
        {
            string[] points = line.Split(" -> ");

            int[] p1 = Array.ConvertAll(points[0].Split(","), s => int.Parse(s));
            int[] p2 = Array.ConvertAll(points[1].Split(","), s => int.Parse(s));

            // Horizontal and vertical lines
            if (p1[0] == p2[0] || p1[1] == p2[1])
            {
                if (p2[0] >= p1[0])
                {
                    if (p2[1] >= p1[1])
                    {
                        for (int x = p1[0]; x <= p2[0]; x++)
                        {
                            for (int y = p1[1]; y <= p2[1]; y++)
                            {
                                grid1[x,y]++;
                                grid2[x,y]++;
                            }
                        }
                    }
                    else
                    {
                        for (int x = p1[0]; x <= p2[0]; x++)
                        {
                            for (int y = p1[1]; y >= p2[1]; y--)
                            {
                                grid1[x,y]++;
                                grid2[x,y]++;
                            }
                        }
                    }                    
                }
                else
                {
                    if (p2[1] >= p1[1])
                    {
                        for (int x = p1[0]; x >= p2[0]; x--)
                        {
                            for (int y = p1[1]; y <= p2[1]; y++)
                            {
                                grid1[x,y]++;
                                grid2[x,y]++;
                            }
                        }
                    }
                    else
                    {
                        for (int x = p1[0]; x >= p2[0]; x--)
                        {
                            for (int y = p1[1]; y >= p2[1]; y--)
                            {
                                grid1[x,y]++;
                                grid2[x,y]++;
                            }
                        }
                    }
                }
            }
            else
            {
                // Diagonal line at exactly 45 degrees
                if (Math.Abs(p1[0] - p2[0]) == Math.Abs(p1[1] - p2[1]))
                {
                    for (int n = 0; n <= Math.Abs(p1[0] - p2[0]); n++)
                    {
                        int x = p1[0] - n;
                        if (p2[0] >= p1[0])
                        {
                            x = p1[0] + n;
                        }

                        int y = p1[1] + n;
                        if (p1[1] >= p2[1])
                        {
                            y = p1[1] - n;
                        }

                        grid2[x,y]++; 
                    }
                }
            }
        }

        int c = 0;
        for (int a = 0; a < size; a++)
        {
            for (int b = 0; b < size; b++)
            {
                if (grid1[a,b] > 1) c++;
            }
        }

        Console.WriteLine("Day1 (1): " + c);

        c = 0;
        for (int a = 0; a < size; a++)
        {
            for (int b = 0; b < size; b++)
            {
                if (grid2[a,b] > 1) c++;
            }
        }

        Console.WriteLine("     (2): " + c);
    }
}
class Day09
{
    public static void Run()
    {
        List<string> lines = File.ReadAllLines(@"./Data/Day09.txt").ToList();
        string[] lines2 = File.ReadAllLines(@"./Data/Day09.txt").ToArray<string>();
        
        int hh = Day9_2(lines2);

        int xLength = lines[0].Length;
        int yLength = lines.Count;

        int[,] map = new int[xLength,yLength];

        HashSet<string> taken = new HashSet<string>();

        List<int> jjj = new List<int>();


        int j = 0;
        foreach (string line in lines)
        {
            for (int i = 0; i < line.Length; i++)
            {
                map[i,j] = Convert.ToInt32(line[i].ToString());
            }    
            j++;
        }

        int sum = 0;
        for (int x = 0; x < xLength; x++)
        {
            for (int y = 0; y < yLength; y++)
            {
                int lp = map[x,y];

                int e = int.MaxValue;
                int w = int.MaxValue;
               int n = int.MaxValue;
                int s = int.MaxValue;

                if (x == 0)
                {
                    e = map[x+1,y];
                }
                else if (x == xLength - 1)
                {
                    w = map[x-1,y];
                }
                else
                {
                    e = map[x+1,y];
                    w = map[x-1,y];
                }

                if (y == 0)
                {
                    n = map[x,y+1];
                }
                else if (y == yLength - 1)
                {
                    s = map[x,y-1];
                }
                else
                {
                    n = map[x,y+1];
                    s = map[x,y-1];
                }
                
                

                // Low point found
                if (lp < e && lp < w && lp < n && lp < s)
                {
                        sum = sum + lp +1;

                        int  g = Recursive(x, y, xLength, yLength, map, taken);
                        //hs = new HashSet<string>();
                        jjj.Add(g);

                }
                
            }



        }

  
        Console.WriteLine(String.Join("; ", jjj));  // "1; 2; 3"
        
        var hej = jjj.OrderByDescending(i => i).Take(3);

        

        Console.WriteLine("Day1 (1): " + sum);
        //Console.WriteLine("     (2): " + lo);
    }

    static int Day9_1(string[] lines)
{
    var lowestPoints = GetLowestPoints(lines);

    var riskLevel = lowestPoints.Values.Sum(x => x + 1);

    return riskLevel;
}

static Dictionary<(int y, int x), int> GetLowestPoints(string[] lines)
{
    Dictionary<(int y, int x), int> lowestPoints = new();

    var ymax = lines.Length - 1;
    var xmax = lines[0].Length - 1;

    for (var y = 0; y <= ymax; y++)
    for (var x = 0; x <= xmax; x++)
    {
        var c = lines[y][x];
        if ((y == 0 || c < lines[y-1][x]) 
            && (y == ymax || c < lines[y+1][x])
            && (x == 0 || c < lines[y][x-1])
            && (x == xmax || c < lines[y][x+1]))
        {
            lowestPoints[(y, x)] = c - '0';
        }
    }

    return lowestPoints;
}

static int Day9_2(string[] lines)
{
    var lowPoints = GetLowestPoints(lines);
    var sizes = new List<int>();

    var ymax = lines.Length - 1;
    var xmax = lines[0].Length - 1;

    foreach (var (pos, _) in lowPoints)
    {
        var size = GetBasinSize(lines, pos);
        sizes.Add(size);
    }

Console.WriteLine(String.Join("; ", sizes));  // "1; 2; 3"
    return sizes.OrderByDescending(x => x).Take(3).Aggregate((a, x) => a * x);

    int GetBasinSize(string[] lines, (int y, int x) seed)
    {
        HashSet<(int y, int x)> seen = new();
        Queue<(int y, int x)> work = new();

        work.Enqueue(seed);

        while (work.Count > 0)
        {
            var pos = work.Dequeue();
            Grow(pos);
        }

        return seen.Count(pos => lines[pos.y][pos.x] != '9');

        void Grow((int y, int x) pos)
        {
            if (!seen.Contains(pos))
            {
                seen.Add(pos);
                var c = lines[pos.y][pos.x];

                if (c == '9') return;

                AddWork(c, -1,  0);
                AddWork(c,  1,  0);
                AddWork(c,  0, -1);
                AddWork(c,  0,  1);
            }

            void AddWork(char c, int dy, int dx)
            {
                var ny = pos.y + dy;
                var nx = pos.x + dx;
                var npos = (ny, nx);

                if (!seen.Contains(npos)
                    && ny >= 0 && ny <= ymax 
                    && nx >= 0 && nx <= xmax 
                    && c < lines[ny][nx])
                {
                    work.Enqueue(npos);
                }
            }
        }
    }
}

    public static int Recursive(int x, int y, int xLength, int yLength, int[,] map, HashSet<string> taken)
    {
        
        string k = "" + x;
        k = k.PadLeft(4, '0');
        string m = "" + y;
        m = m.PadLeft(4, '0');
        string o = k+m;

        if (taken.Contains(o))
            return 0;
        else
            taken.Add(o);

        int result = 1;
  
        int lp = map[x,y];

        if (lp < 8)
        {
            if (x == 0)
            {
                if (lp + 1 == map[x+1,y])
                    result = result + Recursive(x+1, y, xLength, yLength, map, taken);
            }
            else if (x == xLength - 1)
            {
                if (lp + 1 == map[x-1,y])
                    result = result + Recursive(x-1, y, xLength, yLength, map, taken);
            }
            else
            {
                if (lp + 1 == map[x+1,y])
                    result = result + Recursive(x+1, y, xLength, yLength, map, taken);
                if (lp + 1 == map[x-1,y])
                    result = result + Recursive(x-1, y, xLength, yLength, map, taken);
            }

            if (y == 0)
            {
                if (lp + 1 == map[x,y+1])
                    result = result + Recursive(x, y+1, xLength, yLength, map, taken);
            }
            else if (y == yLength - 1)
            {
                if (lp + 1 == map[x,y-1])
                    result = result + Recursive(x, y-1, xLength, yLength, map, taken);
            }
            else
            {
                if (lp + 1 == map[x,y+1])
                    result = result + Recursive(x, y+1, xLength, yLength, map, taken);
                if (lp + 1 == map[x,y-1])
                    result = result + Recursive(x, y-1, xLength, yLength, map, taken);
            }
        }

        return result;
    } 
}
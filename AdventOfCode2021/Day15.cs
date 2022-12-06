class Day15
{
    public static void Run()
    {
        List<string> lines = File.ReadAllLines(@"./Data/Day15.txt").ToList();

        var grid = new SquareGrid(lines[0].Length, lines.Count);
        
        int y = 0;
        foreach (string line in lines)
        {
            List<int> xx = new List<int>();
            for (int x = 0; x < line.Length; x++)
            {
                int val = Convert.ToInt32(line[x].ToString());
                xx.Add(val);
                grid.locations.Add(new Location(x, y, val));
          
            }
            
            grid.costGrid.Add(xx);
            y++;
        }

        var astar = new AStarSearch(grid, new Location(0, 0),
                                    new Location(grid.width - 1, grid.height - 1));



        grid = new SquareGrid(lines[0].Length * 5, lines.Count * 5);
        
        y = 0;
        foreach (string line in lines)
        {
            List<int> xx = new List<int>();
            for (int a = 0; a < 5; a++)
            {
                for (int x = 0; x < line.Length; x++)
                {
                    int val = Convert.ToInt32(line[x].ToString());
                    val = val  + a;
                    if (val > 9) val = val -9;
                    xx.Add(val);
                    
                    grid.locations.Add(new Location(x + a * 10, y, val)); 
                }
            }
            grid.costGrid.Add(xx);
            y++;
        }

       List<List<int>> clonedList = new List<List<int>>(grid.costGrid);
        //List<Location> clonedList = new List<Location>(grid.locations);

        for (int b = 1; b < 5; b++)
        {
            foreach (List<int> ints in clonedList)
            //foreach (Location ints in clonedList)
            {
                List<int> yy = new List<int>();

                for (int x = 0; x < ints.Count; x++)
                {
                    int val = ints[x];
                    val = val  + b;
                    if (val > 9) val =   val -9;
                    yy.Add(val);

                    int u = grid.locations.Count();

                    grid.locations.Add(new Location(x, y, val)); 
          
                }

                grid.costGrid.Add(yy);
                y++;

            }
        }
    
        Location start = new Location(0, 0);
        Location end = new Location(grid.width - 1, grid.height - 1);

        var astar2 = new AStarSearch(grid, start, end);

        Console.WriteLine("Day15 (1): " + astar.costSoFar.Last().Value);

        var t = astar2.costSoFar.Reverse();

        Console.WriteLine("      (2): " + astar2.costSoFar.FirstOrDefault(l => l.Key.x == grid.width - 1 && l.Key.y == grid.height - 1).ToString());
    }
}
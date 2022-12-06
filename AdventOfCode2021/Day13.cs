class Day13
{
    public static void Run()
    {
        List<string> lines = File.ReadAllLines(@"./Data/Day13.txt").ToList();
        
        List<List<char>> grid = new List<List<char>>();

        foreach (string line in lines)
        {
            List<char> chars = new List<char>();
            for (int i = 0; i < line.Length; i++)
            {
                chars.Add(line[i]);
            }
            grid.Add(chars);
        }

         int flash = 0;
            int counter = 0;
       
        

        Console.WriteLine("Day11 (1): " + flash);
        Console.WriteLine("      (2): " + counter);
    }
}
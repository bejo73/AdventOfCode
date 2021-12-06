class Day06
{
    public static void Run()
    {
        
        List<string> lines = File.ReadAllLines(@"./Data/Day06.txt").ToList();
        List<int> numbers = lines[0].Split(",").Select(x => int.Parse(x)).ToList();

        // 1
        int numberOfDays = 80;

        List<int> current = new List<int>(numbers);
        List<int> next = new List<int>();

        for (int i = 0; i < numberOfDays; i++)
        {
            int newFishes = 0;
            foreach (int fish in current)
            {
                if (fish == 0)
                {
                    next.Add(6);
                    newFishes++;
                }
                else
                {
                    next.Add(fish - 1);
                }
            }

            for (int f = 0; f < newFishes; f++)
            {
                next.Add(8);
            }

            current = new List<int>(next);
            next = new List<int>();
        }

        // 2
        numberOfDays = 256;

        long[] days = new long[9];
        long[] nextdays = new long[9];

        foreach(int f in numbers)
        {
            days[f]++;
        }

        for (int i = 0; i < numberOfDays; i++)
        {
            nextdays[8] = days[0];
            nextdays[7] = days[8];
            nextdays[6] = days[7] + days[0];
            nextdays[5] = days[6];
            nextdays[4] = days[5];
            nextdays[3] = days[4];
            nextdays[2] = days[3];
            nextdays[1] = days[2];
            nextdays[0] = days[1];
            
            nextdays.CopyTo(days,0);
        }

        Console.WriteLine("Day1 (1): " + current.Count());
        Console.WriteLine("     (2): " + days.Sum());
    }
}
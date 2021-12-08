class Day07
{
    public static void Run()
    {

        List<string> lines = File.ReadAllLines(@"./Data/Day07.txt").ToList();
        int[] numbers = lines[0].Split(",").Select(x => int.Parse(x)).ToArray<int>();

        // 1
        int middle = numbers.Length / 2;
        var sortedNumbers = (int[])numbers.Clone();
        Array.Sort(sortedNumbers);

        // int median = Convert.ToInt32((numbers.Length % 2 != 0) ? (double)sortedNumbers[mid] : ((double)sortedNumbers[mid] + (double)sortedNumbers[mid - 1]) / 2);
        int median;
        if ((numbers.Length % 2) == 0)
        {
            median = Convert.ToInt32((sortedNumbers.ElementAt(middle) + sortedNumbers.ElementAt(middle - 1)) / 2);
        }
        else
        {
            median = Convert.ToInt32(sortedNumbers.ElementAt(middle));
        }

        //for (int i = median; i <= median; i++)
        //{

        long fuel1 = 0;
        foreach (int n in numbers)
        {
            long distance = n - median;
            fuel1 = fuel1 + Math.Abs(distance);
        }

        //Console.WriteLine("f: " + "i=" + median + "," + fuel1);
        //}

        // 2
        int mean = Convert.ToInt32(Math.Floor(numbers.Average()));

        //for (int i = mean; i <= mean ; i++)
        //{

        long fuel2 = 0;
        foreach (int n in numbers)
        {
            int steps = Math.Abs(n - mean);
            int cost = 0;
            for (int u = 1; u <= steps; u++)
            {
                cost = cost + u;
            }
            fuel2 = fuel2 + Math.Abs(cost);
        }

        //Console.WriteLine("h: " + "i=" + mean + "," + fuel2);
        //}


        Console.WriteLine("Day1 (1): " + "Median=" + median + ", Fuel=" + fuel1);
        Console.WriteLine("     (2): " + "Mean=" + mean + ", Fuel=" + fuel2);
    }
}
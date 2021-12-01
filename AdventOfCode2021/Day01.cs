class Day01
{
    public static void Run()
    {
        int result1 = 0;
        int result2 = 0;

        int[] sweepList = File.ReadAllLines(@"./Data/Day01.txt").Select(Int32.Parse).ToArray();

        // 1
        for (int i = 1; i < sweepList.Length; i++)
        {
            if (sweepList[i] > sweepList[i-1])
                result1++;
        }

        // 2
        for (int i = 2; i < sweepList.Length - 1; i++)
        {
            if ((sweepList[i-1] + sweepList[i] + sweepList[i+1]) > (sweepList[i-2] + sweepList[i-1] + sweepList[i]))
                result2++;
        }

        Console.WriteLine("Day1 (1): " + result1);
        Console.WriteLine("     (2): " + result2);
    }
}
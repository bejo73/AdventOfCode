class Day03
{
    public static void Run()
    {
        List<string> diagnosticReport = File.ReadAllLines(@"./Data/Day03.txt").ToList<string>();
        int binaryNumberlength = diagnosticReport[0].Length;

        // 1
        int[] binaryNumberCount = new int[binaryNumberlength];
        string gamma = "";
        string epsilon = "";

        for (int i = 0; i < diagnosticReport.Count; i++)
        {
            for (int j = 0; j < binaryNumberlength; j++)
            {
                if (diagnosticReport[i][j] == '0')
                    binaryNumberCount[j]--;
                else
                    binaryNumberCount[j]++;
            }
        }

        for (int j = 0; j < binaryNumberlength; j++)
        {
            if (binaryNumberCount[j] < 0)
            {
                gamma = gamma + "0";
                epsilon = epsilon + "1";
            }
            else
            {
                gamma = gamma + "1";
                epsilon = epsilon + "0";
            }
        }

        Console.WriteLine("Day1 (1): " + Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2));

        // 2
        List<string> currentReport = new List<string>(diagnosticReport);
        List<string> nextReport = new List<string>();
        string oxygenGeneratorRating = "";

        // For every position
        for (int j = 0; j < binaryNumberlength; j++)
        {
            int a = 0;
            for (int i = 0; i < currentReport.Count; i++)
            {
                if (currentReport[i][j] == '0')
                    a--;
                else
                    a++;
            }

            if (a >= 0)
                nextReport = currentReport.Where(r => r[j] == '1').ToList<string>();
            else
                nextReport = currentReport.Where(r => r[j] == '0').ToList<string>();

            if (nextReport.Count == 1)
            {
                oxygenGeneratorRating = nextReport[0];
                break;
            }

            currentReport = new List<string>(nextReport);
        }

        currentReport = new List<string>(diagnosticReport);
        nextReport = new List<string>();
        string co2ScrubberRating = "";

        // For every position
        for (int j = 0; j < binaryNumberlength; j++)
        {
            int a = 0;
            for (int i = 0; i < currentReport.Count; i++)
            {
                if (currentReport[i][j] == '0')
                    a--;
                else
                    a++;
            }

            if (a >= 0)
                nextReport = currentReport.Where(r => r[j] == '0').ToList<string>();
            else
                nextReport = currentReport.Where(r => r[j] == '1').ToList<string>();

            if (nextReport.Count == 1)
            {
                co2ScrubberRating = nextReport[0];
                break;
            }

            currentReport = new List<string>(nextReport);
        }

        Console.WriteLine("     (2): " + Convert.ToInt32(oxygenGeneratorRating, 2) * Convert.ToInt32(co2ScrubberRating, 2));
    }
}
class Day08
{
    public static void Run()
    {
        List<string> lines = File.ReadAllLines(@"./Data/Day08.txt").ToList();

        int oneFourSevenOrEights = 0;
        int sumOfDigits = 0;

        foreach (string line in lines)
        {
            string[] s = line.Split('|');
            string[] digits = s[1].Trim().Split(' ');

            List<string> numbers = s[0].Trim().Split(' ').ToList<string>();

            string one = numbers.First(n => n.Length == 2);
            numbers.Remove(one);

            string four = numbers.First(n => n.Length == 4);
            numbers.Remove(four);

            string nine = numbers.First(n => (n.Length == 6 && n.Contains(four[0]) && n.Contains(four[1]) && n.Contains(four[2]) && n.Contains(four[3])));
            numbers.Remove(nine);

            string zero = numbers.First(n => (n.Length == 6 && n.Contains(one[0]) && n.Contains(one[1])));
            numbers.Remove(zero);

            string six = numbers.First(n => (n.Length == 6));
            numbers.Remove(six);

            string str = "";
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i].Length == 2)
                {
                    oneFourSevenOrEights++;
                    str = str + 1;
                }
                else if (digits[i].Length == 3)
                {
                    oneFourSevenOrEights++;
                    str = str + 7;
                }
                else if (digits[i].Length == 4)
                {
                    oneFourSevenOrEights++;
                    str = str + 4;
                }
                else if (digits[i].Length == 7)
                {
                    oneFourSevenOrEights++;
                    str = str + 8;
                }
                else if (digits[i].Length == 5)
                {
                    if (digits[i].Contains(one[0]) && digits[i].Contains(one[1]))
                    {
                        str = str + 3;
                    }
                    else if (six.Contains(digits[i][0]) && six.Contains(digits[i][1]) && six.Contains(digits[i][2]) && six.Contains(digits[i][3]) && six.Contains(digits[i][4]))
                    {
                        str = str + 5;
                    }
                    else
                    {
                        str = str + 2;
                    }
                }
                else if (digits[i].Length == 6)
                {
                    if (digits[i].Contains(four[0]) && digits[i].Contains(four[1]) && digits[i].Contains(four[2]) && digits[i].Contains(four[3]))
                    {
                        str = str + 9;
                    }
                    else if (digits[i].Contains(one[0]) && digits[i].Contains(one[1]))
                    {
                        str = str + 0;
                    }
                    else
                    {
                        str = str + 6;
                    }
                }
            }

            int a = Int32.Parse(str);
            sumOfDigits = sumOfDigits + a;
        }

        Console.WriteLine("Day1 (1): " + oneFourSevenOrEights);
        Console.WriteLine("     (2): " + sumOfDigits);
    }
}
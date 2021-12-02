class Day02
{
    public static void Run()
    {
        int length = 0;
        int depth = 0;

        string[] commands = File.ReadAllLines(@"./Data/Day02.txt").ToArray<string>();

        // 1
        for (int i = 0; i < commands.Length; i++)
        {
            string cmd = commands[i].Split(" ")[0];
            string val = commands[i].Split(" ")[1];

            if (cmd.ToLower().Equals("forward"))
            {
                length = length + Int32.Parse(val);
            }
            else if (cmd.ToLower().Equals("up"))
            {
                depth = depth - Int32.Parse(val);
            }
            else if (cmd.ToLower().Equals("down"))
            {
                depth = depth + Int32.Parse(val);
            }
        }

        Console.WriteLine("Day1 (1): " + length * depth);

        length = 0;
        depth = 0;
        int aim = 0;

        // 2
        for (int i = 0; i < commands.Length; i++)
        {
            string cmd = commands[i].Split(" ")[0];
            string val = commands[i].Split(" ")[1];

            if (cmd.ToLower().Equals("forward"))
            {
                length = length + Int32.Parse(val);
                depth = depth + (aim * Int32.Parse(val));
            }
            else if (cmd.ToLower().Equals("up"))
            {
                aim = aim - Int32.Parse(val);
            }
            else if (cmd.ToLower().Equals("down"))
            {
                aim = aim + Int32.Parse(val);
            }
        }

        Console.WriteLine("     (2): " + length * depth);
    }
}
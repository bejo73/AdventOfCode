class Day10
{
    public static void Run()
    {
        List<string> lines = File.ReadAllLines(@"./Data/Day10.txt").ToList();

        int syntaxErrorScore = 0;
        List<long> scores = new List<long>();

        foreach (string line in lines)
        {
            Stack<char> stack = new Stack<char>();

            bool corrupt  = false;

            for (int i = 0; i < line.Length; i++)
            {
                if (stack.Count > 0)
                {
                    char start = ' ';
                    int point = 3;

                    switch (line[i])
                    {
                        case ')':
                            start = '(';
                            break;
                        case '>':
                            start = '<';
                            point = 25137;
                            break;
                        case '}':
                            start = '{';
                            point = 1197;
                            break;
                        case ']':
                            start = '[';
                            point = 57;
                            break;
                        default:
                            break;
                    }

                    if (start == ' ')
                    {
                        stack.Push(line[i]);
                    }
                    else
                    {
                        if (stack.Peek() ==  start)
                        {
                            stack.Pop();
                        }
                        else
                        {
                            corrupt = true;
                            syntaxErrorScore = syntaxErrorScore + point;
                            break;
                        }
                    }         
                }
                else
                {
                    stack.Push(line[i]);
                }
            }
                        
            if (!corrupt)
            {
                long score = 0;

                while (stack.Count > 0)
                {
                    score = score * 5;

                    switch (stack.Pop())
                    {
                        case '{':
                            score = score + 3;
                            break;
                        case '(':
                            score = score + 1;
                            break;
                        case '[':
                            score = score + 2;
                            break;
                        case '<':
                            score = score + 4;
                            break;
                        default:
                            break;
                    }
                }
   
                 scores.Add(score);
            }
        }

        scores.Sort();
        double middle = scores.Count / 2;
        int middleIndex = Convert.ToInt32(Math.Floor(middle));

        Console.WriteLine("Day1 (1): " + syntaxErrorScore);
        Console.WriteLine("     (2): " + scores[middleIndex]);
    }
}
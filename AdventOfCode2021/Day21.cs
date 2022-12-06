class Day21
{
    public static void Run()
    {
        long result1 = 0;
        long dice = 0;

        long p1Score = 0;
        long p2Score = 0;
        long p1Space = 6;
        long p2Space = 2;

        long diceSum = 0;

        bool p1 = true;
        while (true)
        {
            
            diceSum = 3 * dice + 6;

            if (p1)
            {
                
                p1Space = (p1Space + diceSum) % 10;
                if (p1Space == 0) p1Space = 10;


                p1 = false;

                dice = dice + 3;

                p1Score = p1Score + p1Space;
                if (p1Score >= 1000)
                {
                    result1 = dice * p2Score;

                    break;
                }

            }
            else
            {
                p2Space = (p2Space + diceSum) % 10;
                if (p2Space == 0) p2Space = 10;
                p1 = true;

                p2Score = p2Score + p2Space;

                dice = dice + 3;

                if (p2Score >= 1000)
                {
                    result1 = dice * p1Score;

                    break;
                }
            }
            

        }


        Console.WriteLine("Day21 (1): " + result1 );
        Console.WriteLine("      (2): ");
    }
}
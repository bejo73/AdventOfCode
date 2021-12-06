class Day04
{
    public static void Run()
    {
        List<string> bingoLines = File.ReadAllLines(@"./Data/Day04.txt").ToList();
        List<int> numbers = bingoLines[0].Split(",").Select(x => int.Parse(x)).ToList();

        List<List<List<int>>> boards = new();

        int numberOfBoards = (bingoLines.Count - 1) / 6;

        for (int i = 0; i < numberOfBoards; i++)
        {
            var board = new List<List<int>>();
            for (int j = 0; j < 5; j++)
            {
                board.Add(bingoLines[2 + 6 * i + j].Split().Where(x => x.Trim() != "").Select(x => int.Parse(x)).ToList());
            }
            boards.Add(board);
        }

        int result1 = 0;
        int result2 = 0;

        // 1
        bool bingo = false;
        foreach (var number in numbers)
        {
            foreach (var board in boards)
            {
                for (var i = 0; i < 5; i++)
                {
                    for (var j = 0; j < 5; j++)
                    {
                        if (board[i][j] == number)
                            board[i][j] = -1;
                    }
                }
            }

            foreach (var board in boards)
            {
                for (var i = 0; i < 5; i++)
                {
                    if (board.Select(x => x[i]).Sum() == -5 )
                    {
                        result1 = board.SelectMany(x => x).Where(x => x != -1).Sum() * number;
                        bingo = true;
                        break;
                    }
                }
            }

            if (bingo) break;
        } 

        // 2
        foreach (var number in numbers)
            {
                foreach (var board in boards)
                {
                    for (var i = 0; i < 5; i++)
                        for (var j = 0; j < 5; j++)
                            if (board[i][j] == number)
                                board[i][j] = -1;
                }

                var winningBoards = new List<List<List<int>>>();

                foreach (var board in boards)
                {
                    for (var i = 0; i < 5; i++)
                    {
                        if ( board.Select(x => x[i]).Sum() == -5)
                        {
                            winningBoards.Add(board);
                        }
                    }
                }

                foreach (var board in winningBoards)
                {
                    boards.Remove(board);
                }

                if (boards.Count == 0)
                {
                    result2 = winningBoards[0].SelectMany(x => x).Where(x => x != -1).Sum() * number;
                    break;
                }
            }

        Console.WriteLine("Day1 (1): " + result1 );
        Console.WriteLine("     (2): " + result2 );
    }
}
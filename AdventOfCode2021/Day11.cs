class Day11
{
    public static void Run()
    {
        List<string> lines = File.ReadAllLines(@"./Data/Day11.txt").ToList();
        
        List<List<int>> nums = new List<List<int>>();

        foreach (string line in lines)
        {
            List<int> ints = new List<int>();
            for (int i = 0; i < line.Length; i++)
            {
                ints.Add(Convert.ToInt32(line[i].ToString()));
            }
            nums.Add(ints);
        }

         int flash = 0;
            int counter = 0;
        // 1
        for (int i = 0; i < 1000; i++)
        {
            // Increase all with one
            for (int a = 0; a < nums.Count; a++)
            {
                for (int b = 0; b < nums[a].Count; b++)
                {
                    nums[a][b] = nums[a][b] + 1;
                }
            }

            // while...
            bool ready = false;

            
            while(!ready)
            {
                ready = true;
                for (int a = 0; a < nums.Count; a++)
                {
                    for (int b = 0; b < nums[a].Count; b++)
                    {
                        if (nums[a][b] >= 10)
                        {
                            nums[a][b] = 0;
                            flash++;

                            if (a == 0)
                            {
                                if (b == 0)
                                {
                                    if (nums[a][b+1] > 0) nums[a][b+1]++;
                                    if (nums[a+1][b] > 0) nums[a+1][b]++;
                                    if (nums[a+1][b+1] > 0) nums[a+1][b+1]++;
                                }
                                else if (b == (nums[a].Count - 1))
                                {
                                    if (nums[a][b-1] > 0) nums[a][b-1]++;
                                    if (nums[a+1][b-1] > 0) nums[a+1][b-1]++;
                                    if (nums[a+1][b] > 0) nums[a+1][b]++;
                                }
                                else
                                {
                                    if (nums[a][b+1] > 0) nums[a][b+1]++;
                                    if (nums[a][b-1] > 0) nums[a][b-1]++;
                                    if (nums[a+1][b-1] > 0) nums[a+1][b-1]++;
                                    if (nums[a+1][b] > 0) nums[a+1][b]++;
                                    if (nums[a+1][b+1] > 0) nums[a+1][b+1]++;
                                }
                            }
                            else if (a == (nums.Count - 1))
                            {
                                if (b == 0)
                                {
                                    if (nums[a-1][b] > 0) nums[a-1][b]++;
                                    if (nums[a-1][b+1] > 0) nums[a-1][b+1]++;
                                    if (nums[a][b+1] > 0) nums[a][b+1]++;
                                }
                                else if (b == (nums[a].Count - 1))
                                {
                                    if (nums[a-1][b-1] > 0) nums[a-1][b-1]++;
                                    if (nums[a-1][b] > 0) nums[a-1][b]++;
                                    if (nums[a][b-1] > 0) nums[a][b-1]++;
                                }
                                else
                                {
                                    if (nums[a][b+1] > 0) nums[a][b+1]++;
                                    if (nums[a][b-1] > 0) nums[a][b-1]++;
                                    if (nums[a-1][b-1] > 0) nums[a-1][b-1]++;
                                    if (nums[a-1][b] > 0) nums[a-1][b]++;
                                    if (nums[a-1][b+1] > 0) nums[a-1][b+1]++;
                                }
                            }
                            else
                            {
                                if (b == 0)
                                {
                                    if (nums[a-1][b] > 0) nums[a-1][b]++;
                                    if (nums[a-1][b+1] > 0) nums[a-1][b+1]++;
                                    if (nums[a][b+1] > 0) nums[a][b+1]++;
                                    if (nums[a+1][b] > 0) nums[a+1][b]++;
                                    if (nums[a+1][b+1] > 0) nums[a+1][b+1]++;
                                }
                                else if (b == (nums[a].Count - 1))
                                {
                                    if (nums[a-1][b-1] > 0) nums[a-1][b-1]++;
                                    if (nums[a-1][b] > 0) nums[a-1][b]++;
                                    if (nums[a][b-1] > 0) nums[a][b-1]++;
                                    if (nums[a+1][b-1] > 0) nums[a+1][b-1]++;
                                    if (nums[a+1][b] > 0) nums[a+1][b]++;
                                }
                                else
                                {
                                    if (nums[a-1][b-1] > 0) nums[a-1][b-1]++;
                                    if (nums[a-1][b] > 0) nums[a-1][b]++;
                                    if (nums[a-1][b+1] > 0) nums[a-1][b+1]++;
                                    if (nums[a][b-1] > 0) nums[a][b-1]++;
                                    if (nums[a][b+1] > 0) nums[a][b+1]++;
                                    if (nums[a+1][b-1] > 0) nums[a+1][b-1]++;
                                    if (nums[a+1][b] > 0) nums[a+1][b]++;
                                    if (nums[a+1][b+1] > 0) nums[a+1][b+1]++;
                                }

                            }




                        }
                    }
                }

                for (int a = 0; a < nums.Count; a++)
                {
                    for (int b = 0; b < nums[a].Count; b++)
                    {
                        if (nums[a][b] >= 10)
                        {
                            ready = false;
                        
                        }


                    }
                }

            }
            

for (int a = 0; a < nums.Count; a++)
                {
                    for (int b = 0; b < nums[a].Count; b++)
                    {
                      

                        if (nums[a][b] == 0)
                        {
                            counter++;
                        }

                    }
                }
            if (counter == nums.Count * nums[0].Count)
            {
                counter = i;
                break;
            }
            else
            {
                counter = 0;
            }
        }
        

        Console.WriteLine("Day11 (1): " + flash);
        Console.WriteLine("      (2): " + counter);
    }
}
class Day14
{
    public static void Run()
    {
        List<string> lines = File.ReadAllLines(@"./Data/Day14.txt").ToList();

        string input = lines[0];
        int steps = 40;

        Dictionary<string, string> rules = new Dictionary<string, string>();

        for (int i = 2; i < lines.Count; i++)
        {
            string rule = lines[i];
            rules.Add(rule.Substring(0, 2), rule.Substring(6, 1));
        }

        Dictionary<string, string> patterns = new Dictionary<string, string>();

string od = input;
string ud ="";
        for (int s = 0; s < steps; s++)
        {
            int index = 0;
            var output = new System.Text.StringBuilder();

            Console.WriteLine(s);

                    
                    int hh = 1000 - 1;
                    int hg = (1000 - 1) * 2;
      

            while (index < input.Length)
            {

                if (od.Length > 2000)
                {
                
                               while (input.Substring(index).StartsWith(od.Substring(0,1000)))
                {
                    output.Append(input.Substring(0,hg));
                    index = index + hh;
                }
                }

                while (input.Substring(index).StartsWith("NBBNBBNBBNBBNBBNBBNBBNBB"))
                {
                    output.Append("NBBNBBNBBNBBNBBNBBNBBNBBNBBNBBNBBNBBNBBNBBNBBN");
                    index = index + 23;
                }


                while (input.Substring(index).StartsWith("NBBNBBNBBNBB"))
                {
                    output.Append("NBBNBBNBBNBBNBBNBBNBBN");
                    index = index + 11;
                }

                if (input.Substring(index).StartsWith("NBBNBBNBBNBB"))
                {
                    output.Append("NBBNBBNBBNBBNBBNBBNBBN");
                    index = index + 11;
                }  
                else if (input.Substring(index).StartsWith("NBBNBB"))
                {
                    output.Append("NBBNBBNBBN");
                    index = index + 5;
                }      



                if (input.Length - index > 1)
                {
                    string pair = input.Substring(index, 2);

                    string element = rules[pair];

                    if (!string.IsNullOrEmpty(element))
                    {
                        output.Append(pair.Substring(0, 1)).Append(element);
                        index = index + 1;
                    }
                    else
                    {
                        output.Append(pair.Substring(0, 1));
                        index = index + 1;

                    }
                }
                else
                {
                    output.Append(input.Substring(index, 1));
                    index = index + 1;
                }
            }
            
            if ( input.Length > 1000)
            {
                if (output.ToString().StartsWith(input.Substring(0,1000)))
                {
                    Console.WriteLine("STarts" + " input len = " + input.Length);
                    
                    od = input;


                 }
                else
                {

                    Console.WriteLine("Nej");
                }
            }

            input = output.ToString();
            Console.WriteLine(input);
        }

        int len = input.Length;

        var groups = input.ToList().GroupBy(x => x);
        var largest = groups.OrderByDescending(x => x.Count()).First();

        long max = largest.Count();

        var smallest = groups.OrderByDescending(x => x.Count()).Last();

        long min = smallest.Count();





        long flash = max - min;
        int counter = 0;



        Console.WriteLine("Day11 (1): " + flash);
        Console.WriteLine("      (2): " + counter);
    }
}
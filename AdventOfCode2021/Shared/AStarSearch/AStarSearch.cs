/* NOTE about types: in the main article, in the Python code I just
 * use numbers for costs, heuristics, and priorities. In the C++ code
 * I use a typedef for this, because you might want int or double or
 * another type. In this C# code I use double for costs, heuristics,
 * and priorities. You can use an int if you know your values are
 * always integers, and you can use a smaller size number if you know
 * the values are always small. */
 
class AStarSearch
{
    public Dictionary<Location, Location> cameFrom = new Dictionary<Location, Location>();
    public Dictionary<Location, double> costSoFar = new Dictionary<Location, double>();

    // Note: a generic version of A* would abstract over Location and
    // also Heuristic
    static public double Heuristic(Location a, Location b)
    {
        return Math.Abs(a.x - b.x) + Math.Abs(a.y - b.y);
    }

    public AStarSearch(WeightedGraph<Location> graph, Location start, Location goal)
    {
        var frontier = new PriorityQueue<Location>();
        //var frontier = new PriorityQueues.PriorityQueue<Location>();
        frontier.Enqueue(start, 0);
        //start.priority = 0;
        //frontier.Enqueue(start);

        cameFrom[start] = start;
        costSoFar[start] = 0;

        while (frontier.Count > 0)
        //while (frontier.Count() > 0)
        {
            var current = frontier.Dequeue();

            if (current.Equals(goal))
            {
                break;
            }

/*
            var ns = graph.Neighbors(current);
            for (int i = 0; i < ns.Count(); i++)
            {
                var next = ns.ElementAt(i);

                double newCost = costSoFar[current] + graph.Cost(current, next);

                if (!costSoFar.ContainsKey(next) || newCost < costSoFar[next])
                {
                    costSoFar[next] = newCost;
                    double priority = newCost + Heuristic(next, goal);

                    //frontier.Enqueue(next, priority);
                    next.priority = priority;
                    frontier.Enqueue(next);

                    cameFrom[next] = current;
                }
            }
*/
            foreach (var next in graph.Neighbors(current))
            {
                double newCost = costSoFar[current] + graph.Cost(current, next);
                //double newCost = costSoFar[current] + next.cost;

                if (!costSoFar.ContainsKey(next) || newCost < costSoFar[next])
                {
                    costSoFar[next] = newCost;
                    double priority = newCost + Heuristic(next, goal);

                    frontier.Enqueue(next, priority);
                    //next.priority = priority;
                    //frontier.Enqueue(next);

                    cameFrom[next] = current;
                }
            }
            
        }
    }
}
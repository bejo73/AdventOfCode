// A* needs only a WeightedGraph and a location type L, and does *not*
// have to be a grid. However, in the example code I am using a grid.



interface WeightedGraph<L>
{
    double Cost(Location a, Location b);
    IEnumerable<Location> Neighbors(Location id);
}

public struct Location 
//public struct Location : IComparable<Location>
//public class Location
{
    // Implementation notes: I am using the default Equals but it can
    // be slow. You'll probably want to override both Equals and
    // GetHashCode in a real project.

    public readonly int x, y;
    public int cost;


    //public double priority; // smaller values are higher priority

    //public Location(int x, int y)
    //{
    //    this.x = x;
    ///    this.y = y;
    //   this.cost = 1;
    //}

    //public Location(int x, int y, int cost = 1, double priority = 0)
    public Location(int x, int y, int cost = 1)
    {
        this.x = x;
        this.y = y;
        this.cost = cost;
        //this.priority = priority;
    }

/*
     public int CompareTo(Location other)
    {
      if (this.priority < other.priority) return -1;
      else if (this.priority > other.priority) return 1;
      else return 0;
    }
    */
}
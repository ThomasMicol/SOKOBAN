public class Movement
{
    protected Location startingLocation;
    protected Location endingLocation;

    public Movement(Location start, Location end)
    {
        startingLocation = start;
        endingLocation = end;
    }

    public Location GetStartingLocation()
    {
        return startingLocation;
    }

    public Location GetEndingLocation()
    {
        return endingLocation;
    }
}
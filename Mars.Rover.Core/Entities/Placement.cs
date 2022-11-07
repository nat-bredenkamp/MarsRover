namespace Mars.Rover.Core.Entities;

public class Placement
{
    public int X { get; set; }

    public int Y { get; set; }

    public Direction Direction { get; set; }

    public Placement()
    {
        
    }
    public Placement(Placement placement)
    {
        X = placement.X;
        Y = placement.Y;
        Direction = placement.Direction;
    }
    
    public Placement(string? instructions)
    {
        var placement = instructions.Split(" ");
        X = int.Parse(placement[0]);
        Y = int.Parse(placement[1]);
        Direction = placement[2] switch
        {
            "N" => Direction.N,
            "E" => Direction.E,
            "S" => Direction.S,
            "W" => Direction.W
        };
    }

    public Placement(int x, int y, Direction d)
    {
        X = x;
        Y = y;
        Direction = d;
    }
}
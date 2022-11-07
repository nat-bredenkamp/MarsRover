using Mars.Rover.Core.Entities;
using Mars.Rover.Core.Plateau;

namespace Mars.Rover.Core.Rover;

public class Rover : IRover
{
    public event EventHandler<PlacementEventArgs>? ReportPlacement;
    public Placement CurrentPlacement { get; set; }

    private readonly IPlateau _plateau;

    public Rover(IPlateau plateau)
    {
        _plateau = plateau;
        CurrentPlacement = new Placement();
    }

    public void Deploy(string? placementCommand)
    {
        var proposedPlacement = new Placement(placementCommand);
        if (!_plateau.IsValidPlacement(proposedPlacement))
        {
            throw new Exception("Invalid deployment for Rover, outside bounds of Plateau");
        }
        
        this.CurrentPlacement = new Placement(placementCommand);
        ReportPlacement?.Invoke(this, new PlacementEventArgs(new Placement(CurrentPlacement)));
    }
    
    public void TurnLeft()
    {
        CurrentPlacement.Direction = (int)CurrentPlacement.Direction - 1 < (int)Direction.N ? Direction.W : (Direction)((int)CurrentPlacement.Direction - 1);
        ReportPlacement?.Invoke(this, new PlacementEventArgs(new Placement(CurrentPlacement)));
    }

    public void TurnRight()
    {
        CurrentPlacement.Direction = ((int)CurrentPlacement.Direction + 1) > (int)Direction.W ? Direction.N : (Direction)((int)CurrentPlacement.Direction + 1);
        ReportPlacement?.Invoke(this, new PlacementEventArgs(new Placement(CurrentPlacement)));
    }

    public void MoveForward()
    {
        var proposedPlacement = CurrentPlacement;
        switch(CurrentPlacement.Direction) {
            case Direction.N:
                proposedPlacement.Y += 1;
                break;
            case Direction.E:
                proposedPlacement.X += 1;
                break;
            case Direction.S:
                proposedPlacement.Y -= 1;
                break;
            case Direction.W:
                proposedPlacement.X -= 1;
                break;
        }
        
        if(!_plateau.IsValidPlacement(proposedPlacement))
        {
            return;
        }

        CurrentPlacement = proposedPlacement;
        ReportPlacement?.Invoke(this, new PlacementEventArgs(new Placement(CurrentPlacement)));
    }
}

public class PlacementEventArgs
{
    public PlacementEventArgs(Placement placement)
    {
        Placement = placement;
    }
    
    public Placement Placement { get; }
}
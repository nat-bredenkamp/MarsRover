using Mars.Rover.Core.Entities;

namespace Mars.Rover.Core.Rover;

public interface IRover
{
    public event EventHandler<PlacementEventArgs>? ReportPlacement;
    Placement CurrentPlacement { get; set; }

    void MoveForward();
    void TurnLeft();
    void TurnRight();

    void Deploy(string? placementCommand);
}
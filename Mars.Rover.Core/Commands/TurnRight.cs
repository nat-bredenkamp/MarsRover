using Mars.Rover.Core.Rover;

namespace Mars.Rover.Core.Commands;

public class TurnRight : ICommand
{
    public void Execute(IRover rover)
    {
        rover.TurnRight();
    }
}
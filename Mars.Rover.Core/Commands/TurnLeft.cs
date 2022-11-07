using Mars.Rover.Core.Rover;

namespace Mars.Rover.Core.Commands;

public class TurnLeft : ICommand
{
    public void Execute(IRover rover)
    {
        rover.TurnLeft();
    }
}
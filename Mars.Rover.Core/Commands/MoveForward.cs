using Mars.Rover.Core.Rover;

namespace Mars.Rover.Core.Commands;

public class MoveForward : ICommand
{
    public void Execute(IRover rover)
    {
        rover.MoveForward();
    }
}
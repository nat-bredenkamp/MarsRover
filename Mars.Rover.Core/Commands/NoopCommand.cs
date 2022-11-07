using Mars.Rover.Core.Rover;

namespace Mars.Rover.Core.Commands;

public class NoopCommand : ICommand
{
    public void Execute(IRover rover)
    {
        //no op
    }
}
using Mars.Rover.Core.Rover;

namespace Mars.Rover.Core.Commands;

public interface ICommand
{
    void Execute(IRover rover);

    //void CancelCommand(IRover rover);
}
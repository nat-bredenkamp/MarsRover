using Mars.Rover.Core.Entities;
using Mars.Rover.Core.Rover;

namespace Mars.Rover.Core.Commands;

public interface ICommandInvoker
{
    void ExecuteCommands(string commands, IRover rover);
}
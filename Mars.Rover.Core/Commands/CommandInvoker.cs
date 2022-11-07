using Mars.Rover.Core.Entities;
using Mars.Rover.Core.Rover;

namespace Mars.Rover.Core.Commands;

public class CommandInvoker : ICommandInvoker
{
    private readonly ICommandParser _commandParser;

    private readonly List<Placement> _completedPlacements = new List<Placement>();
    
    public CommandInvoker(ICommandParser commandParser)
    {
        _commandParser = commandParser;
    }

    public void ExecuteCommands(string commands, IRover rover)
    {
        foreach (var movementCommand in commands)
        {
            var command = _commandParser.ParseCommand(movementCommand.ToString());
            command.Execute(rover);
        }
    }
}


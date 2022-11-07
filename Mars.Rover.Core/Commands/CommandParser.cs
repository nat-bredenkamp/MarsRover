namespace Mars.Rover.Core.Commands;

public class CommandParser : ICommandParser
{
    private static readonly Dictionary<string, ICommand> ValidCommands = new Dictionary<string, ICommand>()
    {
        { "M", new MoveForward() },
        { "L", new TurnLeft() },
        { "R", new TurnRight() }
    };
    
    public ICommand ParseCommand(string command)
    {
        return ValidCommands.ContainsKey(command)
            ? ValidCommands[command]
            : new NoopCommand();
    }
}
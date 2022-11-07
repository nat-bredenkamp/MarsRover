namespace Mars.Rover.Core.Commands;

public interface ICommandParser
{
    ICommand ParseCommand(string command);
}
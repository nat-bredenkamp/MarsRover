namespace Mars.Rover.Core.Entities;

public class Instruction
{
    public string? Deployment { get; set; }

    public string? Movement { get; set; }

    public override string ToString()
    {
        return $"{Deployment} - {Movement}{Environment.NewLine}";
    }
}
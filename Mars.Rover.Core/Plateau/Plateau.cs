using Mars.Rover.Core.Entities;

namespace Mars.Rover.Core.Plateau;

public class PlateauInstance : IPlateau
{
    public PlateauInstance()
    {
        Instructions = new List<Instruction>();
    }

    public PlateauInstance(int width, int height)
    {
        if (width < 1)
        {
            throw new ArgumentException("Width cannot be less than 1", nameof(width));
        }

        if (height < 1)
        {
            throw new ArgumentException("Height cannot be less than 1", nameof(height));
        }
        
        Width = width;
        Height = height;
    }

    public int Id { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public List<Instruction> Instructions { get; set; }
    
    public bool IsValidPlacement(Placement placement)
    {
        return placement.X <= Width && placement.Y <= Height && placement.X >= 0 && placement.Y >= 0;
    }
}
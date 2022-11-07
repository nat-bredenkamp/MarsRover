using Mars.Rover.Core.Entities;

namespace Mars.Rover.Core.Plateau;

public interface IPlateau
{
    int Width { get; set; }
    int Height { get; set; }

    bool IsValidPlacement(Placement placement);
}
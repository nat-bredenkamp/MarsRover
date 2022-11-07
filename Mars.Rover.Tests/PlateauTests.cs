using Mars.Rover.Core.Entities;

namespace Mars.Rover.Core;

public class PlateauTests
{
    [Theory]
    [InlineData(6,5,Direction.N, false)]
    [InlineData(-1,5,Direction.N, false)]
    [InlineData(4,5,Direction.N, true)]
    [InlineData(1,-5,Direction.N, false)]
    public void IsValidPlacementReturnsTrueWhenMoveOnPlateau(int x, int y, Direction d, bool expected)
    {
        var sut = new Plateau.PlateauInstance(5, 5);
        var result = sut.IsValidPlacement(new Placement(x, y, d));

        Assert.Equal(expected, result);
    }
}
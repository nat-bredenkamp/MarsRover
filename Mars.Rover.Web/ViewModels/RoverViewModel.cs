using Mars.Rover.Core.Entities;
using Mars.Rover.Core.Plateau;

namespace Mars.Rover.Web.ViewModels;

public class RoverViewModel
{
    public Dictionary<string, List<Placement>> Rovers { get; set; }

    public PlateauInstance Plateau { get; set; }
}
using Mars.Rover.Core;
using Mars.Rover.Core.Commands;
using Mars.Rover.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Mars.Rover.Web.ViewModels;

namespace Mars.Rover.Web.Controllers;

public class RoverController : Controller
{
    private readonly IPlateauRepository _plateauRepository;
    private readonly ICommandInvoker _commandInvoker;
    private readonly string[] colours = new[] { "green", "red", "blue" };

    public RoverController(IPlateauRepository plateauRepository, ICommandInvoker commandInvoker)
    {
        _plateauRepository = plateauRepository;
        _commandInvoker = commandInvoker;
    }
    
    // GET  
    public IActionResult Index(int id)
    {
        var plateau = _plateauRepository.Get(id);
        if (plateau == null)
        {
            return NotFound();
        }
        
        var roverModel = new RoverViewModel
        {
            Plateau = plateau,
            Rovers = new Dictionary<string, List<Placement>>()
        };
        var i = 0;
        foreach (var instruction in plateau.Instructions)
        {
            var roverPaths = new List<Placement>();

            var rover = new Core.Rover.Rover(plateau);
            rover.ReportPlacement += (sender, args) => { roverPaths.Add(args.Placement); };
            rover.Deploy(instruction.Deployment);

            _commandInvoker.ExecuteCommands(instruction.Movement, rover);
            roverModel.Rovers.Add(colours[i++], roverPaths);

        }

        return View(roverModel);
    }
}
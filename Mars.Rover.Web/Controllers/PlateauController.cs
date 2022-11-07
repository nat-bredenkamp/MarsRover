using Mars.Rover.Core;
using Mars.Rover.Core.Entities;
using Mars.Rover.Core.Plateau;
using Mars.Rover.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Mars.Rover.Web.Controllers
{
    public class PlateauController : Controller
    {
        private readonly IPlateauRepository _plateauRepository;

        public PlateauController(IPlateauRepository plateauRepository)
        {
            _plateauRepository = plateauRepository;
        }

        // GET: PI
        public IActionResult Index()
        {
            var allPlateaus = _plateauRepository.GetAll();
            return View(allPlateaus);
        }

        // GET: PI/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plateauInstance = _plateauRepository.Get(id.Value);

            if (plateauInstance == null)
            {
                return NotFound();
            }

            return View(plateauInstance);
        }

        // GET: PI/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PI/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Width,Height,FormFile")] CreatePlateauViewModel model)
        {
            if (ModelState.IsValid)
            {
                string fileContents;
                await using (var stream = model.FormFile.OpenReadStream())
                using (var reader = new StreamReader(stream))
                {
                    fileContents = await reader.ReadToEndAsync();
                }

                var instructions = fileContents.Split(Environment.NewLine).Select(x => 
                    new Instruction()
                    {
                        Deployment = x.Split("|")[0],
                        Movement = x.Split("|")[1]
                    }).ToList();
                var plateau = new PlateauInstance()
                {
                    Width = model.Width,
                    Height = model.Height,
                    Instructions = instructions
                };
                _plateauRepository.Save(plateau);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: PI/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plateauInstance = _plateauRepository.Get(id.Value);

            if (plateauInstance == null)
            {
                return NotFound();
            }

            return View(plateauInstance);
        }

        // POST: PI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _plateauRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
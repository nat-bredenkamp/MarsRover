using System.ComponentModel.DataAnnotations;
using Mars.Rover.Web.ValidationAttributes;

namespace Mars.Rover.Web.ViewModels;

public class CreatePlateauViewModel
{
    [Range(1, 10)]
    [Required(ErrorMessage = "Please enter a width.")]
    public int Width { get; set; }

    [Range(1, 10)]
    [Required(ErrorMessage = "Please enter a height.")]
    public int Height { get; set; }

    [Required(ErrorMessage = "Please select a file.")]
    [AllowedExtensions(new string[] { ".csv" })]
    public IFormFile FormFile { get; set; }
}
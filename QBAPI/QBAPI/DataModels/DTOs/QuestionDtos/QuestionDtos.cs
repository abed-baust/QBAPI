using System.ComponentModel.DataAnnotations;

namespace QBAPI.DTOs.QuestionDtos
{
    public class QuestionDtos
    {
     
        [Required(ErrorMessage = "Department Name is required")]
        public string? Department { get; set; }

        [Required(ErrorMessage = "Semister is required")]
        public string? Semister { get; set; }

        [Required(ErrorMessage = "Level is required")]
        public string? Level { get; set; }
        public IFormFile? file { get; set; }
    }
}

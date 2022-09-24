using System.ComponentModel.DataAnnotations;

namespace QBAPI.DataModels
{
    public class QuestionModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Department Name is required")]
        public string? Department { get; set; }

        [Required(ErrorMessage = "Semister is required")]
        public string? Semister { get; set; }        
        
        [Required(ErrorMessage = "Level is required")]
        public string? Level { get; set; }        
        
        [Required(ErrorMessage = "Question URL is required")]
        public string? QuestionURL { get; set; }
    }
}

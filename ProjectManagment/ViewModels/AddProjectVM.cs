using System.ComponentModel.DataAnnotations;

namespace ProjectManagment.ViewModels
{
    public class AddProjectVM
    {
        [Required]
        public string? Name { get; set; }
        public string? Describtion { get; set; }
    }
}

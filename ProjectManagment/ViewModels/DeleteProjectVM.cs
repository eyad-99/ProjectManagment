using System.ComponentModel.DataAnnotations;

namespace ProjectManagment.ViewModels
{
    public class EditProjectVM
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Describtion { get; set; }
    }
}

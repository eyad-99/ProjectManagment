using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagment.context.entities
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public string? Describtion { get; set; }

        public List<DeveloperTask>? Tasks { get; set; }


        [ForeignKey("userid")]
        public User user { get; set; }
        public string userid { get; set; }
    }
}

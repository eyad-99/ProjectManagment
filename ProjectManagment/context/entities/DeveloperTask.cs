using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagment.context.entities
{
    public class DeveloperTask
    {


        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public string? Describtion { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? DeadLine { get; set; }


        public bool? Status { get; set; }

        [ForeignKey("ProjectId")]
        public Project? Project { get; set; }

        public int ProjectId { get; set; }



        [ForeignKey("userid")]
        public User user { get; set; }
        public string userid { get; set; }
    }
}

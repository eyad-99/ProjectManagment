using ProjectManagment.context.entities;

namespace ProjectManagment.ViewModels
{
    public class AddTaskViewModel
    {
        public string Name { get; set; }
        public string Describtion { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DeadLine { get; set; }
        public bool? Status { get; set; }
        public int ProjectId { get; set; }
        public string UserId { get; set; }
        public List<User>? developers  { get; set; }
    }
}

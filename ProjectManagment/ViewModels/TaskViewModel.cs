namespace ProjectManagment.ViewModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Describtion { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DeadLine { get; set; }
        public bool? Status { get; set; }
        public string ProjectName { get; set; }
        public string UserName { get; set; }
    }
}

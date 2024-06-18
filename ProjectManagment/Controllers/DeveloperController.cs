using Microsoft.AspNetCore.Mvc;
using ProjectManagment.context.entities;
using ProjectManagment.repositories.interfaces;
using ProjectManagment.service;
using ProjectManagment.ViewModels;

namespace ProjectManagment.Controllers
{
    public class DeveloperController : Controller
    {
        private readonly ITaskRepository TaskRepository;
        private readonly IUserService UserService;

        public DeveloperController(ITaskRepository TaskRepository, IUserService UserService)
        {
            this.TaskRepository=TaskRepository;
            this.UserService=UserService;
        }

        public IActionResult Index()
        {
            List<DeveloperTask> tasks=TaskRepository.ListDeveloperTasks(UserService.GetUserId());
            var taskViewModels = tasks.Select(t => new TaskViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Describtion = t.Describtion,
                StartDate = t.StartDate,
                DeadLine = t.DeadLine,
                Status = t.Status,
                ProjectName = t.Project?.Name, // Assumes Project has a Name property
                UserName = t.user?.UserName     // Assumes User has a UserName property
            }).ToList();

           // ViewBag.ProjectId = Id;

            return View(taskViewModels);
        }


        [HttpGet]
        public IActionResult CompleteTask(int Id)
        {
          
                DeveloperTask task = TaskRepository.GetById(Id);
                task.Status = true;
                TaskRepository.Update(task);
                return RedirectToAction("Index", new { Id = task.userid }); 
        }
    }
}

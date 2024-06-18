using Microsoft.AspNetCore.Mvc;
using ProjectManagment.context;
using ProjectManagment.context.entities;
using ProjectManagment.repositories.interfaces;
using ProjectManagment.service;
using ProjectManagment.ViewModels;
using System.Collections.Generic;

namespace ProjectManagment.Controllers
{
    public class LeadController : Controller
    {
        private readonly IProjectRepository ProjectRepository;
        private readonly ITaskRepository TaskRepository;
        private readonly IAccountRepository AccountRepository;

        private readonly IUserService UserService;


        public LeadController(IProjectRepository ProjectRepository, ITaskRepository TaskRepository, IUserService UserService,IAccountRepository AccountRepository)
        {
            this.TaskRepository = TaskRepository;
            this.ProjectRepository = ProjectRepository;
            this.UserService = UserService;
            this.AccountRepository = AccountRepository;

        }
        public IActionResult Index()
        {
            List<Project> Projects = ProjectRepository.List();
            return View(Projects);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(AddProjectVM model)
        {
            if(ModelState.IsValid)
            {
                Project p = new Project()
                {
                    Name = model.Name,
                    Describtion = model.Describtion,
                    userid = UserService.GetUserId()
                };
                ProjectRepository.Add(p);
                return RedirectToAction("Index");
            }
            return View(model);
            
        }



        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var project = ProjectRepository.GetById(Id);
            EditProjectVM projectVM = new EditProjectVM()
            {
                Id = Id,
                Name=project.Name,
                Describtion=project.Describtion,

            };
            return View(projectVM);
        }


        [HttpPost]
        public IActionResult Edit(EditProjectVM model)
        {
            if(ModelState.IsValid)
            {
                var project = ProjectRepository.GetById(model.Id);
                project.Describtion = model.Describtion;
                project.Name = model.Name;

                ProjectRepository.Update(project);
                return RedirectToAction("Index");

            }
            return View(model);
           
        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var project = ProjectRepository.GetById(Id);
            DeleteProjectVM projectVM = new DeleteProjectVM()
            {
                Id = Id,
                Name = project.Name,
                Describtion = project.Describtion,

            };
            return View(projectVM);
        }


        [HttpPost]
        public IActionResult Delete(DeleteProjectVM model)
        {     
            
            ProjectRepository.Delete(model.Id);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult tasks(int Id)
        {
            var Tasks = TaskRepository.List(Id);
            var taskViewModels = Tasks.Select(t => new TaskViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Describtion = t.Describtion,
                StartDate = t.StartDate,
                DeadLine = t.DeadLine,
                Status = t.Status,
                ProjectName = t.Project?.Name , // Assumes Project has a Name property
                UserName = t.user?.UserName     // Assumes User has a UserName property
            }).ToList();

            ViewBag.ProjectId = Id;

            return View(taskViewModels);
        }


        [HttpGet]
        public async Task<IActionResult> AddTask(int Id)

        {
            ViewBag.Id = Id;
            List<User> devs = await AccountRepository.GetDevelopers();

            AddTaskViewModel model = new AddTaskViewModel()
            {
                developers=devs.ToList(),
            };
            return View(model);

        }


        [HttpPost]
        public  IActionResult AddTask(AddTaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                DeveloperTask task = new DeveloperTask()
                {
                    Name = model.Name,
                    Describtion = model.Describtion,
                    StartDate = model.StartDate,
                    DeadLine = model.DeadLine,
                    Status = false,
                    ProjectId = model.ProjectId, // Assumes Project has a Name property
                    userid = model.UserId    // Assumes User has a Use


                };
                TaskRepository.Add(task);
                return RedirectToAction("tasks", new { Id = model.ProjectId });

            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> EditTask(int Id)

        {
            ViewBag.Id = Id;
            List<User> devs = await AccountRepository.GetDevelopers();
            DeveloperTask task = TaskRepository.GetById(Id);

            EditTaskViewModel model = new EditTaskViewModel()
            {
                Id=task.Id,
                Name=task.Name,
                Describtion=task.Describtion,
                StartDate=task.StartDate,
                DeadLine=task.DeadLine,
                Status= task.Status,
                ProjectId=task.ProjectId,
                UserId=task.userid,
                developers = devs.ToList(),
            };
            return View(model);

        }


        [HttpPost]
        public IActionResult EditTask(EditTaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                DeveloperTask task=TaskRepository.GetById(model.Id);


                task.Name = model.Name;
                task.Describtion = model.Describtion;
                task.StartDate = model.StartDate;
              task.DeadLine = model.DeadLine;
              //task.Status = false;
               // task.ProjectId = model.ProjectId; // Assumes Project has a Name property
                task.userid = model.UserId;    // Assumes User has a Use


               
                TaskRepository.Update(task);
                return RedirectToAction("tasks", new { Id = model.ProjectId });

            }
            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> DeleteTask(int Id)
        {
            ViewBag.Id = Id;
            List<User> devs = await AccountRepository.GetDevelopers();
            DeveloperTask task = TaskRepository.GetById(Id);

            EditTaskViewModel model = new EditTaskViewModel()
            {
                Id = task.Id,
                Name = task.Name,
                Describtion = task.Describtion,
                StartDate = task.StartDate,
                DeadLine = task.DeadLine,
                Status = task.Status,
                ProjectId = task.ProjectId,
                UserId = task.userid,
                developers = devs.ToList(),
            };
            return View(model);
        }


        [HttpPost]
        public IActionResult DeleteTask(EditTaskViewModel model)
        {

            TaskRepository.Delete(model.Id);
            return RedirectToAction("tasks", new { Id = model.ProjectId });
        }




    }
}

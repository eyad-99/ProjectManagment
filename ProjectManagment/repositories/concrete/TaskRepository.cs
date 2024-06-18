using Humanizer.Localisation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectManagment.context;
using ProjectManagment.context.entities;
using ProjectManagment.repositories.interfaces;
using ProjectManagment.service;

namespace ProjectManagment.repositories.concrete
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext ctx;
        private readonly IUserService UserService;
        public TaskRepository(ApplicationDbContext ctx, IUserService UserService)
        {
            this.ctx = ctx;
            this.UserService = UserService;


        }
        public bool Add(DeveloperTask model)
        {
            try
            {
                ctx.Tasks.Add(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.GetById(id);
                if (data == null)
                    return false;
                ctx.Tasks.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DeveloperTask GetById(int id)
        {
            return ctx.Tasks.Find(id);
        }

        public List<DeveloperTask> List(int ProjectId)
        {
            var data = ctx.Tasks.Include(t => t.user).Where(X=>X.ProjectId==ProjectId).ToList();
            return data;
        }


        public List<DeveloperTask> ListDeveloperTasks(string UserId)
        {
            var data = ctx.Tasks.Include(y=>y.Project).Include(t => t.user).Where(X => X.userid == UserId).ToList();
            return data;
        }

        public bool Update(DeveloperTask model)
        {
            try
            {
                ctx.Tasks.Update(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

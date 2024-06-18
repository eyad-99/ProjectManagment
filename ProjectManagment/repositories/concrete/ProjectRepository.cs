using Humanizer.Localisation;
using Microsoft.AspNetCore.Identity;
using ProjectManagment.context;
using ProjectManagment.context.entities;
using ProjectManagment.repositories.interfaces;
using ProjectManagment.service;

namespace ProjectManagment.repositories.concrete
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext ctx;
        private readonly IUserService UserService;
        public ProjectRepository(ApplicationDbContext ctx, IUserService UserService)
        {
            this.ctx = ctx;
            this.UserService = UserService;


        }
        public bool Add(Project model)
        {
            try
            {
                ctx.projects.Add(model);
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
                ctx.projects.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Project GetById(int id)
        {
            return ctx.projects.Find(id);
        }

        public List<Project> List()
        {
            var data = ctx.projects.Where(x=>x.user.Id==UserService.GetUserId()).ToList();
            return data;
        }

        public bool Update(Project model)
        {
            try
            {
                ctx.projects.Update(model);
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

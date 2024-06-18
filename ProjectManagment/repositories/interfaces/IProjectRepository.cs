using Humanizer.Localisation;
using ProjectManagment.context.entities;

namespace ProjectManagment.repositories.interfaces
{
    public interface IProjectRepository
    {
        bool Add(Project model);
        bool Update(Project model);
        Project GetById(int id);
        bool Delete(int id);
        List<Project> List();
    }
}

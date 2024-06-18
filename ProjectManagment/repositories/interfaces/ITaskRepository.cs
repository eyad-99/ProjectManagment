using Humanizer.Localisation;
using ProjectManagment.context.entities;

namespace ProjectManagment.repositories.interfaces
{
    public interface ITaskRepository
    {
        bool Add(DeveloperTask model);
        bool Update(DeveloperTask model);
        DeveloperTask GetById(int id);
        bool Delete(int id);
        List<DeveloperTask> List(int ProjectId);
        public List<DeveloperTask> ListDeveloperTasks(string UserId);
    }
}

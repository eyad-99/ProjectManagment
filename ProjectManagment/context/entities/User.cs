using Microsoft.AspNetCore.Identity;

namespace ProjectManagment.context.entities
{
    public class User:IdentityUser
    {
        public List<DeveloperTask>? Tasks { get; set; }

        public List<Project>? Projects { get; set; }
    }
}

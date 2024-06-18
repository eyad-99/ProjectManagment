using Microsoft.AspNetCore.Identity;
using ProjectManagment.context.entities;
using ProjectManagment.ViewModels;

using Task = System.Threading.Tasks.Task;

namespace ProjectManagment.repositories.interfaces
{
    public interface IAccountRepository
    {
        public  Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);

        public  Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);

        Task<User> GetUserByEmailAsync(string email);

        public  Task<List<string>> GetRole(User user);
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);


        public  Task GenerateEmailConfirmationTokenAsync(User user);


        public System.Threading.Tasks.Task SignOutAsync();

        public  Task<IdentityResult> ConfirmEmailAsync(string uid, string token);

        public  Task GenerateForgotPasswordTokenAsync(User user);

        Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model);


        Task<List<User>> GetDevelopers();

    }
}

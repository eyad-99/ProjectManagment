using Microsoft.AspNetCore.Identity;
using ProjectManagment.repositories.interfaces;
using ProjectManagment.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ProjectManagment.service;
using ProjectManagment.context.entities;
using ProjectManagment.configs;
using System.Configuration;
using System.Threading.Tasks;

namespace ProjectManagment.repositories.concrete
{
    public class AccountRepository: IAccountRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _UserService;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _Configuration;


        public AccountRepository(UserManager<User> userManager, SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager, IUserService UserService, IEmailService emailService, IConfiguration Configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _UserService= UserService;
            _emailService = emailService;
            _Configuration = Configuration;


        }


        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new User()
            {
            
                Email = userModel.Email,
                UserName = userModel.Email

            };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            if (result.Succeeded)
            {
                await GenerateEmailConfirmationTokenAsync(user);
            }
            return result;
        }


        public async Task GenerateEmailConfirmationTokenAsync(User user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendEmailConfirmationEmail(user, token);
            }
        }



        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
            return await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, true);
        }


        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }


        public async Task<List<string>> GetRole(User user)
        {
            List <string> roles = (List<string>)await _userManager.GetRolesAsync(user);
            return roles;
        }


        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }


        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model)
        {
            var userId = _UserService.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
            return await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        }


        public async Task SendEmailConfirmationEmail(User user, string token)
        {
            string appDomain = _Configuration.GetSection("Application:AppDomain").Value;
            string confirmationLink = _Configuration.GetSection("Application:EmailConfirmation").Value;

            UserEmailOptions options = new UserEmailOptions
            {
                ToEmails = new List<string>() { user.Email },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.UserName),
                    new KeyValuePair<string, string>("{{Link}}",
                        string.Format(appDomain + confirmationLink, user.Id, token))
                }
            };

            await _emailService.SendEmailForEmailConfirmation(options);
        }


        public async Task<IdentityResult> ConfirmEmailAsync(string uid, string token)
        {
            return await _userManager.ConfirmEmailAsync(await _userManager.FindByIdAsync(uid), token);
        }

        public async Task GenerateForgotPasswordTokenAsync(User user)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendForgotPasswordEmail(user, token);
            }
        }


        private async Task SendForgotPasswordEmail(User user, string token)
        {
            string appDomain = _Configuration.GetSection("Application:AppDomain").Value;
            string confirmationLink = _Configuration.GetSection("Application:ForgotPassword").Value;

            UserEmailOptions options = new UserEmailOptions
            {
                ToEmails = new List<string>() { user.Email },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.UserName),
                    new KeyValuePair<string, string>("{{Link}}",
                        string.Format(appDomain + confirmationLink, user.Id, token))
                }
            };

            await _emailService.SendEmailForForgotPassword(options);
        }


        public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model)
        {
            return await _userManager.ResetPasswordAsync(await _userManager.FindByIdAsync(model.UserId), model.Token, model.NewPassword);
        }

      public async Task<List<User>> GetDevelopers()
        {
            return (List<User>)await  _userManager.GetUsersInRoleAsync("Developer");
        }

    }
}

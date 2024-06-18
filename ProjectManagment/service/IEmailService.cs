using ProjectManagment.configs;

namespace ProjectManagment.service
{
    public interface IEmailService
    {
        public Task SendTestEmail(UserEmailOptions userEmailOptions);

        public Task SendEmailForEmailConfirmation(UserEmailOptions userEmailOptions);
        public Task SendEmailForForgotPassword(UserEmailOptions userEmailOptions);
    
    
    
    
    }
}

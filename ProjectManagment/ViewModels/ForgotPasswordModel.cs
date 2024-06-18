using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjectManagment.ViewModels
{
    public class ForgotPasswordModel
    {
        [Required, EmailAddress, Display(Name = "Registered email address")]
        public string Email { get; set; }
        public bool EmailSent { get; set; }
    }
}

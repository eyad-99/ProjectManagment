﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjectManagment.ViewModels
{
    public class SignUpUserModel
    {
      

        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a strong password")]
        [Compare("ConfirmPassword", ErrorMessage = "Password does not match")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }





        [Required(ErrorMessage = "Please choose user type")]
        [Display(Name = "user type")]
        public string Type { get; set; }





        [Required(ErrorMessage = "Please confirm your password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}

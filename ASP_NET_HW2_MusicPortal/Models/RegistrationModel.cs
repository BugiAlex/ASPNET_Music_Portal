using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_NET_HW2_MusicPortal.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "The field must be set.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The field must be set.")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid email.")]
        public string Login { get; set; }
        

        [Required(ErrorMessage = "The field must be set.")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Password length must be between 6 and 10 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "The field must be set.")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Password Confirm")]
        public string PasswordConfirm { get; set; }
    }
}
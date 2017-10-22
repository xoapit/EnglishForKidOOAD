using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnglishForKidAPI.Models.ViewModels
{
    public class CreateUserBindingModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        public string Avatar { get; set; }

        [Required]
        public string FullName { get; set; }

        public string RoleName { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public bool Gender { get; set; }

        public bool Status { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        public string Address { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
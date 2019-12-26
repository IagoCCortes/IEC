using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Identity.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
        
        public DateTime Created { get; set; }

        public RegisterViewModel()
        {
            Created = DateTime.Now;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingSystem.ViewModels
{
    public class SignUpModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Invalid lenght. Max 50 an minimum 5 chars", MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$", ErrorMessage = "Minimum eight characters, at least one letter, one number and one special character")]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}

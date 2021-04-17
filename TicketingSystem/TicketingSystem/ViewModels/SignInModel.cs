using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingSystem.ViewModels
{
    public class SignInModel
    {
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsPersistent { get; set; }
    }
}

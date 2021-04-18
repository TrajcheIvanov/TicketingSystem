using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingSystem.ViewModels
{
    public class TicketCreateModel
    {
        [Required]
        [StringLength(maximumLength: 500, MinimumLength = 4)]
        public string Title { get; set; }

        [Required]
        [StringLength(maximumLength: 500, MinimumLength = 10)]
        public string Description { get; set; }

        public int UserId { get; set; }
    }
}

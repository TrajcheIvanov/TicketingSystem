using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Models;

namespace TicketingSystem.ViewModels
{
    public class TicketOverviewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public TicketStatusType TicketStatus { get; set; }

        public int UserId { get; set; }

    }
}

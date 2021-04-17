using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public TicketStatusType TicketStatus { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}

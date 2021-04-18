using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingSystem.ViewModels
{
    public class CommentCreateModel
    {
        public int TicketId { get; set; }
        public string Comment { get; set; }
    }
}

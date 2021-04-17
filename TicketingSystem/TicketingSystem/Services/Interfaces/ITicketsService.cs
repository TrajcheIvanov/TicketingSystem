using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Models;

namespace TicketingSystem.Services.Interfaces
{
    public interface ITicketsService
    {
        List<Ticket> GetAllForCurrentUser(int userId);

        List<Ticket> GetAll();
    }
}

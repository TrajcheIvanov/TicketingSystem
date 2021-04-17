using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Models;

namespace TicketingSystem.Repository.Interfaces
{
    public interface ITicketsRepository
    {
        List<Ticket> GetAllForCurrentUser(int userId);

        List<Ticket> GetAll();
    }
}

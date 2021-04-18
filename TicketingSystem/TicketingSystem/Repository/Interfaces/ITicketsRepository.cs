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
        void Add(Ticket domainModel);
        Ticket GetById(int id);
        void Delete(Ticket ticket);
        void Update(Ticket ticket);
        List<Ticket> GetTicketsWithAdminFilter(string adminFilterOption);
    }
}

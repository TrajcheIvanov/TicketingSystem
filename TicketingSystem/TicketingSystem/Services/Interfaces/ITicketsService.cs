using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Models;
using TicketingSystem.Services.DtoModels;

namespace TicketingSystem.Services.Interfaces
{
    public interface ITicketsService
    {
        List<Ticket> GetAllForCurrentUser(int userId);

        List<Ticket> GetAll();
        StatusModel CreateTicket(Ticket domainModel);
        StatusModel Delete(int id);
        Ticket GetById(int id);
        StatusModel ChangeStatus(string ticketStatus, int ticketId);

        void Update(Ticket ticket);
        List<Ticket> GetTicketsWithAdminFilter(string adminFilterOption);
    }
}

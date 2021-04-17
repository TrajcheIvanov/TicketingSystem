using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Models;
using TicketingSystem.Repository.Interfaces;
using TicketingSystem.Services.Interfaces;

namespace TicketingSystem.Services
{
    public class TicketsService : ITicketsService
    {
        private ITicketsRepository _ticketsRepository;
        public TicketsService(ITicketsRepository ticketsRepository)
        {
            _ticketsRepository = ticketsRepository;
        }

        public List<Ticket> GetAll()
        {
            return _ticketsRepository.GetAll();
        }



        public List<Ticket> GetAllForCurrentUser(int userId)
        {
            return _ticketsRepository.GetAllForCurrentUser(userId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Models;
using TicketingSystem.Repository.Interfaces;
using TicketingSystem.Services.DtoModels;
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

        public StatusModel CreateTicket(Ticket domainModel)
        {
            var response = new StatusModel();

            domainModel.DateCreated = DateTime.Now;
            domainModel.TicketStatus = TicketStatusType.Pending;
            _ticketsRepository.Add(domainModel);

            return response;
        }

        public StatusModel Delete(int id)
        {
            var response = new StatusModel();
            var ticket = _ticketsRepository.GetById(id);

            if (ticket == null)
            {
                response.IsSuccessful = false;
                response.Message = $"The Ticket with id {id} was not found";
            }
            else
            {
                _ticketsRepository.Delete(ticket);
            }

            return response;
        }

        public List<Ticket> GetAll()
        {
            return _ticketsRepository.GetAll();
        }

        public List<Ticket> GetAllForCurrentUser(int userId)
        {
            return _ticketsRepository.GetAllForCurrentUser(userId);
        }

        public Ticket GetById(int id)
        {
            return _ticketsRepository.GetById(id);
        }
    }
}

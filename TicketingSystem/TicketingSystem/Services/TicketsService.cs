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

        public StatusModel ChangeStatus(string ticketStatus, int ticketId)
        {
            var response = new StatusModel();
            var ticketForUpdate = _ticketsRepository.GetById(ticketId);

            if (ticketForUpdate == null)
            {
                response.IsSuccessful = false;
                response.Message = $"The Ticket with id {ticketId} was not found";
            }
            else
            {
                if (ticketStatus == "processing")
                {
                    ticketForUpdate.TicketStatus = TicketStatusType.Processing;
                    _ticketsRepository.Update(ticketForUpdate);
                }
                else
                {
                    ticketForUpdate.TicketStatus = TicketStatusType.Done;
                    _ticketsRepository.Update(ticketForUpdate);
                }
            }


            return response;
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

        public List<Ticket> GetTicketsWithAdminFilter(string adminFilterOption)
        {
            return _ticketsRepository.GetTicketsWithAdminFilter(adminFilterOption);
        }

        public void Update(Ticket ticket)
        {
            _ticketsRepository.Update(ticket);
        }
    }
}

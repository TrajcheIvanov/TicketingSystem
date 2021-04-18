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
    public class CommentsService : ICommentsService
    {
        private ICommentsRepository _commentsRepository;
        private ITicketsService _ticketsService;
        public CommentsService(ICommentsRepository commentsRepository, ITicketsService ticketsService)
        {
            _commentsRepository = commentsRepository;
            _ticketsService = ticketsService;
        }

        public StatusModel Add(string comment, int ticketId, int userId)
        {
            var response = new StatusModel();
            var ticket = _ticketsService.GetById(ticketId);

            if (ticket != null)
            {
                var newComment = new Comment()
                {
                    Message = comment,
                    DateCreated = DateTime.Now,
                    TicketId = ticketId,
                    UserId = userId
                };

                _commentsRepository.Add(newComment);

            }
            else
            {
                response.IsSuccessful = false;
                response.Message = $"The Ticket with Id {ticketId} was not found";
            }


            return response;
        }
    }
}

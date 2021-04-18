using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Services.DtoModels;

namespace TicketingSystem.Services.Interfaces
{
    public interface ICommentsService
    {
        StatusModel Add(string comment, int ticketId, int userId);
    }
}

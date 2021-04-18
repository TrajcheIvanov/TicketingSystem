using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Models;

namespace TicketingSystem.Repository.Interfaces
{
    public interface ICommentsRepository
    {
        void Add(Comment newComment);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Models;

namespace TicketingSystem.Repository.Interfaces
{
    public interface IUsersRepository
    {
        bool CheckIfExists(string username, string email);
        void Add(User newUser);
        User GetByUsername(string username);
    }
}

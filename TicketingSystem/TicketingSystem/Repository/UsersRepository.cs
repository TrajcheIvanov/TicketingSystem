using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Models;
using TicketingSystem.Repository.Interfaces;

namespace TicketingSystem.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private TicketingSystemDbContext _dbContext;

        public UsersRepository(TicketingSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(User newUser)
        {
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }

        public bool CheckIfExists(string username, string email)
        {
            return _dbContext.Users.Any(x => x.Username == username || x.Email == email);
        }

        public User GetByUsername(string username)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Username == username);
        }
    }
}

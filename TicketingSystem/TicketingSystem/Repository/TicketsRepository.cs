using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Models;
using TicketingSystem.Repository.Interfaces;

namespace TicketingSystem.Repository
{
    public class TicketsRepository : ITicketsRepository
    {
        private TicketingSystemDbContext _dbContext;
        public TicketsRepository(TicketingSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Ticket domainModel)
        {
            _dbContext.Tickets.Add(domainModel);
            _dbContext.SaveChanges();
        }

        public void Delete(Ticket ticket)
        {
            _dbContext.Tickets.Remove(ticket);
            _dbContext.SaveChanges();
        }

        public List<Ticket> GetAll()
        {
            return _dbContext.Tickets.ToList();
        }


        public List<Ticket> GetAllForCurrentUser(int userId)
        {
            return _dbContext.Tickets.Where(x => x.UserId == userId).ToList();
        }

        public Ticket GetById(int id)
        {
            return _dbContext.Tickets.Find(id);
        }
    }
}

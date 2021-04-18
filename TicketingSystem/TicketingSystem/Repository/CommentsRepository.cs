using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Models;
using TicketingSystem.Repository.Interfaces;

namespace TicketingSystem.Repository
{
    public class CommentsRepository : ICommentsRepository
    {
        private TicketingSystemDbContext _dbContext;
        public CommentsRepository(TicketingSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Comment newComment)
        {
            _dbContext.Comments.Add(newComment);
            _dbContext.SaveChanges();
        }
    }
}

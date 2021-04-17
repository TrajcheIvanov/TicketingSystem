using Microsoft.EntityFrameworkCore;
using TicketingSystem.Models;

namespace TicketingSystem.Repository
{
    public class TicketingSystemDbContext : DbContext
    {
        public TicketingSystemDbContext(DbContextOptions<TicketingSystemDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

    }
}

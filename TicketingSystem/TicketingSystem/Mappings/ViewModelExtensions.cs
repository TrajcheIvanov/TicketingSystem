using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Models;
using TicketingSystem.ViewModels;

namespace TicketingSystem.Mappings
{
    public static class ViewModelExtensions
    {
        public static User ToModel(this SignUpModel user)
        {
            return new User()
            {
                Password = user.Password,
                Email = user.Email,
                Username = user.Username

            };
        }
    }
}

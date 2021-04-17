using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Models;
using TicketingSystem.Services.DtoModels;

namespace TicketingSystem.Services.Interfaces
{
    public interface IAuthService
    {
        StatusModel SignUp(User user);
        StatusModel SignIn(string username, string password, bool isPersistent, HttpContext httpContext);
        void SignOut(HttpContext httpContext);
    }
}

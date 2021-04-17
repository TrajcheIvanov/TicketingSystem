using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TicketingSystem.Models;
using TicketingSystem.Repository.Interfaces;
using TicketingSystem.Services.DtoModels;
using TicketingSystem.Services.Interfaces;

namespace TicketingSystem.Services
{
    public class AuthService : IAuthService
    {
        private IUsersRepository _usersRepository;
        public AuthService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public StatusModel SignIn(string username, string password, bool isPersistent, HttpContext httpContext)
        {
            var response = new StatusModel();
            var user = _usersRepository.GetByUsername(username);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                var claims = new List<Claim>()
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Username", user.Username),
                    new Claim("Email", user.Email),
                    new Claim("IsAdmin", user.IsAdmin.ToString())
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var authProps = new AuthenticationProperties() { IsPersistent = isPersistent };

                Task.Run(() => httpContext.SignInAsync(principal, authProps)).GetAwaiter().GetResult();

            }
            else
            {
                response.IsSuccessful = false;
                response.Message = "Username or password is incorrect";
            }

            return response;
        }

        public void SignOut(HttpContext httpContext)
        {
            Task.Run(() => httpContext.SignOutAsync()).GetAwaiter().GetResult();
        }

        public StatusModel SignUp(User user)
        {
            var response = new StatusModel();

            var exist = _usersRepository.CheckIfExists(user.Username, user.Email);

            if (exist)
            {
                response.IsSuccessful = false;
                response.Message = "User with username or email already exists";
                return response;
            }
            else
            {
                var newUser = new User()
                {
                    Username = user.Username,
                    Email = user.Email,
                    DateCreated = DateTime.Now,
                    Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                };

                _usersRepository.Add(newUser);

                return response;
            }

            
        }
    }
}

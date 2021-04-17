using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Mappings;
using TicketingSystem.Services.Interfaces;
using TicketingSystem.ViewModels;

namespace TicketingSystem.Controllers
{
    public class TicketController : Controller
    {
        private ITicketsService _ticketsService;
        public TicketController(ITicketsService ticketsService)
        {
            _ticketsService = ticketsService;
        }

        
        public IActionResult Overview()
        {

            


            if (bool.Parse(User.FindFirst("IsAdmin").Value))
            {
                var tickets = _ticketsService.GetAll();
                var viewTickets = tickets.Select(x => x.ToOverviewModel()).ToList();
                return View(viewTickets);
            }
            else
            {
                var userId = int.Parse(User.FindFirst("Id").Value);
                var tickets = _ticketsService.GetAllForCurrentUser(userId);
                var viewTickets = tickets.Select(x => x.ToOverviewModel()).ToList();
                return View(viewTickets);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TicketCreateModel ticketCreateModel)
        {
            return View();
        }
    }
}

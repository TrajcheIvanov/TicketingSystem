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

        [Authorize]
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
            if (ModelState.IsValid)
            {
                var domainModel = ticketCreateModel.ToModel();
                domainModel.UserId = int.Parse(User.FindFirst("Id").Value);
                var response = _ticketsService.CreateTicket(domainModel);

                return RedirectToAction("Overview", "Ticket");
            }
            else
            {
                return View(ticketCreateModel);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var ticket = _ticketsService.GetById(id);
            var ticketDetailsModel = ticket.ToDetailsModel();

            return View(ticketDetailsModel);
        }

        [HttpPost]
        public IActionResult ChangeStatus(string ticketStatus, int ticketId)
        {
            if (ticketStatus == "processing")
            {

                return RedirectToAction("Details", "Ticket", new { id = ticketId } );
            }
            else
            {
                return RedirectToAction("Details", "Ticket" , new { id = ticketId });
            }

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var response = _ticketsService.Delete(id);

            return RedirectToAction("Overview", "Ticket");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingSystem.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult ActionNonSuccessful(string message)
        {
            ViewBag.Message = message;
            return View();
        }
    }
}

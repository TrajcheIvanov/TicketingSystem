using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Services.Interfaces;
using TicketingSystem.ViewModels;

namespace TicketingSystem.Controllers
{
    public class CommentsController : Controller
    {
        private ICommentsService _commentsService;
        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpPost]
        public IActionResult Add(CommentCreateModel commentCreateModel)
        {

            var userId = int.Parse(User.FindFirst("Id").Value);

            var response = _commentsService.Add(commentCreateModel.Comment, commentCreateModel.TicketId , userId);

            if (response.IsSuccessful)
            {
                return RedirectToAction("Details", "Ticket", new { id = commentCreateModel.TicketId });
            }
            else
            {
                return RedirectToAction("ActionNonSuccessful", "Info", new { Message = response.Message });
            }

            
        }
    }
}

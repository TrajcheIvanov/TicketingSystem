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
    public class AuthController : Controller
    {

        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(SignInModel signInModel)
        {

            if (ModelState.IsValid)
            {
                var response = _authService.SignIn(signInModel.Username, signInModel.Password, signInModel.IsPersistent, HttpContext);

                if (response.IsSuccessful)
                {
                    return RedirectToAction("Overview", "Ticket");
                }
                else
                {
                    ModelState.AddModelError("", response.Message);
                    return View(signInModel);
                }
            }
            else
            {
                return View(signInModel);
            }
            
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                var user = signUpModel.ToModel();
                var response = _authService.SignUp(user);

                if (response.IsSuccessful)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    ModelState.AddModelError("", response.Message);
                    return View(signUpModel);
                }
            }
            return View(signUpModel);
        }

        public IActionResult SignOut()
        {
            //sign out
            _authService.SignOut(HttpContext);
            return RedirectToAction("SignIn");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}

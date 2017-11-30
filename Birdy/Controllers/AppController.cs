using Birdy.Services;
using Birdy.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birdy.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;

        public AppController(IMailService mailService)
        {
            this._mailService = mailService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Kontakta Birdy";

            return View();
        }
        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // send the email
                _mailService.SendMail("raketjan@gmail.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();

            } 
            else
            {
                // show the errors
            }
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "Om Birdy";

            return View();
        }
    }
}

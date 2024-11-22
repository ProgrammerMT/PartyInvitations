using Microsoft.AspNetCore.Mvc;
using PartyInvitations.Models;
using System.Diagnostics;
using PartyInvitations.Data;

namespace PartyInvitations.Controllers
{
    public class HomeController : Controller
    {
        private readonly ResponsesDbContext _context;

        public HomeController(ResponsesDbContext context)
        {
            _context = context;
        }

        // Начална страница
        public IActionResult Index()
        {
            return View();
        }

        // GET: Формуляр за RSVP
        public IActionResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RsvpForm(GuestResponse response)
        {
            if (ModelState.IsValid)
            {
                _context.Responses.Add(response);
                _context.SaveChanges();
                ViewBag.SuccessMessage = "Вашият отговор беше успешно запазен!";
                ModelState.Clear(); // Clear the form fields after submission
            }
            return View();
        }


        // Метод за показване на списъка с присъстващи
        public IActionResult ListResponses()
        {
            // Извлича всички записи от базата данни и ги предава към изгледа
            var responses = _context.Responses.ToList();
            return View(responses);
        }
    }
}

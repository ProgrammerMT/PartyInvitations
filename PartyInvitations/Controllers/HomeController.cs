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

        // ������� ��������
        public IActionResult Index()
        {
            return View();
        }

        // GET: �������� �� RSVP
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
                ViewBag.SuccessMessage = "������ ������� ���� ������� �������!";
                ModelState.Clear(); // Clear the form fields after submission
            }
            return View();
        }


        // ����� �� ��������� �� ������� � �����������
        public IActionResult ListResponses()
        {
            // ������� ������ ������ �� ������ ����� � �� ������� ��� �������
            var responses = _context.Responses.ToList();
            return View(responses);
        }
    }
}

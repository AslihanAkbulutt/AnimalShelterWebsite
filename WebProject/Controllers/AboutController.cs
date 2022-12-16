using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProject.Data;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class AboutController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AboutController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Message m)
        {
            _context.Add(m);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}

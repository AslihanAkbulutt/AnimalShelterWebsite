using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using WebProject.Data;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class AboutController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IStringLocalizer<AboutController> _localizer;
        public AboutController(ApplicationDbContext context, IStringLocalizer<AboutController> localizer)
        {
            _context = context;
            _localizer = localizer;

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

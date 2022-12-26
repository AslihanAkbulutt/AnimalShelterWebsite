using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Drawing;
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
        [ValidateAntiForgeryToken]
        public IActionResult Index(Message m)
        {
            if (ModelState.IsValid)
            {
                 _context.Add(m);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();

        }
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1)});
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}

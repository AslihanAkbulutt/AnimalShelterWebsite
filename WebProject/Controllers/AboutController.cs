using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

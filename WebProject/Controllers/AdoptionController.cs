using WebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebProject.Data;
using Microsoft.EntityFrameworkCore;

namespace WebProject.Controllers
{
    public class AdoptionController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        
        public AdoptionController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Animal> list = _context.Animals.ToList();
            return View(list);
        }
        
    }
}

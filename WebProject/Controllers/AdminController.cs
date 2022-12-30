using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using WebProject.Data;
using WebProject.Models;

namespace WebProject.Controllers
{
    [Authorize(Roles ="Admin")] 
    
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult EditUsers()
        {
            var list = _context.Users.ToList();
            if(list.Count==0)
            {
                return NotFound();
            }
            List<Kullanici> liste = new List<Kullanici>();
            foreach(var user in list)
            {
                Kullanici k = new Kullanici();
                string id = user.Id;
                k.Id = id;
                k.Name = user.Name;
                k.LastName = user.Lastname;
                k.Mail = user.Email;
                liste.Add(k);
            }
            return View(liste);
        }
        
    }
}

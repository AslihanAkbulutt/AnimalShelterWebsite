using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProject.Data;
using WebProject.Models;

namespace WebProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MessageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MessageController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult EditMessages()
        {
            List<Message> list = _context.Messages.ToList();
            return View(list);
        }

        [HttpPost]
        public IActionResult Create(Message m)
        {
            _context.Add(m);
            _context.SaveChanges();
            return RedirectToAction(nameof(EditMessages));

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _context.Messages.FindAsync(id);
            _context.Remove(delete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(EditMessages));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var edit = _context.Messages.Find(id);
            return View(edit);
        }
        [HttpPost]
        public IActionResult Edit(Message m)
        {
            _context.Update(m);
            _context.SaveChanges();
            return RedirectToAction(nameof(EditMessages));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var details = _context.Messages.Find(id);
            return View(details);
        }
       
    }
}

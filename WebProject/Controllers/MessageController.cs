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
            if (list.Count == 0)
            {
                return NotFound();
            }
            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Message m)
        {
            if (ModelState.IsValid)
            {
                _context.Add(m);
                _context.SaveChanges();
                return RedirectToAction(nameof(EditMessages));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var delete = await _context.Messages.FindAsync(id);
            if (delete == null)
            {
                return NotFound();
            }
            _context.Remove(delete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(EditMessages));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var edit = _context.Messages.Find(id);
            if (edit == null)
            {
                return NotFound();
            }
            return View(edit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Message m)
        {
            if (ModelState.IsValid)
            {
                _context.Update(m);
                _context.SaveChanges();
                return RedirectToAction(nameof(EditMessages));
            }
            return View();   
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var details = _context.Messages.Find(id);
            if (details == null)
            {
                return NotFound();
            }
            
            return View(details);
        }
        

    }
}

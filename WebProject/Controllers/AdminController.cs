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
            return View();
        }
        
        public IActionResult EditAnimals()
        {
            List<Animal> list = _context.Animals.ToList();
            if (list.Count == 0)
            {
                return NotFound();
            }
            return View(list);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Animal a)
        {
            /*Animal animal = new Animal();
            if (a.Image != null)
            {
                var extension = Path.GetExtension(a.Image.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                a.Image.CopyTo(stream);
                animal.Image = newimagename;
            }
            animal.Breed = a.Breed;
            animal.Age = a.Age;
            animal.Info = a.Info;
            animal.CorD = a.CorD;*/
            if (ModelState.IsValid)
            {
                _context.Add(a);
                _context.SaveChanges();
                return RedirectToAction(nameof(EditAnimals));
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
            var delete = await _context.Animals.FindAsync(id);
            if (delete == null)
            {
                return NotFound();
            }
            _context.Remove(delete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(EditAnimals));
        }
        [HttpGet]

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var edit = _context.Animals.Find(id);
            if(edit == null)
            {
                return NotFound();
            }
            return View(edit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Animal a)
        {
           if(ModelState.IsValid)
           {
                _context.Update(a);
                _context.SaveChanges();
                return RedirectToAction(nameof(EditAnimals));
           }
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            if(id == null)
            {
                return NotFound();   
            }
            var details = _context.Animals.Find(id);
            if(details == null)
            {
                return NotFound();
            }
            return View(details);
        }
    }
}

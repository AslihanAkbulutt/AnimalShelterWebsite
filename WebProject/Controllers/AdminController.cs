using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProject.Data;
using WebProject.Models;

namespace WebProject.Controllers
{ 
    
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
        //-------------------------------------------------------
        

        //_--------------------------------------------------
        public IActionResult EditAnimals()
        {
            List<Animal> list = _context.Animals.ToList();
            return View(list);
        }
        
        [HttpPost]
        public IActionResult Create(AnimalAdd a)
        {
            Animal animal = new Animal();
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
            animal.CorD = a.CorD;

            _context.Add(animal);
            _context.SaveChanges();
            return RedirectToAction(nameof(EditAnimals));

        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _context.Animals.FindAsync(id);
            _context.Remove(delete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(EditAnimals));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var edit = _context.Animals.Find(id);
            return View(edit);
        }
        [HttpPost]
        public IActionResult Edit(Animal a)
        {
            _context.Update(a);
            _context.SaveChanges();
            return RedirectToAction(nameof(EditAnimals));
        }
    }
}

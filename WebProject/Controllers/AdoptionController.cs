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
        public IActionResult Index2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AnimalAdd a)
        {
            Animal animal = new Animal();
            if(a.Image != null)
            {
                var extension = Path.GetExtension(a.Image.FileName);
                var newimagename = Guid.NewGuid()+ extension;
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
            return RedirectToAction(nameof(AdminEdit));

        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        public IActionResult AdminEdit()
        {
            List<Animal> list = _context.Animals.ToList();
            return View(list);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _context.Animals.FindAsync(id);
            _context.Remove(delete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AdminEdit));
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
            return RedirectToAction(nameof(AdminEdit));
        }
    }
}

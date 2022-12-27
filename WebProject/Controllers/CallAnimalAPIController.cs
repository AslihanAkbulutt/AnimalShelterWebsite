using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using System.Data;
using System.Text;
using WebProject.Models;

namespace WebProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CallAnimalAPIController : Controller
    {
       
        public async Task<IActionResult> Index()
        {
            List<Animal> animal = new List<Animal>();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:7224/api/AnimalAPI");
            string resString = await response.Content.ReadAsStringAsync();
            animal = JsonConvert.DeserializeObject<List<Animal>>(resString);
            return View(animal);
        }
        public async Task<IActionResult> Details(int id)
        {
            Animal animal = new Animal();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:7224/api/AnimalAPI/" + id);
            string resString = await response.Content.ReadAsStringAsync();
            animal = JsonConvert.DeserializeObject<Animal>(resString);
            return View(animal);
        }
        public async Task<IActionResult> Delete(int id)
        {
            Animal animal = new Animal();
            var hhtc = new HttpClient();
            var response = await hhtc.DeleteAsync("https://localhost:7224/api/AnimalAPI/" + id);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Animal animal = new Animal();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:7224/api/AnimalAPI/" + id);
            string resString = await response.Content.ReadAsStringAsync();
            animal = JsonConvert.DeserializeObject<Animal>(resString);
            return View(animal);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Animal m, int id)
        {

            var hhtc = new HttpClient();
            var json = new JavaScriptSerializer().Serialize(m);
            // var sp = JsonSerializer.Serialize(json);

            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var result = hhtc.PutAsync("https://localhost:7224/api/AnimalAPI/" + id, stringContent).Result;
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Animal m)
        {

            var hhtc = new HttpClient();
            var json = new JavaScriptSerializer().Serialize(m);
            // var sp = JsonSerializer.Serialize(json);

            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var result = hhtc.PostAsync("https://localhost:7224/api/AnimalAPI/", stringContent).Result;

            return RedirectToAction(nameof(Index));
        }
    }
}

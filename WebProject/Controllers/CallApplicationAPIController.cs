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
    public class CallApplicationAPIController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Application> applications = new List<Application>();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:7224/api/ApplicationAPI");
            string resString = await response.Content.ReadAsStringAsync();
            applications = JsonConvert.DeserializeObject<List<Application>>(resString);
            return View(applications);
        }
        public async Task<IActionResult> Details(int id)
        {
            Application application = new Application();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:7224/api/ApplicationAPI/" + id);
            string resString = await response.Content.ReadAsStringAsync();
            application = JsonConvert.DeserializeObject<Application>(resString);
            return View(application);
        }
        public async Task<IActionResult> Delete(int id)
        {
            Application application= new Application();
            var hhtc = new HttpClient();
            var response = await hhtc.DeleteAsync("https://localhost:7224/api/ApplicationAPI/" + id);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Application application = new Application();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:7224/api/ApplicationAPI/" + id);
            string resString = await response.Content.ReadAsStringAsync();
            application = JsonConvert.DeserializeObject<Application>(resString);
            return View(application);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Application m, int id)
        {

            var hhtc = new HttpClient();
            var json = new JavaScriptSerializer().Serialize(m);
            // var sp = JsonSerializer.Serialize(json);

            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var result = hhtc.PutAsync("https://localhost:7224/api/ApplicationAPI/" + id, stringContent).Result;
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Application m)
        {

            var hhtc = new HttpClient();
            var json = new JavaScriptSerializer().Serialize(m);
            // var sp = JsonSerializer.Serialize(json);

            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var result = hhtc.PostAsync("https://localhost:7224/api/ApplicationAPI/", stringContent).Result;

            return RedirectToAction(nameof(Index));
        }
    }
}

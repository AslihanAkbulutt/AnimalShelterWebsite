using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;
using WebProject.Models;

namespace WebProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CallMessagesAPIController : Controller
    {
       
        public async Task<IActionResult> Index()
        {
            List<Message> messages = new List<Message>();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:7224/api/MessagesAPI");
            string resString = await response.Content.ReadAsStringAsync();
            messages = JsonConvert.DeserializeObject<List<Message>>(resString);
            return View(messages);
        }
        public async Task<IActionResult> Details(int id)
        {
            Message messages = new Message();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:7224/api/MessagesAPI/"+id);
            string resString = await response.Content.ReadAsStringAsync();
            messages = JsonConvert.DeserializeObject<Message>(resString);
            return View(messages);
        }
        public async Task<IActionResult> Delete(int id)
        {
            Message messages = new Message();
            var hhtc = new HttpClient();
            var response = await hhtc.DeleteAsync("https://localhost:7224/api/MessagesAPI/" + id);
            
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Message messages = new Message();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:7224/api/MessagesAPI/" + id);
            string resString = await response.Content.ReadAsStringAsync();
            messages = JsonConvert.DeserializeObject<Message>(resString);
            return View(messages);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Message m,int id)
        {
            
            var hhtc = new HttpClient();
            var json = new JavaScriptSerializer().Serialize(m);
           // var sp = JsonSerializer.Serialize(json);

            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var result = hhtc.PutAsync("https://localhost:7224/api/MessagesAPI/"+id, stringContent).Result;
             return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Message m)
        {
           
            var hhtc = new HttpClient();
            var json = new JavaScriptSerializer().Serialize(m);
            // var sp = JsonSerializer.Serialize(json);

            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var result = hhtc.PostAsync("https://localhost:7224/api/MessagesAPI/", stringContent).Result;

            return RedirectToAction(nameof(Index));
        }



    }
}

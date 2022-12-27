using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nancy.Json;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using System.Data;
using WebProject.Data;
using WebProject.Models;
using Message = WebProject.Models.Message;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebProject.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MessagesAPIController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<MessagesAPIController>
        [HttpGet]
        public async Task<ActionResult<List<Message>>> Get()
        {
            /*List<Message> list = _context.Messages.ToList();
            var json = new JavaScriptSerializer().Serialize(list);
            List<Message> models = JsonConvert.DeserializeObject<List<Message>>(json);
            return models;*/
            var m = await _context.Messages.ToListAsync();
            if (m is null)
            {
                return NoContent();
            }
            return m;
        }

        // GET api/<MessagesAPIController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> Get(int id)
        {
            /*var message = _context.Messages.FindAsync(id);
            var json = new JavaScriptSerializer().Serialize(message);
            Message model = JsonConvert.DeserializeObject<Message>(json);
            return model;*/
            var m = await _context.Messages.FirstOrDefaultAsync(x => x.Id == id);
            if (m is null)
            {
                return NoContent();
            }
            return m;
        }

        // POST api/<MessagesAPIController>
        [HttpPost]
        public IActionResult Post([FromBody] Message m)
        {
            _context.Messages.Add(m);
            _context.SaveChanges();
            return Ok();
        }

        // PUT api/<MessagesAPIController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Message m)
        {
            var m1 = _context.Messages.FirstOrDefault(x => x.Id == id);
            if (m1 is null)
            {
                return NotFound();
            }
            m1.Name = m.Name;
            m1.Mail = m.Mail;
            m1.Messages = m.Messages;
            _context.Update(m1);
            _context.SaveChanges();
            return Ok();
        }

        // DELETE api/<MessagesAPIController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var m1 = _context.Messages.FirstOrDefault(x => x.Id == id);
            if (m1 is null)
            {
                return NotFound();
            }
            
            _context.Messages.Remove(m1);
            _context.SaveChanges();
            return Ok();
        }
    }
}

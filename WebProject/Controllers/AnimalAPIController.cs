using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebProject.Data;
using WebProject.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebProject.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AnimalAPIController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<AnimalAPIController>
        [HttpGet]
        public async Task<ActionResult<List<Animal>>> Get()
        {
            /*List<Message> list = _context.Messages.ToList();
            var json = new JavaScriptSerializer().Serialize(list);
            List<Message> models = JsonConvert.DeserializeObject<List<Message>>(json);
            return models;*/
            var m = await _context.Animals.ToListAsync();
            if (m is null)
            {
                return NoContent();
            }
            return m;
        }

        // GET api/<AnimalAPIController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> Get(int id)
        {
            /*var message = _context.Messages.FindAsync(id);
            var json = new JavaScriptSerializer().Serialize(message);
            Message model = JsonConvert.DeserializeObject<Message>(json);
            return model;*/
            var m = await _context.Animals.FirstOrDefaultAsync(x => x.Id == id);
            if (m is null)
            {
                return NoContent();
            }
            return m;
        }

        // POST api/<AnimalAPIController>
        [HttpPost]
        public IActionResult Post([FromBody] Animal m)
        {
            _context.Animals.Add(m);
            _context.SaveChanges();
            return Ok();
        }

        // PUT api/<AnimalAPIController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Animal m)
        {
            var m1 = _context.Animals.FirstOrDefault(x => x.Id == id);
            if (m1 is null)
            {
                return NotFound();
            }
            m1.Breed = m.Breed;
            m1.Age = m.Age;
            m1.Image = m.Image;
            m1.Info = m.Info;
            m1.CorD = m.CorD;
            _context.Update(m1);
            _context.SaveChanges();
            return Ok();
        }

        // DELETE api/<AnimalAPIController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var m1 = _context.Animals.FirstOrDefault(x => x.Id == id);
            if (m1 is null)
            {
                return NotFound();
            }

            _context.Animals.Remove(m1);
            _context.SaveChanges();
            return Ok();
        }
    }
}

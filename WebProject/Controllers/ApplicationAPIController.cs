using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProject.Data;
using WebProject.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ApplicationAPIController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<ApplicationAPIController>
        [HttpGet]
        public async Task<ActionResult<List<Application>>> Get()
        {
            var m = await _context.Applications.ToListAsync();
            if (m is null)
            {
                return NoContent();
            }
            return m;
        }

        // GET api/<ApplicationAPIController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Application>> Get(int id)
        {
            var m = await _context.Applications.FirstOrDefaultAsync(x => x.Id == id);
            if (m is null)
            {
                return NoContent();
            }
            return m;
        }

        // POST api/<ApplicationAPIController>
        [HttpPost]
        public IActionResult Post([FromBody] Application m)
        {
            _context.Applications.Add(m);
            _context.SaveChanges();
            return Ok();
        }

        // PUT api/<ApplicationAPIController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Application m)
        {
            var m1 = _context.Applications.FirstOrDefault(x => x.Id == id);
            if (m1 is null)
            {
                return NotFound();
            }
            m1.UserName = m.UserName;
            m1.AnimalId = m.AnimalId;
            m1.Name = m.Name;
            m1.LastName = m.LastName;
            m1.Adress = m.Adress;
            m1.PhoneNo = m.PhoneNo;
            m1.Explanation = m.Explanation;
            _context.Update(m1);
            _context.SaveChanges();
            return Ok();
        }

        // DELETE api/<ApplicationAPIController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var m1 = _context.Applications.FirstOrDefault(x => x.Id == id);
            if (m1 is null)
            {
                return NotFound();
            }

            _context.Applications.Remove(m1);
            _context.SaveChanges();
            return Ok();
        }
    }
}

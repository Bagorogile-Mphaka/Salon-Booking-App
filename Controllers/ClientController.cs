using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalonBookingApp1.Data;
using SalonBookingApp1.Models;

namespace SalonBookingApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly SalonBookingAppDbContext _context;
        public ClientController(SalonBookingAppDbContext context)
        {
            _context = context;
        }
        //GET: api/clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        // GET: api/clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
                return NotFound();

            return Ok(client);
        }

        //POST: api/clients
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            //Returns the new client + 201 status
            return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);
        }
        //PUT: api/clients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.Id)
                return BadRequest();
            _context.Entry(client).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Clients.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }
        //DELETE: api/clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
                return NotFound();
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
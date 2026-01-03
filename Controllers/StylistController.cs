using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalonBookingApp1.Data;
using SalonBookingApp1.Models;

namespace SalonBookingApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StylistController : ControllerBase
    {
        private readonly SalonBookingAppDbContext _context;
        public StylistController(SalonBookingAppDbContext context)
        {
            _context = context;
        }
        //GET: api/stylist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stylist>>> GetStylists()
        {
            return await _context.Stylist.ToListAsync();
        }
        // GET: api/stylist
        [HttpGet("{id}")]
        public async Task<ActionResult<Stylist>> GetStylist(int id)
        {
            var stylist = await _context.Stylist.FirstOrDefaultAsync(c => c.StylistId == id);
            if (stylist == null)
                return NotFound();
            return Ok(stylist);
        }
        //POST: api/stylists
        [HttpPost]
        public async Task<ActionResult<Stylist>> PostStylist(Stylist stylist)
        {
            _context.Stylist.Add(stylist);
            await _context.SaveChangesAsync();
            //Returns the new stylist + 201 status
            return CreatedAtAction(nameof(GetStylist), new { id = stylist.StylistId }, stylist);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalonBookingApp1.Data;
using SalonBookingApp1.Models;

namespace SalonBookingApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly SalonBookingAppDbContext _context;
        public BookingsController(SalonBookingAppDbContext context)
        {
            _context = context;
        }
        //GET: api/bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bookings>>> GetBookings()
        {
            return await _context.Bookings
                .Include(b => b.Client)
                .Include(b => b.Stylist)
                .Include(b => b.Treatment)
                .ToListAsync();
        }
        // GET: api/bookings
        [HttpGet("{id}")]
        public async Task<ActionResult<Bookings>> GetBookings(int id)
        {
            var booking = await _context.Bookings
                .Include(b => b.Client)
                .Include(b => b.Stylist)
                .Include(b => b.Treatment)
                .FirstOrDefaultAsync(c => c.BookingId == id);
            if (booking == null)
                return NotFound();
            return Ok(booking);
        }
        //POST: api/bookings
        [HttpPost]
        public async Task<ActionResult<Bookings>> PostBookings(Bookings booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            //Returns the new booking + 201 status
            return CreatedAtAction(nameof(GetBookings), new { id = booking.BookingId }, booking);
        }
        //PUT: api/bookings
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookings(int id, Bookings booking)
        {
            if (id != booking.BookingId)
                return BadRequest();
            _context.Entry(booking).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Bookings.Any(e => e.BookingId == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        // DELETE: api/bookings
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookings(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
                return NotFound();
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

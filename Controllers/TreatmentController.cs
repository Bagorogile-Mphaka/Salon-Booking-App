using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalonBookingApp1.Data;
using SalonBookingApp1.Models;

namespace SalonBookingApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly SalonBookingAppDbContext _context;
        public TreatmentController(SalonBookingAppDbContext context)
        {
            _context = context;
        }
        //GET: api/treatment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Treatment>>> GetTreatment()
        {
            return await _context.Treatment.ToListAsync();
        }
        // GET: api/treatment
        [HttpGet("{id}")]
        public async Task<ActionResult<Treatment>> GetTreatment(int id)
        {
            var treatment = await _context.Treatment.FirstOrDefaultAsync(c => c.TreatmentId == id);
            if (treatment == null)
                return NotFound();
            return Ok(treatment);
        }
        //POST: api/treatment
        [HttpPost]
        public async Task<ActionResult<Treatment>> PostTreatment(Treatment treatment)
        {
            _context.Treatment.Add(treatment);
            await _context.SaveChangesAsync();
            //Returns the new treatment + 201 status
            return CreatedAtAction(nameof(GetTreatment), new { id = treatment.TreatmentId }, treatment);
        }
        //PUT: api/treatment
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTreatment(int id, Treatment treatment)
        {
            if (id != treatment.TreatmentId)
                return BadRequest();
            _context.Entry(treatment).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Treatment.Any(e => e.TreatmentId == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        // DELETE: api/treatment
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTreatment(int id)
        {
            var treatment = await _context.Treatment.FindAsync(id);
            if (treatment == null)
                return NotFound();
            _context.Treatment.Remove(treatment);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

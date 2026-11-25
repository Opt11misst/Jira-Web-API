using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController(AppDbContext db) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(Booking booking)
        {
            // Перевірка на перетин часу
            var hasConflict = await db.Bookings.AnyAsync(b =>
                b.ClassroomId == booking.ClassroomId &&
                b.StartTime < booking.EndTime &&
                booking.StartTime < b.EndTime);

            if (hasConflict)
                return Conflict("Аудиторія вже заброньована на цей час");

            db.Bookings.Add(booking);
            await db.SaveChangesAsync();
            return CreatedAtAction(nameof(Post), new { id = booking.ClassroomId }, booking);
        }

        [HttpGet("{classroomId}")]
        public async Task<IActionResult> Get(string classroomId)
        {
            var bookings = await db.Bookings
                .Where(b => b.ClassroomId == classroomId)
                .ToListAsync();
            return Ok(bookings);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var booking = await db.Bookings.FindAsync(id);
            if (booking == null) return NotFound();

            db.Bookings.Remove(booking);
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}
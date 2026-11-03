using Microsoft.AspNetCore.Mvc;
using Api.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private static readonly List<Booking> _bookings = new();

        [HttpPost]
        public async Task<IActionResult> Post(Booking booking)
        {
            // Перевірка на перетин часу
            var hasConflict = _bookings.Any(b =>
                b.ClassroomId == booking.ClassroomId &&
                b.StartTime < booking.EndTime &&
                booking.StartTime < b.EndTime);

            if (hasConflict)
            {
                return Conflict("Аудиторія вже заброньована на цей час");
            }

            _bookings.Add(booking);
            return CreatedAtAction(nameof(Post), new { id = booking.ClassroomId }, booking);
        }
    }
}

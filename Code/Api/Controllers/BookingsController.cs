using Microsoft.AspNetCore.Mvc;
using Api.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(Booking booking)
        {
            return CreatedAtAction(nameof(Post), new { id = booking.ClassroomId }, booking);
        }
    }
}

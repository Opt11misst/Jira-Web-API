using Microsoft.AspNetCore.Mvc;
using Api.Controllers;
using Api.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassroomsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(Classroom classroom)
        {
            return CreatedAtAction(nameof(Post), new { id = classroom.Number }, classroom);
        }
    }
}

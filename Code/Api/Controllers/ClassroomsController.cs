
using Microsoft.AspNetCore.Mvc;
using Api.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassroomsController : ControllerBase
    {
        private static readonly List<Classroom> _classrooms = new();

        [HttpPost]
        public async Task<IActionResult> Post(Classroom classroom)
        {
            _classrooms.Add(classroom);
            return CreatedAtAction(nameof(Post), new { id = classroom.Number }, classroom);
        }

        [HttpGet]
        public IActionResult Get(int minCapacity)
        {
            var filteredClassrooms = _classrooms.Where(c => c.Capacity >= minCapacity).ToList();
            return Ok(filteredClassrooms);
        }
    }
}

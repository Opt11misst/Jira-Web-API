// Copilot, відрефактори цей метод: додай приватний статичний список _classrooms для зберігання даних. Зроби метод Post асинхронним (async Task<IActionResult>), додай аудиторію до списку і поверни CreatedAtAction.

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
    }
}

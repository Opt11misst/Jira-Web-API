
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
        public async Task<IActionResult> Get(int? minCapacity = null)
        {
            var filteredClassrooms = minCapacity.HasValue
                ? _classrooms.Where(c => c.Capacity >= minCapacity.Value).ToList()
                : _classrooms.ToList();
            return Ok(filteredClassrooms);
        }
    }
    [HttpPost]
        public async Task<IActionResult> Post(Classroom classroom)
        {
            // Проверка на дубликат номера аудитории
            if (_classrooms.Any(c => c.Number == classroom.Number))
            {
                return Conflict("Аудиторія з таким номером уже існує.");
            }

            _classrooms.Add(classroom);
            return CreatedAtAction(nameof(Post), classroom);
        }

    }

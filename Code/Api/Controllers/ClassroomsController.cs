using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassroomsController(AppDbContext db) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(Classroom classroom)
        {
            if (await db.Classrooms.AnyAsync(c => c.Number == classroom.Number))
                return Conflict("Аудитория с таким номером уже существует.");

            db.Classrooms.Add(classroom);
            await db.SaveChangesAsync();
            return CreatedAtAction(nameof(Post), new { id = classroom.Number }, classroom);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? minCapacity = null)
        {
            IQueryable<Classroom> query = db.Classrooms;
            if (minCapacity.HasValue)
                query = query.Where(c => c.Capacity >= minCapacity.Value);

            return Ok(await query.ToListAsync());
        }
    }
}
using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(AppDbContext db) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await db.Users.ToListAsync());

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await db.Users.FindAsync(id);
            if (user == null) return NotFound();

            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}
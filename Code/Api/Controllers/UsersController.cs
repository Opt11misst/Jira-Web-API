using Microsoft.AspNetCore.Mvc;
using Api.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static readonly List<User> _users = new()
        {
            new User { Id = 1, Name = "Test User 1" },
            new User { Id = 2, Name = "Test User 2" },
            new User { Id = 3, Name = "Test User 3" }
        };

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_users.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            _users.Add(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Api.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(new List<User>
            {
                new User { Id = 1, Name = "Test User 1" },
                new User { Id = 2, Name = "Test User 2" },
                new User { Id = 3, Name = "Test User 3" }
                        });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}

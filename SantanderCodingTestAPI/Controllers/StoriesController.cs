using Microsoft.AspNetCore.Mvc;
using SantanderCodingTestAPI.Services;

namespace SantanderCodingTestAPI.Controllers
{
    [ApiController]
    [Route("api/stories")]
    public class StoriesController : ControllerBase
    {
        private readonly IHackerNewsService _service;

        public StoriesController(IHackerNewsService service)
        {
            _service = service;
        }

        [HttpGet("best")]
        public async Task<IActionResult> GetBestStories([FromQuery] int n = 10)
        {
            if (n <= 0 || n > 100)
            {
                return BadRequest("Parameter 'n' must be between 1 and 100.");
            }

            var stories = await _service.GetBestStoriesAsync(n);
            return Ok(stories);
        }
    }
}

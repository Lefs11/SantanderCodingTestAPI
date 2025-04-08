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
            if (n <= 0)
            {
                return BadRequest("Parameter 'n' must be more than 0.");
            }

            var stories = await _service.GetBestStoriesAsync(n);
            return Ok(stories);
        }
    }
}

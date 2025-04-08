using SantanderCodingTestAPI.Models;

namespace SantanderCodingTestAPI.Services
{
    public interface IHackerNewsService
    {
        Task<IEnumerable<StoryDto>> GetBestStoriesAsync(int count);
    }
}

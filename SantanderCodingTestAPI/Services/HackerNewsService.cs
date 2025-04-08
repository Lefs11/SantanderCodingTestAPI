using SantanderCodingTestAPI.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http.Json;

namespace SantanderCodingTestAPI.Services
{
    public class HackerNewsService : IHackerNewsService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;
        private const string BestStoriesUrl = "https://hacker-news.firebaseio.com/v0/beststories.json";
        private const string ItemUrl = "https://hacker-news.firebaseio.com/v0/item/{0}.json";

        public HackerNewsService(HttpClient httpClient, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _cache = cache;
        }

        public async Task<IEnumerable<StoryDto>> GetBestStoriesAsync(int count)
        {
            var ids = await _httpClient.GetFromJsonAsync<List<int>>(BestStoriesUrl);
            if (ids == null || !ids.Any())
            {
                return Enumerable.Empty<StoryDto>();
            }

            var tasks = ids.Take(100).Select(async id => await GetStoryAsync(id));
            var stories = await Task.WhenAll(tasks);

            return stories.Where(s => s != null).OrderByDescending(s => s.Score).Take(count);
        }

        private async Task<StoryDto?> GetStoryAsync(int id)
        {
            if (_cache.TryGetValue(id, out StoryDto story))
            {
                return story;
            }

            var url = string.Format(ItemUrl, id);
            var result = await _httpClient.GetFromJsonAsync<StoryDto>(url);

            if (result != null)
            {
                result.Time = DateTimeOffset.FromUnixTimeSeconds(result.UnixTime).UtcDateTime;
                _cache.Set(id, result, TimeSpan.FromMinutes(10));
            }

            return result;
        }
    }
}

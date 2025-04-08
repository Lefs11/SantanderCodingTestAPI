using System.Text.Json.Serialization;

namespace SantanderCodingTestAPI.Models
{
    public class StoryDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("url")]
        public string? Uri { get; set; }

        [JsonPropertyName("by")]
        public string PostedBy { get; set; } = string.Empty;

        [JsonPropertyName("time")]
        public long UnixTime { get; set; }

        [JsonIgnore]
        public DateTime Time { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("descendants")]
        public int CommentCount { get; set; }
    }
}

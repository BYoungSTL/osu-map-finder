using System.Text.Json.Serialization;

namespace OsuMapFinder.Data.DTOs
{
    public class OsuBeatmapSetDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("artist")]
        public string Artist { get; set; }
        [JsonPropertyName("creator")]
        public string Creator { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("covers")]
        public СoversDTO Covers { get; set; }
    }
}

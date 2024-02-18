using System.Text.Json.Serialization;

namespace OsuMapFinder.Data.DTOs
{
    public class OsuBeatmapStatisticsDTO
    {
        [JsonPropertyName("count_100")]
        public int Count100 { get; set; }
        [JsonPropertyName("count_300")]
        public int Count300 { get; set; }
        [JsonPropertyName("count_50")]
        public int Count50 { get; set; }
        [JsonPropertyName("count_miss")]
        public int CountMiss { get; set; }
    }
}

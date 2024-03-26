using System.Text.Json.Serialization;

namespace OsuMapFinder.Data.DTOs
{
    public class OsuBeatmapDTO
    {
        [JsonPropertyName("difficulty_rating")]
        public double DifficultyRating { get; set; }
        [JsonPropertyName("accuracy")]
        public double OdAccuracy { get; set; }
        [JsonPropertyName("ar")]
        public double Ar { get; set; }
        [JsonPropertyName("bpm")]
        public int Bpm { get; set; }
        [JsonPropertyName("drain")]
        public double HpDrain { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("version")]
        public string Version { get; set; }
        [JsonPropertyName("beatmapset")]
        public OsuBeatmapSetDTO Beatmapset { get; set; }
    }
}

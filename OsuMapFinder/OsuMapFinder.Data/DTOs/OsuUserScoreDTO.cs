using System.Text.Json.Serialization;

namespace OsuMapFinder.Data.DTOs
{
    public class OsuUserScoreDTO
    {
        [JsonPropertyName("accuracy")]
        public double Accuracy { get; set; }
        [JsonPropertyName("pp")]
        public double Pp { get; set; }
        [JsonPropertyName("rank")]
        public string Rank { get; set; }
        [JsonPropertyName("statistics")]
        public OsuBeatmapStatisticsDTO Statistics { get; set; }
        [JsonPropertyName("beatmap")]
        public OsuBeatmapDTO Beatmap { get; set; }
        [JsonPropertyName("beatmapset")]
        public OsuBeatmapSetDTO Beatmapset { get; set; }
        [JsonPropertyName("weight")]
        public OsuScoreWeightDTO Weight { get; set; }
    }
}

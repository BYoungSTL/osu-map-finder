using System.Text.Json.Serialization;

namespace OsuMapFinder.Data.DTOs
{
    public class OsuUserStatisticsDTO
    {
        [JsonPropertyName("global_rank")]
        public int GlobalRank { get; set; }
        [JsonPropertyName("pp")]
        public double Pp { get; set; }
        [JsonPropertyName("country_rank")]
        public int CountryRank { get; set; }
    }
}

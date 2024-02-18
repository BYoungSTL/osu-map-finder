using System.Text.Json.Serialization;

namespace OsuMapFinder.Data.DTOs
{
    public class OsuScoreWeightDTO
    {
        [JsonPropertyName("percentage")]
        public double Percentage { get; set; }
        [JsonPropertyName("pp")]
        public double CalculatedPp { get; set; }
    }
}

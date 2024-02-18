using System.Text.Json.Serialization;

namespace OsuMapFinder.Data.DTOs
{
    public class OsuUserExtendedDTO
    {
        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }
        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("is_active")]
        public bool IsActive { get; set; }
        [JsonPropertyName("is_bot")]
        public bool IsBot { get; set; }
        [JsonPropertyName("is_deleted")]
        public bool IsDeleted { get; set; }
        [JsonPropertyName("username")]
        public string Username{ get; set; }
        [JsonPropertyName("statistics")]
        public OsuUserStatisticsDTO Statistics { get; set; }
    }
}

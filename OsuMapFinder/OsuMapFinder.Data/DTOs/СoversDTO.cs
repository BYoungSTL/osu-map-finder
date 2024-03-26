using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OsuMapFinder.Data.DTOs
{
    public class СoversDTO
    {
        [JsonPropertyName("cover")]
        public string Cover { get; set; }
        [JsonPropertyName("cover@2x")]
        public string Cover2x { get; set; }
        [JsonPropertyName("card")]
        public string Card { get; set; }
        [JsonPropertyName("card@2x")]
        public string Card2x { get; set; }
        [JsonPropertyName("list")]
        public string List { get; set; }
        [JsonPropertyName("list@2x")]
        public string List2x { get; set; }
        [JsonPropertyName("slimcover")]
        public string SlimCover { get; set; }
        [JsonPropertyName("slimcover@2x")]
        public string SlimCover2x { get; set; }
    }
}

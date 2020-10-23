using Newtonsoft.Json;

namespace CheffyExtractData.Domain.Entities
{
    public class ChefAvatar
    {
        [JsonProperty("large_url")]
        public string LargeUrl { get; set; }
        public string Name { get; set; }
    }
}
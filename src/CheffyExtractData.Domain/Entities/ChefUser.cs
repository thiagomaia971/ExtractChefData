using System;
using Newtonsoft.Json;

namespace CheffyExtractData.Domain.Entities
{
    public class ChefUser
    {
        public string Id { get; set; }
        [JsonProperty("last_online")]
        public DateTimeOffset LastOnline { get; set; }
    }
}
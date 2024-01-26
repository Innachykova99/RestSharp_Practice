using Newtonsoft.Json;

namespace Inna_RestSharp.Models
{
    internal class UpdateUser
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("job")]
        public string Job { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
    }
}
using System.Text.Json.Serialization;

namespace Inna_RestSharp.Models
{
    internal class UpdateUser
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("job")]
        public string Job { get; set; }

        [JsonPropertyName("updatedAt")]
        public string UpdatedAt { get; }
    }
}

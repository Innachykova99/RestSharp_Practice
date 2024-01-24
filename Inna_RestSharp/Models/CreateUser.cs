using System.Text.Json.Serialization;

namespace Inna_RestSharp.Models
{
    internal class CreateUser
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("job")]
        public string Job { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; }
    }

}

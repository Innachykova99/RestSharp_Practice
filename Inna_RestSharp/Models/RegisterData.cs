using System.Text.Json.Serialization;

namespace Inna_RestSharp.Models
{
    internal class RegisterData
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("token")]
        public string Token { get; }
    }
}

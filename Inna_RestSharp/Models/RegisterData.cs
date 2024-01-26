using Newtonsoft.Json;

namespace Inna_RestSharp.Models
{
    internal class RegisterData
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
using System.Text.Json.Serialization;

namespace Inna_RestSharp.Models
{
    internal class LoginData
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }

    internal class UnsuccessfulLogin
    {
        [JsonPropertyName("error")]
        public string Error { get; }
    }
}

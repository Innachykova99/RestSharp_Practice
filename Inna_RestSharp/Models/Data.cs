using System.Text.Json.Serialization;

namespace Inna_RestSharp.Models
{
    internal class UsersList
    {
        [JsonPropertyName("data")]
        public List<Data> Items { get; set; }
    }

    internal class Data
    {
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }
    }
}

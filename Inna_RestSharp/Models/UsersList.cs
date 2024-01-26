using Newtonsoft.Json;

namespace Inna_RestSharp.Models
{
    internal class UsersList
    {
        [JsonProperty("data")]
        public List<UserInformation> Items { get; set; }
    }

    internal class SingleUserData
    {
        [JsonProperty("data")]
        public UserInformation Data { get; set; }
    }

    internal class UserInformation
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }
    }
}
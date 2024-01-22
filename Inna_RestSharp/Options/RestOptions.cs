using RestSharp;
using System.Globalization;
using System.Text.Json.Serialization;
using System.Threading;

namespace Inna_RestSharp.Options
{
    internal class RestOptions

    {
        private RestClient _restClient;
        private RestResponse _restResponse;
        public RestClient SetUrl(string baseUrl, string endpoint)
        {
            string url = Path.Combine(baseUrl, endpoint);
            _restClient = new RestClient(url);
            return _restClient;
        }

        public RestClient CreateClientWithParameters(string baseUrl, string endpoint)
        {
            string url = Path.Combine(baseUrl, endpoint);
            var options = new RestClientOptions(url)
            {
                ThrowOnAnyError = true
            };

            _restClient = new RestClient(url);
            return _restClient;
        }

        public async Task<RestResponse> ExecuteMethod(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Get);
            return await _restClient.ExecuteAsync(request);
            
        }

        public string GetResponse(RestRequest request)
        {
            _restResponse = _restClient.GetAsync(request).GetAwaiter().GetResult();
            return _restResponse.Content;

        }

        public class User
        {
            public string Name { get; set; }
            public string Job { get; set; }

        }

        public class RegisterData
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
        
        public class Data
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

        //public async Task GetDataFromApi(string endpoint, RestClient _restClient)
        //{
        //    var _restResponse = await ExecuteMethod(endpoint);

        //    var userData = System.Text.Json.JsonSerializer.Deserialize<Data>(_restResponse.Content);

        //    Console.WriteLine($"User ID: {userData.Id}");
        //    Console.WriteLine($"First Name: {userData.FirstName}");
        //    Console.WriteLine($"Last Name: {userData.LastName}");
        //    Console.WriteLine($"Email: {userData.Email}");
        //    Console.WriteLine($"Avatar: {userData.Avatar}");
        //}

        
    }
}
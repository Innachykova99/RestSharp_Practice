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

        public async Task<string>GetResponseAsync(RestRequest request)
        {
            _restResponse = await _restClient.GetAsync(request);
            return _restResponse.Content;
        }

    }
}
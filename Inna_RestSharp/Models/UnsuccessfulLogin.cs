using Newtonsoft.Json;

namespace Inna_RestSharp.Models
{
    internal class UnsuccessfulLogin
    {
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
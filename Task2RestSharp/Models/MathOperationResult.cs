using Newtonsoft.Json;

namespace Task2RestSharp.Models
{
    internal class MathOperationResult
        {
            [JsonProperty("result")]
            public object Result { get; set; }

            [JsonProperty("errors")]
            public string Errors { get; set; }
        }
}
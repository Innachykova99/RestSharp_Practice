using Newtonsoft.Json;

namespace Task2RestSharp.Models
{
    internal class MathOperationResult
        {
            [JsonProperty("result")]
            public string Result { get; set; } 

            [JsonProperty("errors")]
            public string Errors { get; set; }
        }

    internal class MathOperationResults
    {
        [JsonProperty("result")]
        public List<string> Results { get; set; }

        [JsonProperty("errors")]
        public string Errors { get; set; }
    }

    internal class MathOperationRequest
    {
        public List<string> expr { get; set; }
        public int Precision { get; set; }
    }
}
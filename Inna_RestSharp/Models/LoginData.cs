﻿using Newtonsoft.Json;

namespace Inna_RestSharp.Models
{
    internal class LoginData
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
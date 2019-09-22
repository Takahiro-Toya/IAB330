using System;
using Newtonsoft.Json;

namespace SnackRoulette.Models
{
    public class FacebookUserModel
    {
        public string Email { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
    }
}

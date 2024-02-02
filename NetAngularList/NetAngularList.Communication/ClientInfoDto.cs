using System;
using Newtonsoft.Json;

namespace NetAngularList.Communication
{
    public class ClientInfoDto
    {
        [JsonProperty("numberInLine")]
        public int NumberInLine { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("checkInTime")]
        public DateTimeOffset CheckInTime { get; set; }
    }
}

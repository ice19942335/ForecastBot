using Newtonsoft.Json;

namespace Domain.Forecast
{
    public class Sys
    {
        [JsonProperty("pod")]
        public string Pod { get; set; }
    }
}

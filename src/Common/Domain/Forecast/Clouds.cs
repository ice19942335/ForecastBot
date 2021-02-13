using Newtonsoft.Json;

namespace Domain.Forecast
{
    public class Clouds
    {
        [JsonProperty("all")]
        public long All { get; set; }
    }
}

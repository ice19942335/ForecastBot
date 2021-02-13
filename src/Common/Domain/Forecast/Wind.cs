using Newtonsoft.Json;

namespace Domain.Forecast
{
    public class Wind
    {
        [JsonProperty("speed")]
        public long Speed { get; set; }

        [JsonProperty("deg")]
        public long Deg { get; set; }
    }
}

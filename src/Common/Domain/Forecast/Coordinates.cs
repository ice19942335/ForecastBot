using Newtonsoft.Json;

namespace Domain.Forecast
{
    public class Coordinates
    {
        [JsonProperty("lat")]
        public decimal Lat { get; set; }

        [JsonProperty("lon")]
        public decimal Lon { get; set; }
    }
}

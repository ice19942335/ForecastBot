using Newtonsoft.Json;

namespace Domain.Forecast
{
    public class Main
    {
        [JsonProperty("temp")]
        public long Temp { get; set; }

        [JsonProperty("feels_like")]
        public long FeelsLike { get; set; }

        [JsonProperty("temp_min")]
        public long TempMin { get; set; }

        [JsonProperty("temp_max")]
        public long TempMax { get; set; }

        [JsonProperty("pressure")]
        public long Pressure { get; set; }

        [JsonProperty("sea_level")]
        public long SeaLevel { get; set; }

        [JsonProperty("grnd_level")]
        public long GrndLevel { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("temp_kf")]
        public long TempKf { get; set; }
    }
}

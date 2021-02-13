using System.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.Forecast
{
    public class ForecastResponse
    {
        [JsonProperty("cod")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("cnt")]
        public long Cnt { get; set; }

        [JsonProperty("list")]
        public List<Forecast> ForecastList { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }
    }
}

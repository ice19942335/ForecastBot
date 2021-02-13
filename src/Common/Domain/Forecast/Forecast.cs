using System.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.Forecast
{
    public class Forecast
    {
        [JsonProperty("dt")]
        public string Dt { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("visibility")]
        public long Visibility { get; set; }

        [JsonProperty("pop")]
        public long Pop { get; set; }

        [JsonProperty("sys")]
        public Sys Sys { get; set; }

        [JsonProperty("dt_txt")]
        public string DateTimeText { get; set; }
    }
}

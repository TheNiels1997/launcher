namespace TWC.Weather.Models
{
    using Newtonsoft.Json;

    public class ForecastDay
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("validDate")]
        public long Date { get; set; }

        [JsonProperty("maxTemp")]
        public int? MaximumTemperature { get; set; }

        [JsonProperty("minTemp")]
        public int? MinimumTemperature { get; set; }

        [JsonProperty("precip_type")]
        public string PrecipitationType { get; set; }

        [JsonProperty("day")]
        public DayPart Day { get; set; }

        [JsonProperty("night")]
        public DayPart Night { get; set; }

        public class DayPart
        {
            [JsonProperty("humid")]
            public int? Humidity { get; set; }

            [JsonProperty("wSpeed")]
            public int? WindSpeed { get; set; }

            [JsonProperty("wDir")]
            public int? WindDirectionDegrees { get; set; }

            [JsonProperty("uv")]
            public int? UvIndex { get; set; }

            [JsonProperty("wDirText")]
            public string WindDirection { get; set; }

            [JsonProperty("phrase")]
            public string Phrase { get; set; }

            [JsonProperty("precip_type")]
            public string PrecipitationType { get; set; }

            [JsonProperty("snwAccumPhrase")]
            public string SnowAccumulationPhrase { get; set; }

            [JsonProperty("snwAccumPhraseTerse")]
            public string SnowAccumulationPhraseTerse { get; set; }
        }
    }
}

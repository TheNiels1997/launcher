namespace TWC.Weather.Models
{
    using Newtonsoft.Json;

    public class Observation
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("visibility")]
        public double? Visibility { get; set; }

        [JsonProperty("date")]
        public long? Date { get; set; }

        [JsonProperty("wxIcon")]
        public int? IconCode { get; set; }

        [JsonProperty("temp")]
        public int? Temperature { get; set; }

        [JsonProperty("dewPoint")]
        public int? DewPoint { get; set; }

        [JsonProperty("pressure")]
        public double? Pressure { get; set; }

        [JsonProperty("pressureDescription")]
        public string PressureDescription { get; set; }

        [JsonProperty("feelsLike")]
        public int? FeelsLike { get; set; }

        [JsonProperty("humid")]
        public int? Humidity { get; set; }

        [JsonProperty("wSpeed")]
        public int? WindSpeed { get; set; }

        [JsonProperty("wDir")]
        public int? WindDirectionDegrees { get; set; }

        [JsonProperty("uv")]
        public int? UvIndex { get; set; }

        [JsonProperty("uvText")]
        public string UvText { get; set; }

        [JsonProperty("obsName")]
        public string Location { get; set; }

        [JsonProperty("wDirText")]
        public string WindDirection { get; set; }

        [JsonProperty("text")]
        public string Phrase { get; set; }

        [JsonProperty("heatIndex")]
        public int? HeatIndex { get; set; }

        [JsonProperty("windchill")]
        public int? WindChill { get; set; }
    }
}

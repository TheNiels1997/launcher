using Newtonsoft.Json;

namespace TWC.Weather.Models
{
    public class WeatherLocation
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("type")]
        public int? Type { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("lat")]
        public double? Lat { get; set; }

        [JsonProperty("lng")]
        public double? Lng { get; set; }

        [JsonProperty("elv")]
        public int? Elv { get; set; }

        [JsonProperty("tz")]
        public double? Tz { get; set; }

        [JsonProperty("zoneInfo")]
        public string ZoneInfo { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("stateName")]
        public string StateName { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("forecastID")]
        public string ForecastID { get; set; }

        [JsonProperty("obsID")]
        public string ObsID { get; set; }

        [JsonProperty("dma")]
        public string Dma { get; set; }

        [JsonProperty("rgn4")]
        public string Rgn4 { get; set; }

        [JsonProperty("rgn9")]
        public string Rgn9 { get; set; }

        [JsonProperty("closeUpRadar")]
        public string CloseUpRadar { get; set; }

        [JsonProperty("localRadar")]
        public string LocalRadar { get; set; }

        [JsonProperty("metroRadar")]
        public string MetroRadar { get; set; }

        [JsonProperty("regionalRadar")]
        public string RegionalRadar { get; set; }

        [JsonProperty("ultraRadar")]
        public string UltraRadar { get; set; }

        [JsonProperty("zoneId")]
        public string ZoneId { get; set; }

        [JsonProperty("countyId")]
        public string CountyId { get; set; }

        [JsonProperty("isMarineSurf")]
        public string IsMarineSurf { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("parentLoc")]
        public string ParentLoc { get; set; }

        [JsonProperty("cID")]
        public string CID { get; set; }

        [JsonProperty("score")]
        public double? Score { get; set; }
    }
}

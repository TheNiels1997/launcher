namespace TWC.Weather.Events
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TWC.Weather.Models;

    public class SearchDataReceivedEventArgs
    {
        [JsonProperty("errors")]
        public IList<object> Errors { get; set; }

        [JsonProperty("results")]
        public IList<WeatherLocation> Results { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        public static SearchDataReceivedEventArgs Report(string json)
        {
            return JsonConvert.DeserializeObject<SearchDataReceivedEventArgs>(json);
        }
    }
}

namespace TWC.Weather.Models
{
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;

    public class ClientSettings
    {
        [JsonProperty("daycount")]
        public int DayCount { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("location")]
        public WeatherLocation Location { get; set; }

        public static async Task<ClientSettings> Load(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                return JsonConvert.DeserializeObject<ClientSettings>(await reader.ReadToEndAsync());
            }
        }

        public async Task Save(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                await writer.WriteAsync(JsonConvert.SerializeObject(this));
            }
        }
    }
}

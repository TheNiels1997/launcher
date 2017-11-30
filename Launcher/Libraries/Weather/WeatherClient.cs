namespace TWC.Weather
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Timers;
    using TWC.Weather.Events;
    using TWC.Weather.Models;

    public class WeatherClient
    {
        #region String extensions
        public async Task<string> GetPage(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage message = await client.GetAsync(url);

                if (message.StatusCode != System.Net.HttpStatusCode.OK)
                    return null;

                return await message.Content.ReadAsStringAsync();
            }
        }
        #endregion
        #region Internal URL
        string obs_url_template = "http://wxdata.weather.com/wxdata/obs/{0}.json?key=e88d3874-a740-102c-bafd-001321203584&locale={1}&units={2}";
        string fcast_url_template = "http://wxdata.weather.com/wxdata/df/{0}.json?key=e88d3874-a740-102c-bafd-001321203584&day={1}&locale={2}&units={3}";
        string location_search_url_template = "http://wxdata.weather.com/wxdata/locsearch/{0}.json?key=e88d3874-a740-102c-bafd-001321203584&locale={1}";
        #endregion
        #region Events
        public delegate void WeatherDataReceivedEventHandler(object sender, WeatherDataReceivedEventArgs e);
        public delegate void SearchDataReceivedEventHandler(object sender, SearchDataReceivedEventArgs e);
        public event SearchDataReceivedEventHandler SearchDataReceived;
        public event WeatherDataReceivedEventHandler WeatherDataReceived;
        #endregion

        ClientSettings settings;
        Timer timer;

        public ClientSettings Settings
        {
            get { return settings; }
        }

        public WeatherClient(ClientSettings clientSettings)
        {
            settings = clientSettings;

            Update();

            timer = new Timer();
            timer.Interval = 900000;
            timer.Enabled = true;
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Update();
        }
        private async void Update()
        {
            Observation obs = await GetObservation();
            List<ForecastDay> fcast = await GetForecast();

            if (obs == null || fcast == null)
                throw new System.Exception("Could not update weather. Error 1");

            WeatherDataReceived?.Invoke(this, WeatherDataReceivedEventArgs.Report(obs, fcast));
        }
        private async Task<List<ForecastDay>> GetForecast()
        {
            string days = "0";
            for (int i = 1; i < settings.DayCount; i++)
            {
                days = "," + i;
            }

            string format = string.Format(fcast_url_template, settings.Location.ParentLoc, days, settings.Locale, settings.Units);
            string page = await GetPage(format);

            if (page == null)
                return null;

            return JsonConvert.DeserializeObject<List<ForecastDay>>(page);
        }
        private async Task<Observation> GetObservation()
        {
            string format = string.Format(obs_url_template, settings.Location.ParentLoc, settings.Locale, settings.Units);
            string page = await GetPage(format);

            if (page == null)
                return null;

            return JsonConvert.DeserializeObject<Observation>(page);
        }
        public async Task Search(string location)
        {
            string format = string.Format(location_search_url_template, location, settings.Locale);
            string page = await GetPage(format);

            if (page == null)
                return;

            SearchDataReceived?.Invoke(this, SearchDataReceivedEventArgs.Report(page));
        }
    }
}

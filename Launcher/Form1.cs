namespace Launcher
{
    using TWC.Weather;
    using TWC.Weather.Models;
    using System;
    using System.Windows.Forms;
    using System.IO;

    public partial class Form1 : Form
    {
        WeatherClient client;
        ClientSettings settings;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private async void Init()
        {
            #region WeatherClientInit
            string wClientPath = string.Format(@"{0}\wClientSettings", Environment.CurrentDirectory);
            if (!File.Exists(wClientPath))
            {
                settings = new ClientSettings();
                settings.DayCount = 5;
                settings.Locale = "en";
                settings.Units = "e";

            }
            else
            {
                settings = await ClientSettings.Load(wClientPath);
            }

            client = new WeatherClient(settings);
            #endregion

        }
    }
}

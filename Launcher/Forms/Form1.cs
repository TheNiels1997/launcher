namespace Launcher
{
    using TWC.Weather;
    using TWC.Weather.Models;
    using System;
    using System.Windows.Forms;
    using System.IO;
    using Launcher.Forms;

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
            Init();
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

                using (SearchDialog diag = new SearchDialog())
                {
                    diag.CancelButtonEx.Visible = false;

                    if (diag.ShowDialog() == DialogResult.OK)
                    {
                        settings.Location = (WeatherLocation)diag.SelectedItem.Tag;
                    }
                }

                await settings.Save(wClientPath);
            }
            else
            {
                settings = await ClientSettings.Load(wClientPath);
            }

            client = new WeatherClient(settings);
            client.WeatherDataReceived += Client_WeatherDataReceived;
            #endregion

        }

        private void Client_WeatherDataReceived(object sender, TWC.Weather.Events.WeatherDataReceivedEventArgs e)
        {
            label1.Text = e.Observation.Temperature.ToString();
        }
    }
}

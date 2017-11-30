namespace Launcher.Forms
{
    using TWC.Weather;
    using System;
    using System.Windows.Forms;
    using TWC.Weather.Models;

    public partial class SearchDialog : Form
    {
        public ListViewItem SelectedItem { get; set; }
        public Button CancelButtonEx
        {
            get { return btnCancel; }
        }

        WeatherClient client;

        public SearchDialog()
        {
            InitializeComponent();
        }

        private void SearchDialog_Load(object sender, EventArgs e)
        {
            ClientSettings settings = new ClientSettings();
            settings.Locale = "en";
           
            client = new WeatherClient(settings, null);
            client.SearchDataReceived += Client_SearchDataReceived;
        }

        private void Client_SearchDataReceived(object sender, TWC.Weather.Events.SearchDataReceivedEventArgs e)
        {
            lstLocations.Items.Clear();

            foreach(WeatherLocation loc in e.Results)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = string.Format("{0}, {1}", loc.City, loc.Country);
                lvi.SubItems.Add(loc.ParentLoc);
                lvi.Tag = loc;
                lstLocations.Items.Add(lvi);
            }
        }

        private void lstLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            object item = lstLocations.SelectedItems[0];

            if (item != null)
                SelectedItem = (ListViewItem)item;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await client.Search(txtSearchLoc.Text);
        }
    }
}

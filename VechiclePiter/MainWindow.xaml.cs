using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VechiclePiter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string NameOFPickedGasStation;
        private List<float> prices = new List<float>();
        private List<string> gasStations = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            PickGasStation.IsEnabled = false;
            TCPServer.OnNewMessage += (msg) =>
            {

            };
            TCPServer.Start();
        }
        private async Task RecieveFromApi(string msg)
        {
            string resp;
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://localhost:7011/api/Vechicles"))
                {
                    HttpResponseMessage response = await httpClient.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    resp = await response.Content.ReadAsStringAsync();
                }
            }
            if (resp.Contains(msg))
            {
                int ind = resp.IndexOf(msg);
                this.Title = resp.Substring(resp.IndexOf("\"carNumber\":"), (resp.IndexOf("supportedFuel") - resp.IndexOf("\"carNumber\":")));

            }
        }
        private async void RadioButtonChecked (object sender, EventArgs e)
        {
            await GetGasStations();
            await GetPriceForFuel();
            List<string> gasStationsWithPrices = new List<string>();
            for (int i = 0; i < gasStations.Count; i++)
            {
                gasStations[i].Insert(gasStations[i].Length - 1, " - " + Convert.ToString(prices[i]));
            }
            PickGasStation.ItemsSource = gasStations;
            PickGasStation.IsEnabled = true;
        }
        private async Task GetGasStations()
        {
            string resp = "";
            using (var httpClient = new HttpClient())
            {
                int len = 0;
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://localhost:7011/api/Stations"))
                {
                    HttpResponseMessage response = await httpClient.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    resp = await response.Content.ReadAsStringAsync();
                    len = Convert.ToInt32(resp.Substring(resp.LastIndexOf("\"stationId\":") + 12, 2));
                    for (int i = 0; i < len - 1; i++)
                    {
                        int index_of_data = resp.IndexOf("\",\"data1\":1");
                        int index_of_start_address = resp.IndexOf("\"address\":") + 13;
                        int lenofaddress = index_of_data - index_of_start_address;
                        string fullstat = resp.Substring(index_of_start_address, lenofaddress);
                        gasStations.Add(fullstat);
                        resp = resp.Substring(resp.IndexOf("},"));
                    }
                }
            }
        }
        private async Task GetPriceForFuel()
        {
            string resp = "";
            using (var httpClient = new HttpClient())
            {
                int len = 0;
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://localhost:7011/api/Data"))
                {
                    HttpResponseMessage response = await httpClient.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    resp = await response.Content.ReadAsStringAsync();
                    len = Convert.ToInt32(resp.Substring(resp.LastIndexOf("\"id\":") + 5, 2));
                    int plus = 5;
                    string TypeOfFuel = "";
                    if (TypeOfFuel92.IsChecked == true)
                        TypeOfFuel = "\"92\"";
                    else if (TypeOfFuel95.IsChecked == true)
                        TypeOfFuel = "\"95\"";
                    else if (TypeOfFuel98.IsChecked == true)
                        TypeOfFuel = "\"98\"";
                    else if (TypeOfFuelDisel.IsChecked == true)
                    {
                        TypeOfFuel = "\"Disel Fuel\"";
                        plus = 13;
                    }
                    string[] smh = resp.Split('}');
                    foreach (string s in smh)
                    {
                        if (s.Contains("\"name\": \"92\""))
                        {
                            string currentFuel = s.Substring(resp.IndexOf(TypeOfFuel));
                            string subs = currentFuel.Substring(currentFuel.IndexOf("\"price\":") + 8, currentFuel.IndexOf(",\"amountOfFuel\":") - currentFuel.IndexOf("\"price\":") - 9);
                            subs = subs.Replace('.', ',');
                            float numbert = Convert.ToSingle(subs);
                            prices.Add(numbert);
                        }
                    }
                }
            }
        }
    }
}

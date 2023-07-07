﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

namespace AZSPiter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<StationModel> List = new List<StationModel>();
        List<DataModel> DataList = new List<DataModel>();
        private const string apiurl = "https://localhost:7011/api/";
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Init()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(apiurl + "Stations/" + ID_Input.Text).Result;
            response.EnsureSuccessStatusCode();
            List = response.Content.ReadAsStringAsync<List<StationModel>>();
        }
        private void GetDataButton_Click(object sender, RoutedEventArgs e)
        {
            Init();
            DataOutputWindow newwindow = new DataOutputWindow(ID_Input.Text);
        }
    }
}

﻿using System;
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

namespace GasCanPiter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _codeWord;
        TCPClient TCPClient { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            _codeWord = _generateCodeWord();
            TCPClient = new TCPClient();
            TCPClient.Connect("0");
            TCPClient.SendMessage("A999AA199");
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            int getID = 0;
            TCPServer.OnNewMessage += (msg) =>
            {
                getID = Convert.ToInt32(msg);
            };
            TCPServer.Start(AZS_ID.Text);
            MainGasCanPage newwin = new MainGasCanPage(_codeWord);
            MainPage.Content = newwin;
        }
        private string _generateCodeWord()
        {
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            Random rand = new Random();
            string word = "";
            for (int j = 1; j <= 12; j++)
            {
                int letter_num = rand.Next(0, letters.Length - 1);
                word += letters[letter_num];
            }
            return word;
        }
        private async void Init()
        {
        }
    }
}

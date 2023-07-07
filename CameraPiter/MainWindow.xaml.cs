using CameraPiter.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Media;
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

namespace CameraPiter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isAbleToPay;
        private bool _isDetected;
        private Camera_loadTableAdapter _adapter = new Camera_loadTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            PickByPhoto();
            TCPClient tCPClient = new TCPClient();
            tCPClient.Connect("30");
            tCPClient.SendMessage("True");
        }
        void CheckIsNumberDetected(string StateNumber)
        {
            foreach (DataRow data in _adapter.GetData())
            {
                if (data[2] == null)
                    PickByPhoto();
            }
        }
        void PickByPhoto()
        {
            string link = "C:\\Users\\я\\Desktop\\Сессия 2\\Ресурсы для Сессии 2\\imgs\\не распознан";
            Random rand = new Random();
            int num = rand.Next(0, 9);
            string link1 = link;
            if (num > 0)
            {
                link1 = link + "_" + num + ".jpg";
            }
            num = rand.Next(0, 9);
            string link2 = link;
            if (num > 0)
            {
                link2 = link + "_" + num + ".jpg";
            }
            num = rand.Next(0, 9);
            string link3 = link;
            if (num > 0)
            {
                link3 = link + "_" + num + ".jpg";
            }
            SystemSounds.Exclamation.Play();
            PhotoPicker picker = new PhotoPicker(link1, link2, link3);
            PickByPhotoFrame.Content = picker;
        }
       
    }
}

using Newtonsoft.Json;
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
using System.Windows.Shapes;

namespace AZSPiter
{
    /// <summary>
    /// Логика взаимодействия для DataOutputWindow.xaml
    /// </summary>
    public partial class DataOutputWindow : Window
    {
        public DataOutputWindow(string ID)
        {
            InitializeComponent();
            this.Title = $"Управление АЗС №{ID}";
            HttpClient client = new HttpClient();
        }
    }
}

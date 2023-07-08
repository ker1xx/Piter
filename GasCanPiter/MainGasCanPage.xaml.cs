using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
    /// Логика взаимодействия для MainGasCanPage.xaml
    /// </summary>
    public partial class MainGasCanPage : Page
    {
        string codeword;
        public MainGasCanPage(string _codeword)
        {
            InitializeComponent();
            this.codeword = _codeword;
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            var process = new Process
            {
                StartInfo =
                    {
                        FileName = "C:\\Users\\я\\source\\repos\\BankPiter\\BankPiter\\bin\\Debug\\BankPiter.exe",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        Arguments = "4412234512345123,Ivanov Ivan,000,950.0,Tinkoff,15,SBAH21H87JOP"
                    }
            };
            process.Start();
            using (StreamReader reader = process.StandardOutput)
            {
                string result = reader.ReadToEnd();
                MessageBox.Show(result);
            }
            MessageBox.Show("xd");
        }
    }
}

using System;
using System.Collections.Generic;
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

namespace CameraPiter
{
    /// <summary>
    /// Логика взаимодействия для PhotoPicker.xaml
    /// </summary>
    public partial class PhotoPicker : Page
    {
        public PhotoPicker(string img1, string img2, string img3)
        {
            InitializeComponent();
            Photo1.ImageSource = new BitmapImage(new Uri(img1, UriKind.Absolute));
            Photo2.ImageSource = new BitmapImage(new Uri(img2, UriKind.Absolute));
            Photo3.ImageSource = new BitmapImage(new Uri(img3, UriKind.Absolute));
        }

        private void NotFound_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

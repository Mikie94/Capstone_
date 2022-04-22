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
using MahApps.Metro.Controls;
using OpenWeather.ViewModel;

namespace OpenWeather
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UserControl
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void hide()
        {
            listForcast.Visibility = Visibility.Hidden;
            LocationTextBox.Visibility = Visibility.Hidden;
        }
        public void Call(List<float> position)
        {
           MainWindowViewModel model =  this.DataContext as MainWindowViewModel;
            model.Position = position;
            model.WeatherCommandLatLon.Execute(position);
        }
    }
}

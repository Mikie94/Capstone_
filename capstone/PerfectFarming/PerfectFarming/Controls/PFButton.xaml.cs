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

namespace PerfectFarming.Controls
{
    /// <summary>
    /// Interaction logic for PFButton.xaml
    /// </summary>
    public partial class PFButton : UserControl
    {
        public static event RoutedEventHandler Click;
        public PFButton()
        {
            InitializeComponent();
        }
        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(string), typeof(PFButton));
        public string Tag
        {
            get { return (string)GetValue(TagProperty); }
            set { SetValue(TagProperty, value); }
        }
        public static readonly DependencyProperty TagProperty = DependencyProperty.Register("Tag", typeof(string), typeof(PFButton));

        public string ToolTip
        {
            get { return (string)GetValue(ToolTipProperty); }
            set { SetValue(ToolTipProperty, value); }
        }
        public static readonly DependencyProperty ToolTipProperty = DependencyProperty.Register("ToolTip", typeof(string), typeof(PFButton));

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(sender != null)
                Click(sender, e);
        }
        public void setNoColor()
        {
            border.Background = new SolidColorBrush(Colors.Transparent);
        }
    }
}

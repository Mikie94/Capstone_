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
using PerfectFarming.Database;
using PerfectFarming.Models;

namespace PerfectFarming.Pages
{
    /// <summary>
    /// Interaction logic for FieldView.xaml
    /// </summary>
    public partial class FieldView : UserControl
    {
        DatabaseLayer db;
        public FieldView()
        {
            InitializeComponent();
            db = DatabaseLayer.Instance;
            weather.hide();
        }
        public void setFieldInfo(int field_id)
        {
            FieldExplored fieldExplored = db.GetFieldExplored(field_id);

            List<FieldCoordinate> fieldCoordinates = db.GetFieldCoordinates(field_id);
            
            if (fieldExplored != null && fieldExplored.is_used)
            {
                txtExpenses.Text = fieldExplored.planned_expense.ToString()+ " $";
                cropName.Text = fieldExplored.crop_name;
                fieldName.Content = fieldExplored.field_name;
                List<float> pos = new List<float>();
                pos.Add((float)fieldCoordinates[0].latitude);
                pos.Add((float)fieldCoordinates[0].longitude);
                weather.Call(pos);
                this.Visibility = Visibility.Visible;
            }
            else
            {
                this.Visibility = Visibility.Collapsed;
            }
        }
    }
}

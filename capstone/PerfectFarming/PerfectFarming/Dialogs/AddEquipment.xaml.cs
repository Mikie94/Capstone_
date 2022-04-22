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
using System.Windows.Shapes;
using PerfectFarming.Models;
using PerfectFarming.Database;

namespace PerfectFarming.Dialogs
{
    /// <summary>
    /// Interaction logic for AddEquipment.xaml
    /// </summary>
    public partial class AddEquipment : Window
    {
        DatabaseLayer db;
        public AddEquipment()
        {
            InitializeComponent();
            db = DatabaseLayer.Instance;
        }
        private bool validateFieldForm()
        {
            if (txtName.Text.Trim() == "") { txtName.Background = System.Windows.Media.Brushes.Red; return false; } else { txtName.Background = null; }
            if (txtMake.Text.Trim() == "") { txtMake.Background = System.Windows.Media.Brushes.Red; return false; } else { txtMake.Background = null; }
            if (txtModel.Text.Trim() == "") { txtModel.Background = System.Windows.Media.Brushes.Red; return false; } else { txtModel.Background = null; }
            return true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (validateFieldForm())
            {
                Equipment equipment = new Equipment { name=txtName.Text, make=txtMake.Text,model = txtModel.Text };
                db.AddEquipment(equipment);
                db.Commit();
                this.Close();
            }
        }

        private void txtCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

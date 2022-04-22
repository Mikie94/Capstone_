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
using PerfectFarming.Database;
using PerfectFarming.Models;

namespace PerfectFarming.Dialogs
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        DatabaseLayer db;
        public AddEmployee()
        {
            InitializeComponent();
            db = DatabaseLayer.Instance;
            List<Employee> employees = db.getEmployees();
            foreach(Employee employee in employees)
            {
                employeeTable.Items.Add(employee);
            }
            txtAge.PreviewTextInput += PreviewTextInput;
            //employeeTable.Columns[1].Visibility = Visibility.Collapsed;
            //if(employeeTable.Items.Count != 0)
            //    employeeTable.ColumnH.Visibility = Visibility.Hidden;
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !AreAllValidNumericChars(e.Text);
            base.OnPreviewTextInput(e);
        }
        private bool AreAllValidNumericChars(string str)
        {
            foreach (char c in str)
            {
                if (!Char.IsNumber(c)) return false;
            }

            return true;
        }
        private bool validateFieldForm()
        {
            if (txtFirstName.Text.Trim() == "") { txtFirstName.Background = System.Windows.Media.Brushes.Red; return false; } else { txtFirstName.Background = null; }
            if (txtLastName.Text.Trim() == "") { txtLastName.Background = System.Windows.Media.Brushes.Red; return false; } else { txtLastName.Background = null; }
            if (txtAge.Text.Trim() == "") { txtAge.Background = System.Windows.Media.Brushes.Red; return false; } else { txtAge.Background = null; }
            return true;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (validateFieldForm())
            {
                Employee employee = new Employee {first_name=txtFirstName.Text,last_name=txtLastName.Text,gender=(comboGender.SelectedItem as ComboBoxItem).Content.ToString(),age=Convert.ToInt32(txtAge.Text) };
                db.AddEmploye(employee);
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

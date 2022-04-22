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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        DatabaseLayer db;
        public AddUser()
        {
            InitializeComponent();
            db = DatabaseLayer.Instance;
            List<User> users = db.getUsers();
            foreach (User user in users)
            {
                userTable.Items.Add(user);
            }
        }
        private bool validateFieldForm()
        {
            if (txtUserName.Text.Trim() == "") { txtUserName.Background = System.Windows.Media.Brushes.Red; return false; } else { txtUserName.Background = null; }
            if (txtFirstName.Text.Trim() == "") { txtFirstName.Background = System.Windows.Media.Brushes.Red; return false; } else { txtFirstName.Background = null; }
            if (txtLastName.Text.Trim() == "") { txtLastName.Background = System.Windows.Media.Brushes.Red; return false; } else { txtLastName.Background = null; }
            if (txtEmail.Text.Trim() == "") { txtEmail.Background = System.Windows.Media.Brushes.Red; return false; } else { txtEmail.Background = null; }
            if (txtPassword.Password.Trim() == "") { txtPassword.Background = System.Windows.Media.Brushes.Red; return false; } else { txtPassword.Background = null; }
            if (txtRepeatPassword.Password.Trim() == "") { txtRepeatPassword.Background = System.Windows.Media.Brushes.Red; return false; } else { txtRepeatPassword.Background = null; }

            if(txtRepeatPassword.Password != txtPassword.Password) { MessageBox.Show("Password did not match! Please try again..");return false; }
            return true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (validateFieldForm())
            {
                User user = new User
                {
                    user_name = txtUserName.Text,
                    first_name = txtFirstName.Text,
                    last_name = txtLastName.Text,
                    email = txtEmail.Text,
                    password = txtPassword.Password,
                    user_type = (comboUserType.SelectedItem as ComboBoxItem).Content.ToString()
                };
                db.AddUser(user);
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

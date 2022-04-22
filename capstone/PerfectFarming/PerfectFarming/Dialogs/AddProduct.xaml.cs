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
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        DatabaseLayer db;
        public AddProduct()
        {
            InitializeComponent();
            db = DatabaseLayer.Instance;
            txtPrice.PreviewTextInput += PreviewTextInput;
            txtQuantity.PreviewTextInput += PreviewTextInput;
            
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
            if (txtName.Text.Trim() == "") { txtName.Background = System.Windows.Media.Brushes.Red; return false; } else { txtName.Background = null; }
            if (txtCategory.Text.Trim() == "") { txtCategory.Background = System.Windows.Media.Brushes.Red; return false; } else { txtCategory.Background = null; }
            if (txtQuantity.Text.Trim() == "") { txtQuantity.Background = System.Windows.Media.Brushes.Red; return false; } else { txtQuantity.Background = null; }
            if (txtPrice.Text.Trim() == "") { txtPrice.Background = System.Windows.Media.Brushes.Red; return false; } else { txtPrice.Background = null; }
            return true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (validateFieldForm())
            {
                Product product = new Product { 
                    name = txtName.Text, 
                    category = txtCategory.Text, 
                    quantity = Convert.ToInt32(txtQuantity.Text), 
                    price_per_item = Convert.ToInt32(txtPrice.Text) 
                };
                db.AddProduct(product);
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

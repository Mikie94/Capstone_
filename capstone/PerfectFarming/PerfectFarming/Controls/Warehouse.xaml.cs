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
using PerfectFarming.Dialogs;
using PerfectFarming.Database;
using PerfectFarming.Models;

namespace PerfectFarming.Controls
{
    /// <summary>
    /// Interaction logic for Warehouse.xaml
    /// </summary>
    public partial class Warehouse : UserControl
    {
        DatabaseLayer db;
        public Warehouse()
        {
            InitializeComponent();
            db = DatabaseLayer.Instance;
            //List<Product> products = db.getProducts();
            //listProducts.ItemsSource = products;
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddProduct productdlg = new AddProduct();
            productdlg.ShowDialog();
            List<Product> products = db.getProducts();
            listProducts.ItemsSource = null;
            listProducts.ItemsSource = products;
        }

        internal void Refresh()
        {
            List<Product> products = db.getProducts();
            listProducts.ItemsSource = null;
            listProducts.ItemsSource = products;
        }

        private void searchField_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (searchField.Text != null)
            {
                List<Product> fields = db.getProducts(searchField.Text);
                listProducts.ItemsSource = null;
                listProducts.ItemsSource = fields;
            }
            else
            {
                List<Product> fields = db.getProducts();
                listProducts.ItemsSource = null;
                listProducts.ItemsSource = fields;
            }
        }

        private void listProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product selected = (listProducts.SelectedItem as Product);
            if (selected != null)
            {
                productName.Content = selected.name;
                category.Text = selected.category;
                quantity.Text = selected.quantity.ToString();
                price.Text = selected.price_per_item.ToString();
                detailGrid.Visibility = Visibility.Visible;

            }
            else
            {
                detailGrid.Visibility = Visibility.Collapsed;
            }
        }
    }
}

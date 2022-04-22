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
    /// Interaction logic for AddOperation.xaml
    /// </summary>
    public partial class AddOperation : Window
    {
        DatabaseLayer db;
        public AddOperation()
        {
            InitializeComponent();
            db = DatabaseLayer.Instance;
            List<Equipment> equipments = db.getEquipments();
            txtEquipment.ItemsSource = equipments;
            List<Employee> employees = db.getEmployees();
            txtWorkers.ItemsSource = employees;
            List<Product> products = db.getProducts();
            txtProducts.ItemsSource = products;
            txtOutput.PreviewTextInput += PreviewTextInput;
            txtWages.PreviewTextInput += PreviewTextInput;

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
            if (txtEquipment.SelectedItem == null) { MessageBox.Show("Please select an equipment!"); return false; }
            if (txtWorkers.SelectedItem == null) { MessageBox.Show("Please select a worker!"); return false; }
            if (startDate.SelectedDate == null) { MessageBox.Show("Please select a start date!"); return false; }
            if (endDate.SelectedDate == null) { MessageBox.Show("Please select a end date!"); return false; }
            if (txtWages.Text.Trim() == "") { txtWages.Background = System.Windows.Media.Brushes.Red; return false; } else { txtWages.Background = null; }
            if (txtOutput.Text.Trim() == "") { txtOutput.Background = System.Windows.Media.Brushes.Red; return false; } else { txtOutput.Background = null; }

            return true;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (validateFieldForm())
            {
                Operation operation = new Operation
                {
                    name = txtName.Text,
                    description = "",
                    start_date = startDate.SelectedDate.Value,
                    end_date = endDate.SelectedDate.Value,
                    salary = Convert.ToDouble(txtWages.Text),
                    output_area = Convert.ToDouble(txtOutput.Text)
                    
                };
                int operationid = db.AddOperation(operation);
                foreach(Equipment equipment1 in txtEquipment.SelectedItems)
                {
                    OperationEquipment operationEquipment = new OperationEquipment
                    {
                        operation_id = operationid,
                        equipment_id = equipment1.equipment_id
                    };
                    db.AddOperationEquipment(operationEquipment);
                }
                foreach (Employee employee in txtWorkers.SelectedItems)
                {
                    OperationEmployee operationEmployee = new OperationEmployee
                    {
                        operation_id = operationid,
                        employee_id = employee.employee_id
                    };
                    db.AddOperationEmployee(operationEmployee);
                }
                foreach (Product product in txtProducts.SelectedItems)
                {
                    OperationProduct operationProduct = new OperationProduct
                    {
                        operation_id = operationid,
                        product_id = product.product_id
                    };
                    db.AddOperationProduct(operationProduct);
                }
                db.Commit();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.ShowDialog();
            List<Employee> employees = db.getEmployees();
            txtWorkers.ItemsSource = null;
            txtWorkers.ItemsSource = employees;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddEquipment addequipment = new AddEquipment();
            addequipment.ShowDialog();
            List<Equipment> equipments = db.getEquipments();
            txtEquipment.ItemsSource = null;
            txtEquipment.ItemsSource = equipments;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.ShowDialog();
            List<Product> products = db.getProducts();
            txtProducts.ItemsSource = null;
            txtProducts.ItemsSource = products;
        }
    }
}

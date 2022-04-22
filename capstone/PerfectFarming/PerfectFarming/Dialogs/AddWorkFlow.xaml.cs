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
using PerfectFarming.Dialogs;
using PerfectFarming.Database;
using PerfectFarming.Models;

namespace PerfectFarming.Dialogs
{
    /// <summary>
    /// Interaction logic for AddWorkFlow.xaml
    /// </summary>
    public partial class AddWorkFlow : Window
    {
        DatabaseLayer db;
        string season;
        public AddWorkFlow(string season)
        {
            InitializeComponent();
            db = DatabaseLayer.Instance;
            List<Field> fields = db.getFields(season);
            this.season = season;
            foreach (Field field in fields)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = field.name;
                comboBoxItem.Tag = field.field_id;
                comboFields.Items.Add(comboBoxItem);
            }
            List<Crop> crops = db.getCrops();

            foreach (Crop crop in crops)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = crop.name;
                comboBoxItem.Tag = crop.crop_id;
                comboCrops.Items.Add(comboBoxItem);
            }
            List<Operation> operations = db.getOperations();
            txtOperation.ItemsSource = operations;
            //foreach (Operation operation in operations)
            //{
            //    ComboBoxItem comboBoxItem = new ComboBoxItem();
            //    comboBoxItem.Content = operation.name;
            //    comboBoxItem.Tag = operation.operation_id;
            //    comboOperation.Items.Add(comboBoxItem);
            //}
            txtRevenue.PreviewTextInput += PreviewTextInput;
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
            if (comboCrops.SelectedItem == null) { MessageBox.Show("Please select a crop!"); return false; }
            if (comboFields.SelectedItem == null) { MessageBox.Show("Please select a field!"); return false; }
            
            if (txtStage.Text.Trim() == "") { txtStage.Background = System.Windows.Media.Brushes.Red; return false; } else { txtStage.Background = null; }
            if (txtOperation.SelectedItem == null) { MessageBox.Show("Please select a work!"); return false; }
            if (txtRevenue.Text.Trim() == "") { txtRevenue.Background = System.Windows.Media.Brushes.Red; return false; } else { txtRevenue.Background = null; }

            return true;
        }
        private void btnAddWork_Click(object sender, RoutedEventArgs e)
        {
            AddOperation operationdlg = new AddOperation();
            operationdlg.ShowDialog();

            List<Operation> operations = db.getOperations();
            txtOperation.ItemsSource = null;
            txtOperation.ItemsSource = operations;
            //comboOperation.Items.Clear();
            //foreach (Operation operation in operations)
            //{
            //    ComboBoxItem comboBoxItem = new ComboBoxItem();
            //    comboBoxItem.Content = operation.name;
            //    comboBoxItem.Tag = operation.operation_id;
            //    comboFields.Items.Add(comboBoxItem);
            //}

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (validateFieldForm())
            {
                Workflow workflow = new Workflow
                {
                    crop_id = Convert.ToInt32((comboCrops.SelectedItem as ComboBoxItem).Tag.ToString()),
                    stage = txtStage.Text,
                    name = txtName.Text,
                    is_used = false,
                    revenue = Convert.ToInt32(txtRevenue.Text)
                };
                int workflowid = db.AddWorkflow(workflow);
                foreach (Operation operation in txtOperation.SelectedItems)
                {
                    WorkflowOperation workflowOperation = new WorkflowOperation
                    {
                        operation_id = Convert.ToInt32(operation.operation_id),
                        workflow_id = workflowid,
                        is_completed = false
                    };
                    db.AddWorkflowOperation(workflowOperation);
                }
                WorkflowField workflowField = new WorkflowField
                {
                    field_id = Convert.ToInt32((comboFields.SelectedItem as ComboBoxItem).Tag.ToString()),
                    workflow_id = workflowid
                };
                db.AddWorkflowField(workflowField);
                db.Commit();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddCrop_Click(object sender, RoutedEventArgs e)
        {
            AddCrops addCrops = new AddCrops();
            addCrops.ShowDialog();
            comboCrops.ItemsSource = null;
            List<Crop> crops = db.getCrops();
            comboCrops.Items.Clear();
            foreach (Crop crop in crops)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = crop.name;
                comboBoxItem.Tag = crop.crop_id;
                comboCrops.Items.Add(comboBoxItem);
            }
        }
    }
}

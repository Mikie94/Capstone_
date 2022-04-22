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
using System.Globalization;

namespace PerfectFarming.Controls
{
    /// <summary>
    /// Interaction logic for Works.xaml
    /// </summary>
    /// 
    [ValueConversion(typeof(bool), typeof(bool))]
    class BoolInvertConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool myheader = (bool)value;
            return !myheader;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    [ValueConversion(typeof(string), typeof(bool))]
    class BoolStringCovert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool myheader = (bool)value;
            if (myheader)
                return "Completed";
            else
                return "In Progress...";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    public partial class Works : UserControl
    {
        private AddWorkFlow wfdlg;
        private string season;
        DatabaseLayer db;
        List<WorkflowViewModel> workflowList;
        WorkflowViewModel selectedWorkFlow=null;
        public Works()
        {
            InitializeComponent();
            db = DatabaseLayer.Instance;
        }
        public void setSeason(string season)
        {
            this.season = season;
        }
        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            wfdlg = new AddWorkFlow(this.season);
            wfdlg.ShowDialog();
            Refresh();
        }

        internal void Refresh()
        {
            workflowList = new List<WorkflowViewModel>();
            List<Workflow> workflows = db.getWorkflows();
            foreach(Workflow workflow in workflows)
            {
                WorkflowViewModel workflowViewModel = new WorkflowViewModel();
                workflowViewModel.WorkflowName = workflow.name;
                workflowViewModel.WorkflowId = workflow.workflow_id;
                workflowViewModel.Stage = workflow.stage;
                workflowViewModel.Crop = db.getCrop(workflow.crop_id);
                workflowViewModel.IsUsed = workflow.is_used;
                workflowViewModel.Revenue = workflow.revenue;
                List<WorkflowField> workflowFields = db.getWorkflowFields(workflow.workflow_id);
                Field field = db.getField(workflowFields[0].field_id,season);
                if (field != null)
                {
                    workflowViewModel.Field = field;
                    List<WorkflowOperation> workflowOperations = db.getWorkFlowOperations(workflow.workflow_id);
                    foreach (WorkflowOperation workflowOperation in workflowOperations)
                    {
                        OperationViewModel operationViewModel = new OperationViewModel();

                        List<Operation> operations = db.getOperations(workflowOperation.operation_id);
                        foreach (Operation operation in operations)
                        {
                            operationViewModel.OperationId = operation.operation_id;
                            operationViewModel.IsCompleted = workflowOperation.is_completed;
                            operationViewModel.OperationName = operation.name;
                            operationViewModel.Output = operation.output_area;
                            operationViewModel.Wages = operation.salary;
                            List<OperationEmployee> operationEmployees = db.getOperationEmployee(operation.operation_id);
                            List<Employee> employees = new List<Employee>();
                            foreach (OperationEmployee operationEmployee in operationEmployees)
                            {
                                employees.Add(db.getEmployee(operationEmployee.employee_id));
                            }
                            operationViewModel.Employees = employees;
                            List<OperationEquipment> operationEquipments = db.getOperationEquipments(operation.operation_id);
                            List<Equipment> equipments = new List<Equipment>();
                            foreach (OperationEquipment operationEquipment in operationEquipments)
                            {
                                equipments.Add(db.getEquipment(operationEquipment.equipment_id));
                            }
                            operationViewModel.Equipments = equipments;

                            List<OperationProduct> operationProducts = db.getOperationProducts(operation.operation_id);
                            List<Product> products = new List<Product>();
                            foreach (OperationProduct operationProduct in operationProducts)
                            {
                                products.Add(db.getProduct(operationProduct.product_id));
                            }
                            operationViewModel.Products = products;

                            operationViewModel.StartDate = operation.start_date;
                            operationViewModel.EndDate = operation.end_date;
                        }
                        workflowViewModel.Operations.Add(operationViewModel);
                    }
                    workflowList.Add(workflowViewModel);
                }
            }
            listWorkflow.ItemsSource = null;
            listWorkflow.ItemsSource = workflowList;
        }

        private void listWorkflow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WorkflowViewModel workflow = listWorkflow.SelectedItem as WorkflowViewModel;
            if(workflow != null)
            {
                detailGrid.DataContext = null;
                detailGrid.DataContext = workflow;
                selectedWorkFlow = workflow;
                btnUse.IsEnabled = !workflow.IsUsed;
                if (workflow.IsUsed)
                {
                    btnUse.Content = "Used";
                }
                else
                {
                    btnUse.Content = "Use";
                }
                detailGrid.Visibility = Visibility.Visible;
            }
            else
            {
                detailGrid.Visibility = Visibility.Hidden;
            }

        }

        private void searchField_TextChanged(object sender, TextChangedEventArgs e)
        {
            workflowList = new List<WorkflowViewModel>();
            List<Workflow> workflows;
            if (searchField.Text != null)
                workflows = db.getWorkflows(searchField.Text);
            else
                workflows = db.getWorkflows();
            foreach (Workflow workflow in workflows)
            {
                WorkflowViewModel workflowViewModel = new WorkflowViewModel();
                workflowViewModel.WorkflowId = workflow.workflow_id;
                workflowViewModel.WorkflowName = workflow.name;
                workflowViewModel.Stage = workflow.stage;
                workflowViewModel.Crop = db.getCrop(workflow.crop_id);
                workflowViewModel.IsUsed = workflow.is_used;
                workflowViewModel.Revenue = workflow.revenue;
                List<WorkflowField> workflowFields = db.getWorkflowFields(workflow.workflow_id);
                workflowViewModel.Field = db.getField(workflowFields[0].field_id, season);
                List<WorkflowOperation> workflowOperations = db.getWorkFlowOperations(workflow.workflow_id);
                foreach (WorkflowOperation workflowOperation in workflowOperations)
                {
                    OperationViewModel operationViewModel = new OperationViewModel();

                    List<Operation> operations = db.getOperations(workflowOperation.operation_id);
                    foreach (Operation operation in operations)
                    {
                        operationViewModel.OperationId = operation.operation_id;
                        operationViewModel.IsCompleted = workflowOperation.is_completed;
                        operationViewModel.OperationName = operation.name;
                        operationViewModel.Output = operation.output_area;
                        operationViewModel.Wages = operation.salary;
                        List<OperationEmployee> operationEmployees = db.getOperationEmployee(operation.operation_id);
                        List<Employee> employees = new List<Employee>();
                        foreach (OperationEmployee operationEmployee in operationEmployees)
                        {
                            employees.Add(db.getEmployee(operationEmployee.employee_id));
                        }
                        operationViewModel.Employees = employees;
                        List<OperationEquipment> operationEquipments = db.getOperationEquipments(operation.operation_id);
                        List<Equipment> equipments = new List<Equipment>();
                        foreach (OperationEquipment operationEquipment in operationEquipments)
                        {
                            equipments.Add(db.getEquipment(operationEquipment.equipment_id));
                        }
                        operationViewModel.Equipments = equipments;

                        List<OperationProduct> operationProducts = db.getOperationProducts(operation.operation_id);
                        List<Product> products = new List<Product>();
                        foreach (OperationProduct operationProduct in operationProducts)
                        {
                            products.Add(db.getProduct(operationProduct.product_id));
                        }
                        operationViewModel.Products = products;

                        operationViewModel.StartDate = operation.start_date;
                        operationViewModel.EndDate = operation.end_date;
                    }
                    workflowViewModel.Operations.Add(operationViewModel);
                }
                workflowList.Add(workflowViewModel);
            }
            listWorkflow.ItemsSource = null;
            listWorkflow.ItemsSource = workflowList;
        }

        private void btnUse_Click(object sender, RoutedEventArgs e)
        {
            if(selectedWorkFlow != null)
            {
                db.UseWorkFlow(selectedWorkFlow.WorkflowId, true);
                db.Commit();
                btnUse.Content = "Used";
                btnUse.IsEnabled = false;
                Refresh();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int operation_id = Convert.ToInt32((sender as Button).Tag.ToString());
            db.setOperationCompleted(operation_id, true);
            db.Commit();
            Refresh();
            
        }
    }
}

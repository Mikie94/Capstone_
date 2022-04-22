using PerfectFarming.Database;
using PerfectFarming.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        DatabaseLayer db;
        List<WorkflowViewModel> workflowList;
        WorkflowViewModel selectedWorkFlow = null;
        private string c_season;
        long plannedExpenses;
        double totalExpenses;
        double actualExpenses;
        int totalWorks;
        double workCompletedCost;
        double totalArea;
        long totalFields;


        public Dashboard()
        {
            InitializeComponent();
            db = DatabaseLayer.Instance;
        }

        public long PlannedExpenses { get => plannedExpenses; set => plannedExpenses = value; }
        public double TotalExpenses { get => totalExpenses; set => totalExpenses = value; }
        public int TotalWorks { get => totalWorks; set => totalWorks = value; }
        public double TotalArea { get => totalArea; set => totalArea = value; }
        public long TotalFields { get => totalFields; set => totalFields = value; }
        public double ActualExpenses { get => actualExpenses; set => actualExpenses = value; }

        public void setSeason(string season)
        {
            c_season = season;
        }
        internal void Refresh()
        {
            workflowList = new List<WorkflowViewModel>();
            List<Workflow> workflows = db.getWorkflows();
            
            foreach (Workflow workflow in workflows)
            {

                WorkflowViewModel workflowViewModel = new WorkflowViewModel();
                workflowViewModel.WorkflowName = workflow.name;
                workflowViewModel.WorkflowId = workflow.workflow_id;
                workflowViewModel.Stage = workflow.stage;
                workflowViewModel.Crop = db.getCrop(workflow.crop_id);
                workflowViewModel.IsUsed = workflow.is_used;
                List<WorkflowField> workflowFields = db.getWorkflowFields(workflow.workflow_id);
                Field field = db.getField(workflowFields[0].field_id, c_season);
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
            TotalFields = db.getFields(c_season).Count;
            txtTotalFields.Text = TotalFields.ToString();
            txtFieldsCount.Text = TotalFields.ToString();
            TotalArea = 0;
            foreach (Field field in db.getFields(c_season))
            {
                TotalArea += field.area_covered;
            }
            txtTotalArea.Text = TotalArea.ToString();

            TotalExpenses = 0;
            foreach (Crop crop in db.getCrops())
            {
                TotalExpenses += crop.planned_expense;
            }
            txtPlannedExpenses.Text = TotalExpenses.ToString();
            progressBar.Maximum = TotalExpenses;
            ActualExpenses = 0;
            
            foreach (WorkflowViewModel model in workflowList)
            {
                if(model.IsUsed)
                    ActualExpenses += model.TotalExpense;
                TotalWorks = 0;
                double workExpense = 0;
                int assistants = 0;
                List<string> workTypes = new List<string>();

                double duration = 0;
                foreach (OperationViewModel model1 in model.Operations)
                {
                    if (model1.IsCompleted)
                    {
                        TotalWorks += 1;
                        workExpense += model.TotalExpense;
                        assistants += model.TotalWorkers;
                        double count = 0;
                        
                        duration += (model1.EndDate - model1.StartDate).TotalDays;

                        if (!workTypes.Contains(model1.OperationName.ToLower())){
                            workTypes.Add(model1.OperationName.ToLower());
                        }
                    }
                }
                txtTotalWorks.Text = TotalWorks.ToString();
                txtTotalCost.Text = workExpense.ToString();
                txtDoneByAssistants.Text = assistants.ToString();
                txtTotalDuration.Text = duration.ToString();
                txtWorkTypes.Text = workTypes.Count.ToString();
            }
            txtActualExpenses.Text = ActualExpenses.ToString();
            progressBar.Value = ActualExpenses;
            
        }
    }
}

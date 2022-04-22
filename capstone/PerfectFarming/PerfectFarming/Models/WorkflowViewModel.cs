using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectFarming.Models
{
    class WorkflowViewModel
    {
        int workflowId;
        string workflowName;
        Crop crop;
        Field field;
        List<OperationViewModel> operations;
        string stage;
        double totalExpense;
        int revenue;
        int totalEquipments;
        int totalWorkers;
        int totalProducts;
        double totalDays;
        bool isUsed;
        public WorkflowViewModel()
        {
            operations = new List<OperationViewModel>();
        }

        public string WorkflowName { get => workflowName; set => workflowName = value; }
        public Crop Crop { get => crop; set => crop = value; }
        public Field Field { get => field; set => field = value; }
        public List<OperationViewModel> Operations { get => operations; set => operations = value; }
        public string Stage { get => stage; set => stage = value; }

        public double TotalExpense { 
            get {
                double wage=0.0;
                foreach(OperationViewModel operation in operations)
                {
                    wage += operation.Wages;
                }
                foreach (OperationViewModel operation in operations)
                {
                    foreach(Product product in operation.Products)
                        wage += product.price_per_item * product.quantity;
                }
                totalExpense = wage;
                return totalExpense;
            } 
            set => totalExpense = value;
        }
        public int TotalEquipments { 
            get {
                int count = 0;
                foreach (OperationViewModel operation in operations)
                {
                    count += operation.Equipments.Count;
                }
                totalEquipments = count;
                return totalEquipments;
            }
            set => totalEquipments = value;
        }
        public int TotalWorkers { 
            get {
                int count = 0;
                foreach (OperationViewModel operation in operations)
                {
                    count += operation.Employees.Count;
                }
                totalWorkers = count;
                return totalWorkers; 
            } 
            set => totalWorkers = value; 
        }
        public int TotalProducts
        {
            get
            {
                int count = 0;
                foreach (OperationViewModel operation in operations)
                {
                    count += operation.Products.Count;
                }
                totalProducts = count;
                return totalProducts;
            }
            set => totalProducts = value;
        }

        public double TotalDays
        {
            get
            {
                double count = 0;
                foreach (OperationViewModel operation in operations)
                {
                    count += (operation.EndDate - operation.StartDate).TotalDays;
                }
                totalDays = count;
                return totalDays;
            }
            set => totalDays = value;
        }

        public bool IsUsed { get => isUsed; set => isUsed = value; }
        public int WorkflowId { get => workflowId; set => workflowId = value; }
        public int Revenue { get => revenue; set => revenue = value; }
    }
}

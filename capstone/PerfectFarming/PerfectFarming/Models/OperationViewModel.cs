using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectFarming.Models
{
    class OperationViewModel
    {
        int operationId;
        string operationName;
        List<Employee> employees;
        List<Equipment> equipment;
        List<Product> products;
        DateTime startDate;
        DateTime endDate;
        double wages;
        double output;
        bool isCompleted;
        public OperationViewModel()
        {
            employees = new List<Employee>();
            equipment = new List<Equipment>();
            products = new List<Product>();
        }

        public string OperationName { get => operationName; set => operationName = value; }
        public List<Employee> Employees { get => employees; set => employees = value; }
        public List<Equipment> Equipments { get => equipment; set => equipment = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public double Wages { get => wages; set => wages = value; }
        public double Output { get => output; set => output = value; }
        public List<Product> Products { get => products; set => products = value; }
        public int OperationId { get => operationId; set => operationId = value; }
        public bool IsCompleted { get => isCompleted; set => isCompleted = value; }
    }
}

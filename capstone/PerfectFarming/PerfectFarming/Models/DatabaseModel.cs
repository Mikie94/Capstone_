using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.EntityFramework;
using MySqlX.XDevAPI.CRUD;

namespace PerfectFarming.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DatabaseModel : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Crop> Crops { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<FieldCoordinate> FielCoordiates { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<OperationEmployee> OperationEmployee { get; set; }
        public DbSet<OperationEquipment> OperationEquipments { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<WorkflowField> WorkflowFields { get; set; }
        public DbSet<WorkflowOperation> WorkflowOperations { get; set; }
        public DbSet<Workflow> Workflows { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OperationProduct> OperationProducts { get; set; }
        public DatabaseModel()
      : base()
        {
            
        }

        public DatabaseModel(DbConnection existingConnection, bool contextOwnsConnection)
          : base(existingConnection, contextOwnsConnection)
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().MapToStoredProcedures();
            modelBuilder.Entity<Field>().MapToStoredProcedures();
            modelBuilder.Entity<Crop>().MapToStoredProcedures();
            modelBuilder.Entity<Employee>().MapToStoredProcedures();
            modelBuilder.Entity<Equipment>().MapToStoredProcedures();
            modelBuilder.Entity<FieldCoordinate>().MapToStoredProcedures();
            modelBuilder.Entity<Note>().MapToStoredProcedures();
            modelBuilder.Entity<OperationEmployee>().MapToStoredProcedures();
            modelBuilder.Entity<OperationEquipment>().MapToStoredProcedures();
            modelBuilder.Entity<Operation>().MapToStoredProcedures();
            modelBuilder.Entity<Season>().MapToStoredProcedures();
            modelBuilder.Entity<WorkflowField>().MapToStoredProcedures();
            modelBuilder.Entity<WorkflowOperation>().MapToStoredProcedures();
            modelBuilder.Entity<Workflow>().MapToStoredProcedures();
            modelBuilder.Entity<Product>().MapToStoredProcedures();
            modelBuilder.Entity<OperationProduct>().MapToStoredProcedures();
        } 
    }
    public class User
    {
        [Key]
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string user_type { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }

    }

    public class Field
    {
        [Key]
        public int field_id { get; set; }
        public int season_id { get; set; }
        public string name { get; set; }
        public double area_covered{ get; set; }
    }

    public class Crop
    {
        [Key]
        public int crop_id{ get; set; }
        public string name{ get; set; }
        public string description{ get; set; }
        public string color { get; set; }
        public double planned_expense { get; set; }
    }
    public class Employee
    {
        [Key]
        public int employee_id{ get; set; }
        public string first_name{ get; set; }
        public string last_name{ get; set; }
        public string gender{ get; set; }
        public int age{ get; set; }
    }
    public class Equipment
    {
        [Key]
        public int equipment_id{ get; set; }
        public string name{ get; set; }
        public string make{ get; set; }
        public string model{ get; set; }
    }
    public class FieldCoordinate
    {
        [Key]
        public int id { get; set; }
        public int field_id{ get; set; }
        public double latitude{ get; set; }
        public double longitude{ get; set; }
    }
    public class Note
    {
        [Key]
        public int note_id{ get; set; }
        public string name { get; set; }
        public string description{ get; set; }
        public string filename { get; set; }
        public long file_size { get; set; }
        public Byte[] data{ get; set; }
    }
    public class OperationEmployee
    {
        [Key]
        public int id { get; set; }
        public int operation_id{ get; set; }
        public int employee_id{ get; set; }
    }
    public class OperationEquipment
    {
        [Key]
        public int id { get; set; }
        public int operation_id{ get; set; }
        public int equipment_id{ get; set; }
        public double output_area{ get; set; }
        public float percentage{ get; set; }
        public double fuel_consumption{ get; set; }
    }
    public class Operation
    {
        [Key]
        public int operation_id{ get; set; }
        public string name{ get; set; }
        public string description{ get; set; }
        public DateTime start_date{ get; set; }
        public DateTime end_date{ get; set; }
        public double output_area{ get; set; }
        public double salary{ get; set; }
    }
    public class Season
    {
        [Key]
        public int id { get; set; }
        public int season_id{ get; set; }
        public string name{ get; set; }
    }
    public class WorkflowField
    {
        [Key]
        public int id { get; set; }
        public int workflow_id{ get; set; }
        public int field_id{ get; set; }
    }
    public class WorkflowOperation
    {
        [Key]
        public int id { get; set; }
        public int workflow_id{ get; set; }
        public int operation_id{ get; set; }
        public bool is_completed { get; set; }
    }
    public class Workflow
    {
        [Key]
        public int workflow_id{ get; set; }
        public string name { get; set; }
        public int crop_id{ get; set; }
        public string stage{ get; set; }
        public bool is_used { get; set; }
        public int revenue { get; set; }
    }
    public class Product
    {
        [Key]
        public int product_id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public int quantity { get; set; }
        public int price_per_item { get; set; }
    }
    public class OperationProduct
    {
        [Key]
        public int id { get; set; }
        public int operation_id { get; set; }
        public int product_id { get; set; }
    }
    public class FieldExplored
    {
        public int field_id { get; set; }
        public string field_name { get; set; }
        public string color { get; set; }
        public string crop_name { get; set; }
        public int workflow_id { get; set; }
        public bool is_used { get; set; }
        public long area_covered { get; set; }
        public long planned_expense { get; set; }
    }
}

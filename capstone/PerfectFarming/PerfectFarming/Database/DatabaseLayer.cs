using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PerfectFarming.Models;
using System.Configuration;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Timers;
using System.Windows.Forms;

namespace PerfectFarming.Database
{
    public sealed class DatabaseLayer
    {
        private DatabaseModel db;
        MySqlConnection con=null;
        MySqlTransaction transaction;
        private static DatabaseLayer instance = null;

        private DatabaseLayer()
        {
            try
            {
                con = new MySqlConnection(ConfigurationManager.ConnectionStrings["MyContext"].ConnectionString);
                
                db = new DatabaseModel(con, true);
                db.Database.CreateIfNotExists();
                con.Open();
                transaction = con.BeginTransaction();
                db.Database.UseTransaction(transaction);
            }
            catch(Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.InnerException.Message);
                //System.Windows.Forms.Application.Exit();
            }
        }
        public void setDb(string constring)
        {
            con = new MySqlConnection(constring);

            db = new DatabaseModel(con, true);
            db.Database.CreateIfNotExists();
            con.Open();
            transaction = con.BeginTransaction();
            db.Database.UseTransaction(transaction);
        }

        internal List<Product> getProducts()
        {
            string query = "SELECT * FROM products";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<Product> ls = new List<Product>();
            while (da.Read())
            {
                ls.Add(new Product { 
                    product_id = da.GetInt32(0), 
                    name = da.GetString(da.GetOrdinal("name")).ToString(), 
                    category = da.GetString(da.GetOrdinal("category")), 
                    quantity = da.GetInt32(da.GetOrdinal("quantity")), 
                    price_per_item = da.GetInt32(da.GetOrdinal("price_per_item")) 
                });
            }
            da.Close();
            return ls;
        }

        internal List<Product> getProducts(string text)
        {
            string query = "SELECT * FROM products where name like '%"+text+"%'";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<Product> ls = new List<Product>();
            while (da.Read())
            {
                ls.Add(new Product { product_id = da.GetInt32(0), name = da.GetString(da.GetOrdinal("name")).ToString(), category = da.GetString(da.GetOrdinal("category")), quantity = da.GetInt32(da.GetOrdinal("quantity")), price_per_item = da.GetInt32(da.GetOrdinal("price_per_item")) });
            }
            da.Close();
            return ls;
        }

        internal List<Equipment> getEquipments(string text)
        {
            string query = "SELECT * FROM equipments where name like '%"+text+"%'";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<Equipment> ls = new List<Equipment>();
            while (da.Read())
            {
                ls.Add(new Equipment { 
                    equipment_id = da.GetInt32(0), 
                    name = da.GetString(1).ToString(), 
                    make = da.GetString(2), 
                    model = da.GetString(3) });
            }
            da.Close();
            return ls;
        }

        internal List<WorkflowField> getWorkflowFields(int workflow_id)
        {
            string query = "SELECT * FROM workflowfields where workflow_id=" + workflow_id.ToString();// where operation_id=" + operation_id.ToString();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<WorkflowField> ls = new List<WorkflowField>();
            while (da.Read())
            {
                ls.Add(new WorkflowField { id = da.GetInt32(0), workflow_id = da.GetInt32(1), field_id = da.GetInt32(2) });
            }
            da.Close();
            return ls;
        }

        internal Field getField(int field_id,string season)
        {
            string query = "SELECT * FROM fields where field_id="+field_id.ToString()+" and season_id=" + season;
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<Field> ls = new List<Field>();
            while (da.Read())
            {
                ls.Add(new Field { field_id = da.GetInt32(0), name = da.GetString(2).ToString(), season_id = da.GetInt32(1), area_covered = da.GetInt32(3) });
            }
            da.Close();
            if (ls.Count > 0)
                return ls[0];
            else
                return null;
        }

        internal List<Note> getNotes(string text)
        {
            List<Note> notes = new List<Note>();
            string query = "SELECT * FROM notes where name like '%"+text+"%'";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                UInt64 FileSize = da.GetUInt64(da.GetOrdinal("file_size"));
                byte[] rawData = null;
                if (FileSize != 0)
                {
                    rawData = new byte[FileSize];
                    da.GetBytes(da.GetOrdinal("data"), 0, rawData, 0, (int)FileSize);
                }
                notes.Add(new Note { 
                    note_id = da.GetInt32(0), 
                    name = da.GetString(1).ToString(), 
                    description = da.GetString(2), 
                    file_size = (long)FileSize, 
                    filename = da.GetString(3), data = rawData });
            }
            da.Close();
            return notes;
        }

        internal List<Workflow> getWorkflows(string text)
        {
            string query = "SELECT * FROM workflows where name like '%"+ text +"%'";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<Workflow> ls = new List<Workflow>();
            while (da.Read())
            {
                ls.Add(new Workflow { 
                    workflow_id = da.GetInt32(0), 
                    crop_id = da.GetInt32(da.GetOrdinal("crop_id")), 
                    name = da.GetString(da.GetOrdinal("name")), 
                    stage = da.GetString(da.GetOrdinal("stage")), 
                    is_used = da.GetBoolean(da.GetOrdinal("is_used")),
                    revenue = da.GetInt32(da.GetOrdinal("revenue"))
                });
                    
            }
            da.Close();
            return ls;
        }

        internal Crop getCrop(int crop_id)
        {
            string query = "SELECT * FROM crops where crop_id="+crop_id.ToString();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<Crop> ls = new List<Crop>();
            while (da.Read())
            {
                ls.Add(new Crop { crop_id = da.GetInt32(0), name = da.GetString(1).ToString(), description = da.GetString(2), color = da.GetString(3),planned_expense=da.GetInt64(4) });
            }
            da.Close();
            return ls[0];
        }

        internal List<OperationProduct> getOperationProducts(int operation_id)
        {
            string query = "SELECT * FROM operationproducts where operation_id=" + operation_id.ToString();// where operation_id=" + operation_id.ToString();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<OperationProduct> ls = new List<OperationProduct>();
            while (da.Read())
            {
                ls.Add(new OperationProduct { id = da.GetInt32(0), operation_id = da.GetInt32(1), product_id = da.GetInt32(2) });
            }
            da.Close();
            return ls;
        }

        internal List<Operation> getOperations(int operation_id)
        {
            string query = "SELECT * FROM operations where operation_id="+operation_id.ToString();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<Operation> ls = new List<Operation>();
            while (da.Read())
            {
                ls.Add(new Operation { operation_id = da.GetInt32(0), name = da.GetString(1).ToString(), description = da.GetString(2), start_date = da.GetDateTime(3), end_date = da.GetDateTime(4), output_area = da.GetInt32(5), salary = da.GetInt32(6)});
            }
            da.Close();
            return ls;
        }

        internal Product getProduct(int product_id)
        {
            string query = "SELECT * FROM products where product_id="+product_id.ToString();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<Product> ls = new List<Product>();
            while (da.Read())
            {
                ls.Add(new Product { product_id = da.GetInt32(0), name = da.GetString(da.GetOrdinal("name")).ToString(), category = da.GetString(da.GetOrdinal("category")), quantity = da.GetInt32(da.GetOrdinal("quantity")), price_per_item = da.GetInt32(da.GetOrdinal("price_per_item")) });
            }
            da.Close();
            return ls[0];
        }

        internal void UseWorkFlow(int workflowId, bool v)
        {
            string query = "Update workflows set is_used=" + Convert.ToInt32(v).ToString() + " where workflow_id=" + workflowId.ToString();// * FROM workflows where workflow_id=" + workflowId.ToString();
            MySqlCommand cmd = new MySqlCommand(query, con);
            int e = cmd.ExecuteNonQuery();
            Workflow workflow = Db.Workflows.Where(p => p.workflow_id == workflowId).FirstOrDefault();
            workflow.is_used = v;
            Db.Entry(workflow).Reload();
            //Db.SaveChanges();
        }

        public Workflow getWorkflows(int workflowId)
        {
            string query = "SELECT * FROM workflows where workflow_id="+workflowId.ToString();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<Workflow> ls = new List<Workflow>();
            while (da.Read())
            {
                ls.Add(new Workflow { workflow_id = da.GetInt32(0), crop_id = da.GetInt32(da.GetOrdinal("crop_id")), name = da.GetString(da.GetOrdinal("name")), stage = da.GetString(da.GetOrdinal("stage")), is_used = da.GetBoolean(da.GetOrdinal("is_used")), revenue= da.GetInt32(da.GetOrdinal("revenue")) });
            }
            da.Close();
            return ls[0];
        }

        internal void AddOperationProduct(OperationProduct operationProduct)
        {
            try
            {
                Db.OperationProducts.Add(operationProduct);
                Db.SaveChanges();

            }
            catch (Exception ex)
            {
            }
        }

        internal List<OperationEmployee> getOperationEmployee(int operation_id)
        {
            string query = "SELECT * FROM operationemployees where operation_id="+operation_id.ToString();// where operation_id=" + operation_id.ToString();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<OperationEmployee> ls = new List<OperationEmployee>();
            while (da.Read())
            {
                ls.Add(new OperationEmployee {id= da.GetInt32(0), operation_id = da.GetInt32(1), employee_id = da.GetInt32(2) });
            }
            da.Close();
            return ls;
        }

        internal void setOperationCompleted(int operation_id, bool v)
        {
            string query = "Update workflowoperations set is_completed=" + Convert.ToInt32(v).ToString() + " where operation_id=" + operation_id.ToString();// * FROM workflows where workflow_id=" + workflowId.ToString();
            MySqlCommand cmd = new MySqlCommand(query, con);
            int e = cmd.ExecuteNonQuery();
            WorkflowOperation operation = Db.WorkflowOperations.Where(p => p.operation_id == operation_id).FirstOrDefault();
            operation.is_completed = v;
            Db.Entry(operation).Reload();
        }

        internal List<WorkflowOperation> getWorkFlowOperations(int workflow_id)
        {
            string query = "SELECT * FROM workflowoperations where workflow_id="+workflow_id.ToString();// where operation_id=" + operation_id.ToString();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<WorkflowOperation> ls = new List<WorkflowOperation>();
            while (da.Read())
            {
                ls.Add(new WorkflowOperation { id = da.GetInt32(0), workflow_id = da.GetInt32(1), operation_id = da.GetInt32(2), is_completed = da.GetBoolean(3) });
            }
            da.Close();
            return ls;
        }

        internal Employee getEmployee(int employee_id)
        {
            string query = "SELECT * FROM employees where employee_id="+employee_id.ToString();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<Employee> ls = new List<Employee>();
            while (da.Read())
            {
                ls.Add(new Employee { employee_id = da.GetInt32(0), first_name = da.GetString(1).ToString(), last_name = da.GetString(2), gender = da.GetString(3), age = da.GetInt32(4) });
            }
            da.Close();
            return ls[0];
        }

        internal List<OperationEquipment> getOperationEquipments(int operation_id)
        {
            string query = "SELECT * FROM operationequipments where operation_id="+operation_id.ToString();// where operation_id=" + operation_id.ToString();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<OperationEquipment> ls = new List<OperationEquipment>();
            while (da.Read())
            {
                ls.Add(new OperationEquipment { id = da.GetInt32(0), operation_id = da.GetInt32(1), equipment_id = da.GetInt32(2), output_area = da.GetDouble(da.GetOrdinal("output_area")), fuel_consumption = da.GetDouble(da.GetOrdinal("fuel_consumption")), percentage = da.GetFloat(da.GetOrdinal("percentage")) });
            }
            da.Close();
            return ls;
        }

        internal List<Workflow> getWorkflows()
        {
            string query = "SELECT * FROM workflows";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<Workflow> ls = new List<Workflow>();
            while (da.Read())
            {
                ls.Add(new Workflow { workflow_id = da.GetInt32(0), crop_id = da.GetInt32(da.GetOrdinal("crop_id")), name = da.GetString(da.GetOrdinal("name")), stage = da.GetString(da.GetOrdinal("stage")),is_used= da.GetBoolean(da.GetOrdinal("is_used")), revenue = da.GetInt32(da.GetOrdinal("revenue")) });
            }
            da.Close();
            return ls;
        }

        internal Equipment getEquipment(int equipment_id)
        {
            string query = "SELECT * FROM equipments where equipment_id="+equipment_id.ToString();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<Equipment> ls = new List<Equipment>();
            while (da.Read())
            {
                ls.Add(new Equipment { equipment_id = da.GetInt32(0), name = da.GetString(1).ToString(), make = da.GetString(2), model = da.GetString(3) });
            }
            da.Close();
            return ls[0];
        }

        internal List<User> getUsers()
        {
            string query = "SELECT * FROM users";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<User> ls = new List<User>();
            while (da.Read())
            {
                ls.Add(new User { user_id = da.GetInt32(0), user_name = da.GetString(da.GetOrdinal("user_name")).ToString(), first_name = da.GetString(da.GetOrdinal("first_name")), last_name = da.GetString(da.GetOrdinal("last_name")), email = da.GetString(da.GetOrdinal("email")), password = da.GetString(da.GetOrdinal("password")), user_type = da.GetString(da.GetOrdinal("user_type")) });
            }
            da.Close();
            return ls;
        }

        internal void AddProduct(Product product)
        {
            try
            {
                Db.Products.Add(product);
                Db.SaveChanges();

            }
            catch (Exception ex)
            {
            }
        }

        public static DatabaseLayer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseLayer();
                }
                return instance;
            }
        }
        public DatabaseModel Db { get => db;}
        
        public int AddField(Field field)
        {
            try
            {
                Db.Fields.Add(field);
                Db.SaveChanges();
                //transaction.Commit();
                return field.field_id;
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return -1;
            }
        }

        internal void AddCrop(Crop crop)
        {
            try
            {
                Db.Crops.Add(crop);
                Db.SaveChanges();
                //transaction.Commit();
            }
            catch { }
        }

        public void AddNote(Note note)
        {
            try
            {
                Db.Notes.Add(note);
                Db.SaveChanges();
                //transaction.Commit();
            }
            catch (Exception ex){ Console.WriteLine(ex.Message); }

        }
        
        public List<Note> getNotes()
        {
            List<Note> notes = new List<Note>();
            string query = "SELECT * FROM notes";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                UInt64 FileSize = da.GetUInt64(da.GetOrdinal("file_size"));
                byte[] rawData=null;
                if (FileSize != 0)
                {
                    rawData = new byte[FileSize];
                    da.GetBytes(da.GetOrdinal("data"), 0, rawData, 0, (int)FileSize);
                }
                notes.Add(new Note { note_id = da.GetInt32(0), name = da.GetString(1).ToString(), description = da.GetString(2),file_size=(long)FileSize, filename=da.GetString(3), data = rawData });
            }
            da.Close();
            return notes;
        }

        internal void AddUser(User user)
        {
            try
            {
                Db.Users.Add(user);
                Db.SaveChanges();
            }
            catch
            {
            }
        }

        internal void AddOperationEquipment(OperationEquipment operationEquipment)
        {
            try
            {
                Db.OperationEquipments.Add(operationEquipment);
                Db.SaveChanges();
            }
            catch
            {
            }
        }

        internal void AddOperationEmployee(OperationEmployee operationEmployee)
        {
            try
            {
                Db.OperationEmployee.Add(operationEmployee);
                Db.SaveChanges();
            }
            catch
            {
            }
        }

        internal int AddWorkflow(Workflow workflow)
        {
            try
            {
                Db.Workflows.Add(workflow);
                Db.SaveChanges();
                
                return workflow.workflow_id;
            }
            catch
            {
                return -1;
                //transaction.Rollback();
            }
        }

        internal void AddWorkflowOperation(WorkflowOperation workflowOperation)
        {
            try
            {
                Db.WorkflowOperations.Add(workflowOperation);
                Db.SaveChanges();
            }
            catch
            {
            }
        }

        internal int AddOperation(Operation operation)
        {
            try
            {
                Db.Operations.Add(operation);
                Db.SaveChanges();
                
                return operation.operation_id;
            }
            catch
            {
                return -1;
                //transaction.Rollback();
            }
        }

        internal void AddWorkflowField(WorkflowField workflowField)
        {
            try
            {
                Db.WorkflowFields.Add(workflowField);
                Db.SaveChanges();
            }
            catch
            {
            }
        }

        public List<Field> getFields(string season)
        {

            string query = "SELECT * FROM fields where season_id="+season;
            MySqlCommand cmd = new MySqlCommand(query,con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<Field> ls = new List<Field>();
            while (da.Read()){
                ls.Add(new Field { 
                    field_id = da.GetInt32(0), 
                    name = da.GetString(2).ToString(), 
                    season_id = da.GetInt32(1), 
                    area_covered = da.GetInt32(3) });
            }
            da.Close();
            return ls;
        }
        public List<Employee> getEmployees()
        {

            string query = "SELECT * FROM employees";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<Employee> ls = new List<Employee>();
            while (da.Read())
            {
                ls.Add(new Employee { employee_id = da.GetInt32(0), first_name = da.GetString(1).ToString(), last_name = da.GetString(2), gender = da.GetString(3),age=da.GetInt32(4) });
            }
            da.Close();
            return ls;
        }
        public List<FieldCoordinate> GetFieldCoordinates(int field_id)
        {
            string query = "SELECT * FROM fieldcoordinates where field_id=" + field_id.ToString() + " ORDER BY id DESC";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<FieldCoordinate> ls = new List<FieldCoordinate>();
            while (da.Read())
            {
                ls.Add(new FieldCoordinate { id = da.GetInt32(0), field_id = field_id, latitude = da.GetDouble(2), longitude = da.GetDouble(3) });
            }
            da.Close();
            return ls;
        }
        public FieldExplored GetFieldExplored(int field_id)
        {
            string query = "SELECT fe.field_id,fe.name,cr.color,cr.name,wf.workflow_id,wf.is_used,cr.planned_expense FROM FIELDS as fe inner join workflowfields as wff on fe.field_id = wff.field_id inner join workflows as wf on wff.workflow_id = wf.workflow_id inner join crops as cr on cr.crop_id = wf.crop_id where fe.field_id=" + field_id.ToString() + " ORDER BY id DESC";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<FieldExplored> ls = new List<FieldExplored>();
            while (da.Read())
            {
                ls.Add(new FieldExplored { field_id = da.GetInt32(0), field_name = da.GetString(1), color = da.GetString(2), crop_name = da.GetString(3), workflow_id=da.GetInt32(4), is_used=da.GetBoolean(5),planned_expense=da.GetInt64(6) });
            }
            da.Close();
            if (ls.Count > 0)
                return ls[0];
            else
                return null;
        }
        public List<FieldExplored> GetFieldsExplored()
        {
            string query = "SELECT fe.field_id,fe.name,cr.color,cr.name,wf.workflow_id,wf.is_used,cr.planned_expense FROM FIELDS as fe inner join workflowfields as wff on fe.field_id = wff.field_id inner join workflows as wf on wff.workflow_id = wf.workflow_id inner join crops as cr on cr.crop_id = wf.crop_id";// where as.field_id=" + field_id.ToString() + " ORDER BY id DESC";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<FieldExplored> ls = new List<FieldExplored>();
            while (da.Read())
            {
                ls.Add(new FieldExplored { field_id = da.GetInt32(0), field_name = da.GetString(1), color = da.GetString(2), crop_name = da.GetString(3), workflow_id = da.GetInt32(4),is_used=da.GetBoolean(5), planned_expense = da.GetInt64(6) });
            }
            da.Close();
            return ls;
        }
        public List<FieldExplored> GetFieldsExplored(string seasons)
        {
            string query = "SELECT fe.field_id,fe.name,cr.color,cr.name,wf.workflow_id,wf.is_used,fe.area_covered,cr.planned_expense FROM FIELDS as fe inner join workflowfields as wff on fe.field_id = wff.field_id inner join workflows as wf on wff.workflow_id = wf.workflow_id inner join crops as cr on cr.crop_id = wf.crop_id where fe.season_id=" + seasons;// where as.field_id=" + field_id.ToString() + " ORDER BY id DESC";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<FieldExplored> ls = new List<FieldExplored>();
            while (da.Read())
            {
                ls.Add(new FieldExplored { field_id = da.GetInt32(0), field_name = da.GetString(1), color = da.GetString(2), crop_name = da.GetString(3), workflow_id = da.GetInt32(4), is_used = da.GetBoolean(5),area_covered=da.GetInt64(6), planned_expense = da.GetInt64(7) });
            }
            da.Close();
            return ls;
        }
        public List<Crop> getCrops()
        {
            string query = "SELECT * FROM crops";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<Crop> ls = new List<Crop>();
            while (da.Read())
            {
                ls.Add(new Crop { 
                    crop_id = da.GetInt32(0), 
                    name = da.GetString(1).ToString(), 
                    description = da.GetString(2), 
                    color = da.GetString(3),
                    planned_expense=da.GetDouble(4) });
            }
            da.Close();
            return ls;
        }

        internal List<Field> getFields(string text, string season)
        {
            string query = "SELECT * FROM fields where name like '%"+text+"%' and season_id=" + season;
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<Field> ls = new List<Field>();
            while (da.Read())
            {
                ls.Add(new Field { field_id = da.GetInt32(0), name = da.GetString(2).ToString(), season_id = da.GetInt32(1), area_covered = da.GetInt32(3) });
            }
            da.Close();
            return ls;
        }

        public List<Operation> getOperations()
        {
            string query = "SELECT * FROM operations";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<Operation> ls = new List<Operation>();
            while (da.Read())
            {
                ls.Add(new Operation { operation_id = da.GetInt32(0), name = da.GetString(1).ToString(), description = da.GetString(2), start_date = da.GetDateTime(3), end_date = da.GetDateTime(4), output_area= da.GetInt32(5),salary= da.GetInt32(6) });
            }
            da.Close();
            return ls;
        }
        public List<Equipment> getEquipments()
        {
            string query = "SELECT * FROM equipments";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<Equipment> ls = new List<Equipment>();
            while (da.Read())
            {
                ls.Add(new Equipment { equipment_id = da.GetInt32(0), name = da.GetString(1).ToString(), make = da.GetString(2), model = da.GetString(3) });
            }
            da.Close();
            return ls;
        }
        public void Commit()
        {
            try
            {
                transaction.Commit();
            }
            catch { }
        }
        public void AddFieldCoordinate(FieldCoordinate fieldCoordinate)
        {

            try
            {
                Db.FielCoordiates.Add(fieldCoordinate);
                Db.SaveChanges();
                //transaction.Commit();
            }
            catch
            {
                //transaction.Rollback();
            }
        }
        public void AddEmploye(Employee employee)
        {

            try
            {
                Db.Employees.Add(employee);
                Db.SaveChanges();
                //transaction.Commit();
            }
            catch
            {
                //transaction.Rollback();
            }
        }
        public void AddFieldCoordinates(List<FieldCoordinate> fc)
        {
            try
            {
                Db.FielCoordiates.AddRange(fc);
                Db.SaveChanges();
                //transaction.Commit();
            }
            catch
            {
               //transaction.Rollback();
            }
        }
        public void AddEquipment(Equipment equipment)
        {
            try
            {
                Db.Equipments.Add(equipment);
                Db.SaveChanges();
                //transaction.Commit();
            }
            catch
            {
                //transaction.Rollback();
            }
        }

        public List<User> checkLogin(string text, string password)
        {
            string query = "SELECT * FROM users where user_name like '" + text + "' and password like '" + password + "'";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader da = cmd.ExecuteReader();
            List<User> ls = new List<User>();
            while (da.Read())
            {
                ls.Add(new User { user_id = da.GetInt32(0), user_name = da.GetString(da.GetOrdinal("user_name")).ToString(), first_name = da.GetString(da.GetOrdinal("first_name")), last_name = da.GetString(da.GetOrdinal("last_name")), email = da.GetString(da.GetOrdinal("email")), password = da.GetString(da.GetOrdinal("password")), user_type = da.GetString(da.GetOrdinal("user_type")) });
            }
            da.Close();
            return ls;
        }
    }
}

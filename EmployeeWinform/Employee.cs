using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace EmployeeWinform
{
    internal class Employee
    {
        public string id { get; set; }
        public string name { get; set; }
        public string age { get; set; }
        public string contact { get; set; }

        public string gender { get; set; }

        private static string conStr = "Server=localhost;Port=5432;Database=winformE3;User Id=postgres;Password=12345;";
        NpgsqlConnection con = new NpgsqlConnection(conStr);

        private const string SelectQuery = "Select * from employee";
        private const string InsertQuery = "Insert Into employee(id, name, age, contact, gender) Values (@id, @name, @age, @contact, @gender)";
        private const string UpdateQuery = "Update employee set name=@name, age=@age, contact=@contact, gender=@gender where id=@id";
        private const string DeleteQuery = "Delete from employee where id=@id";

        public DataTable GetEmployees()
        {
            var datatable = new DataTable();
            using (NpgsqlConnection con = new NpgsqlConnection(conStr))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(SelectQuery, con))
                {
                    using (NpgsqlDataAdapter adapter = new  NpgsqlDataAdapter(command))
                    {
                        adapter.Fill(datatable);
                    }
                }
            }
            
            return datatable;
        }

        public bool InsertEmployee(Employee employee)
        {
            int rows;
            using (NpgsqlConnection con = new NpgsqlConnection(conStr))
            {
                con.Open();
                using (NpgsqlCommand command = new  NpgsqlCommand(InsertQuery, con))
                {
                    command.Parameters.AddWithValue("@id", employee.id);
                    command.Parameters.AddWithValue("@name", employee.name);
                    command.Parameters.AddWithValue("@age", employee.age);
                    command.Parameters.AddWithValue("@contact", employee.contact);
                    command.Parameters.AddWithValue("@gender", employee.gender);
                    rows = command.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }


        public bool UpdateEmployee(Employee employee)
        {

            int rows;
            using (NpgsqlConnection con = new NpgsqlConnection(conStr))
            {
                con.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(UpdateQuery, con))
                {
                    command.Parameters.AddWithValue("@name", employee.name);
                    command.Parameters.AddWithValue("@age", employee.age);
                    command.Parameters.AddWithValue("@contact", employee.contact);
                    command.Parameters.AddWithValue("@gender", employee.gender);
                    command.Parameters.AddWithValue("@id", employee.id);
                    rows = command.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }


        public bool DeleteEmployee(Employee employee)
        {
            int rows;
            using (NpgsqlConnection con = new NpgsqlConnection(conStr))
            {
                con.Open();
                using (NpgsqlCommand com = new    NpgsqlCommand(DeleteQuery, con))
                {
                    com.Parameters.AddWithValue("@id", employee.id);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }
    }
}

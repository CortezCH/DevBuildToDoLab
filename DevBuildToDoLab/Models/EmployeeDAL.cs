using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBuildToDoLab.Models
{
    public class EmployeeDAL
    {

        public List<Employee> GetEmployees()
        {
            using(var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "SELECT * FROM Employee";
                connect.Open();
                List<Employee> employees = connect.Query<Employee>(sql).ToList();
                connect.Close();

                return employees;
            }
        }

        public Employee GetEmployee(int ID)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"SELECT * FROM Employee WHERE EmployeeID = {ID}";
                connect.Open();
                Employee employees = connect.Query<Employee>(sql).First();
                connect.Close();
                return employees;
            }
        }

        public List<String> GetEmployeesNames()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"SELECT `Name` FROM Employee";
                connect.Open();
                List<String> names = connect.Query<String>(sql).ToList();
                connect.Close();
                return names;
            }
        }

        public void CreateUser(Employee model)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"INSERT INTO Employee values" +
                    $"({model.EmployeeID}," +
                    $"'{model.Name}'," +
                    $"{model.Hours}," +
                    $"'{model.Title}')";
                connect.Open();
                connect.Query<Employee>(sql);
                connect.Close();
            }
        }

        public void UpdateUser(Employee model)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"UPDATE Employee " +
                    $"SET `Name` = '{model.Name}', Hours = {model.Hours}, Title = '{model.Title}' " +
                    $"WHERE EmployeeID = {model.EmployeeID}";
                connect.Open();
                connect.Query<Employee>(sql);
                connect.Close();
            }
        }

        public void DeleteUser(int ID)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string deleteUserSQL = $"DELETE FROM Employee where EmployeeID = {ID}";
                string unassignTasks = $"UPDATE ToDos SET AssignedTo = null WHERE AssignedTo = {ID}";
                connect.Open();
                connect.Query(unassignTasks);
                connect.Query(deleteUserSQL);
                connect.Close();
            }
        }
    }
}

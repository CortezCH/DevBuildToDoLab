using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBuildToDoLab.Models
{
    public class ToDoDAL
    {
        public List<ToDo> GetToDos()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "SELECT * FROM ToDos";
                connect.Open();
                List<ToDo> toDos = connect.Query<ToDo>(sql).ToList();
                connect.Close();

                return toDos;
            }
        }

        public List<ToDo> GetToDos(Employee employee)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"SELECT * FROM ToDos WHERE AssignedTo = {employee.EmployeeID}";
                connect.Open();
                List<ToDo> toDos = connect.Query<ToDo>(sql).ToList();
                connect.Close();

                return toDos;
            }
        }
    }
}

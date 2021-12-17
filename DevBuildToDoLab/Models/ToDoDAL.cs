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
        
        public ToDo GetToDo(int id)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"SELECT * FROM ToDos WHERE ID = {id}";
                connect.Open();
                ToDo toDo = connect.Query<ToDo>(sql).ToList().First();
                connect.Close();

                return toDo;
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

        public void CreateToDo(ToDo model)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"INSERT INTO ToDos values({model.ID}, {model.AssignedTo}, '{model.Name}', '{model.Description}', {model.HoursNeeded}, {model.IsComplete})";
                connect.Open();
                connect.Query<ToDo>(sql);
                connect.Close();
            }
        }

        public void DeleteToDo(int toDoId)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"DELETE FROM ToDos where ID = {toDoId}";
                connect.Open();
                connect.Query<ToDo>(sql);
                connect.Close();
            }
        }

        public void UpdateToDo(ToDo model)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"UPDATE ToDos SET " +
                    $"ID = {model.ID}, " +
                    $"`Name` = '{model.Name}', " +
                    $"Description = '{model.Description}', " +
                    $"HoursNeeded = {model.HoursNeeded}, " +
                    $"IsComplete = {model.IsComplete}";
                connect.Open();
                connect.Query<ToDo>(sql);
                connect.Close();
            }
        }

        public void AssignToDo(ToDo model)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"UPDATE ToDos SET AssignedTo = {model.AssignedTo}";
                connect.Open();
                connect.Query<ToDo>(sql);
                connect.Close();
            }
        }

        public void MarkComplete(int id)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"UPDATE ToDos SET AssignedTo = null, IsComplete = 1 WHERE ID = {id}";
                connect.Open();
                connect.Query(sql);
                connect.Close();
            }
        }
    }
}

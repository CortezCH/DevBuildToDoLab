using DevBuildToDoLab.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBuildToDoLab.Controllers
{
    public class ToDoController : Controller
    {
        EmployeeDAL EmployeeDAL = new EmployeeDAL();
        ToDoDAL ToDoDAL = new ToDoDAL();

        public IActionResult Index()
        {
            List<ToDo> model = ToDoDAL.GetToDos();
            ViewData["Employees"] = EmployeeDAL.GetEmployees();
            return View(model);
        }

        public IActionResult CreateToDo()
        {
            ViewData["Employees"] = EmployeeDAL.GetEmployees();
            return View();
        }

        [HttpPost]
        public IActionResult CreateToDo(ToDo model)
        {
            Employee selectedEmployee = EmployeeDAL.GetEmployee(model.AssignedTo);
            if (ModelState.IsValid && selectedEmployee.Hours > model.HoursNeeded)
            {
                ToDoDAL.CreateToDo(model);
                return RedirectToAction("Index", "ToDo");
            }

            ViewData["Employees"] = EmployeeDAL.GetEmployees();
            ViewData["ErrorMessage"] = "This employee doesn't have enough Hours";
            return View(model);
        }

        public IActionResult DeleteToDo(int id)
        {
            ToDoDAL.DeleteToDo(id);
            return RedirectToAction("Index", "ToDo");
        }

        public IActionResult UpdateToDo(int id)
        {
            ToDo model =ToDoDAL.GetToDo(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateToDo(ToDo model)
        {
            ToDoDAL.UpdateToDo(model);
            return RedirectToAction("Index", "ToDo");
        }

        public IActionResult AssignToDo(int id)
        {
            ToDo model = ToDoDAL.GetToDo(id);
            ViewData["Employees"] = EmployeeDAL.GetEmployees();
            return View(model);
        }

        [HttpPost]
        public IActionResult AssignToDo(ToDo model)
        {
            if (model.AssignedTo == 0)
            {
                return RedirectToAction("Index", "ToDo");
            }
            ToDoDAL.AssignToDo(model);
            Employee updateHoursForEmployee = EmployeeDAL.GetEmployee(model.AssignedTo);
            updateHoursForEmployee.Hours -= model.HoursNeeded;
            EmployeeDAL.UpdateUser(updateHoursForEmployee);
            return RedirectToAction("Index", "ToDo");
        }

        public IActionResult MarkComplete(int id)
        {
            ToDo toDoModel = ToDoDAL.GetToDo(id);
            if (toDoModel.AssignedTo != 0)
            {
                Employee employeeToUpdateHours = EmployeeDAL.GetEmployee(toDoModel.AssignedTo);

                EmployeeDAL.ToDoComplete(id, toDoModel.HoursNeeded + employeeToUpdateHours.Hours);
            }
            
            ToDoDAL.MarkComplete(id);
            return RedirectToAction("Index", "ToDo");
        }
    }

}

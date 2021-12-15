using DevBuildToDoLab.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBuildToDoLab.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL EmployeeDAL = new EmployeeDAL();
        ToDoDAL ToDoDAL = new ToDoDAL();

        public IActionResult Index()
        {
            List<Employee> model = EmployeeDAL.GetEmployees();
            return View(model);
        }

        public IActionResult CreateUser()
        {
            Employee model = new Employee();
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateUser(Employee model)
        {
            if (ModelState.IsValid)
            {
                EmployeeDAL.CreateUser(model);
                return RedirectToAction("RegistrationConfirmation", "Employee", model);
            }

            return View(model);
        }

        public IActionResult RegistrationConfirmation(Employee model)
        {
            return View(model);
        }

        public IActionResult UpdateUser(int employeeID)
        {
            return View(EmployeeDAL.GetEmployee(employeeID));
        }

        [HttpPost]
        public IActionResult UpdateUser(Employee model)
        {
            if (ModelState.IsValid)
            {
                EmployeeDAL.UpdateUser(model);
                return RedirectToAction("Index", "Employee");
            }
            return View(model);
        }

        public IActionResult DeleteUser(int modelID)
        {
            Employee model = EmployeeDAL.GetEmployee(modelID);
            return View();
        }

        [HttpPost]
        public IActionResult DeleteUser(Employee model)
        {
            EmployeeDAL.DeleteUser(model.EmployeeID);
            return RedirectToAction("Index", "Employee");
        }

        public IActionResult Details(int ID)
        {
            Employee model = EmployeeDAL.GetEmployee(ID);
            ViewData["Employee"] = model;
            ViewData["ToDos"] = ToDoDAL.GetToDos(model);
            return View();
        }
    }
}

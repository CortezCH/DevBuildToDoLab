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
            return View(model);
        }

        public IActionResult CreateToDo()
        {
            //ViewData["Employees"] = EmployeeDAL.GetEmployeesNames();
            return View();
        }

        [HttpPost]
        public IActionResult CreateToDo(ToDo model)
        {
            if (ModelState.IsValid)
            {
                ToDoDAL.CreateToDo(model);
                return RedirectToAction("Index", "ToDo");
            }

            return View(model);
        }
    }

}

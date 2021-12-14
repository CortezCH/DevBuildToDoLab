using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevBuildToDoLab.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; } = 0;

        [MaxLength(20, ErrorMessage = "Name Must be 20 characters or less")]
        public string Name { get; set; }

        [Range(0, 40, ErrorMessage = "Max of 40 hours. Not Enough Hours")]
        public int Hours { get; set; }

        List<ToDo> toDos = new List<ToDo>();
    }
}

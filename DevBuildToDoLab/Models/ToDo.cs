using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevBuildToDoLab.Models
{
    public class ToDo
    {
        [Key]
        public int ID { get; set; } = 0;
        public int AssignedTo { get; set; }

        [MaxLength(20, ErrorMessage = "Task names must be 20 characters or less.")]
        [RegularExpression(@"^.*\S.*$", ErrorMessage = "Name cannot be empty.")]
        public string Name { get; set; }

        [MaxLength(100, ErrorMessage = "Descriptions must be 100 characters or less.")]
        public string Description { get; set; }

        [Range(0, 40, ErrorMessage ="Hours needed must be between 1 and 40 hours")]
        public int HoursNeeded { get; set; }
        public bool IsComplete { get; set; } = false;
    }
}

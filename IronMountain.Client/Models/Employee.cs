using System;
using System.ComponentModel.DataAnnotations;

namespace Iron_Mountain_Coding_Challenge.Models
{
    public class Employee
    {
        [Range(0, 99999999)]
        public int EmployeeID { get; set; }

        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        public DateTime DOB { get; set; }
    }
}

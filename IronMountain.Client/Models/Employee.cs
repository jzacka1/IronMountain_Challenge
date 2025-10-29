//using Castle.Components.DictionaryAdapter;
using System;
using System.ComponentModel.DataAnnotations;

namespace Iron_Mountain_Coding_Challenge.Models
{
    public class Employee
    {
        [Key]
        [Required]
        [StringLength(8)]
        public string EmployeeID { get; set; }

        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        public DateTime DOB { get; set; }
    }
}

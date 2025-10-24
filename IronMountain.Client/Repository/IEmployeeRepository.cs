using Iron_Mountain_Coding_Challenge.Models;
using System.Collections.Generic;

namespace Iron_Mountain_Coding_Challenge.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        void Add(Employee employee);
        void Save();
    }
}

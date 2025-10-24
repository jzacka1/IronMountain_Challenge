using Iron_Mountain_Coding_Challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Iron_Mountain_Coding_Challenge.Repository
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context) {
            _context = context;
        }

        public void Add(Employee employee)
        {
            _context.Employee.Add(employee);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employee.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

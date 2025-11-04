using Iron_Mountain_Coding_Challenge.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

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

        public IEnumerable<Employee> SearchByNlp(string query)
        {
            var terms = query.ToLower().Split(' ');

            IQueryable<Employee> q = _context.Employee;

            if (terms.Contains("older") || terms.Any(t => t.Contains("age")))
            {
                // Example: find minimum age number in text
                var age = terms.Where(t => int.TryParse(t, out _))
                               .Select(int.Parse)
                               .DefaultIfEmpty(0)
                               .First();

                var minDob = DateTime.Now.AddYears(-age);
                q = q.Where(e => e.DOB <= minDob);
            }

            return q.ToList();
        }
    }
}

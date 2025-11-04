using DocumentFormat.OpenXml.Spreadsheet;
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

        public async Task<IEnumerable<Employee>> SearchByNlp(dynamic filters)
        {
            var query = _context.Employee.AsQueryable();

            if (filters.AgeMin != null)
            {
                DateTime dobLimit = DateTime.Today.AddYears(-(int)filters.AgeMin);
                query = query.Where(e => e.DOB <= dobLimit);
            }

            if (filters.AgeMax != null)
            {
                DateTime dobLimit = DateTime.Today.AddYears(-(int)filters.AgeMax);
                query = query.Where(e => e.DOB >= dobLimit);
            }

            if (filters.NameContains != null)
            {
                string name = (string)filters.NameContains;
                query = query.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name));
            }

            return await query.ToListAsync();
        }
    }
}

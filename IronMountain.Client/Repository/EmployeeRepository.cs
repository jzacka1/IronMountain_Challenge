using DocumentFormat.OpenXml.Spreadsheet;
using Iron_Mountain_Coding_Challenge.Models;
using NMemory.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace Iron_Mountain_Coding_Challenge.Repository
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        private readonly EmployeeContext _context;
        private readonly MemoryCache _cache = MemoryCache.Default;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(5);

        public EmployeeRepository(EmployeeContext context) {
            _context = context;
        }

        public async Task<Employee> FindAsync(string id)
        {
            return await Task.Run(() => _context.Employee.FindAsync(id));
        }

        public async Task AddAsync(Employee employee)
        {
            await Task.Run(() => _context.Employee.Add(employee));
        }

        public async Task UpdateAsync(Employee employee)
        {
            await Task.Run(() => _context.Entry(employee).State = EntityState.Modified);
        }

        public async Task DeleteAsync(string id) 
        {
            var emp = await Task.Run(() => FindAsync(id));
            if(emp == null)
            {
                throw new Exception("Employee doesn't exist");
            }
            await Task.Run(() => _context.Employee.Remove(emp));
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context
                .Employee
                .AsNoTracking()
                .ToListAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Employee>> SearchByNlp(dynamic filters)
        {
            // Create a unique string key for this filter set
            string cacheKey = $"nlp_{filters.AgeMin}_{filters.AgeMax}_{filters.NameContains}";

            // Check cache first
            if (_cache.Contains(cacheKey))
            {
                return (IEnumerable<Employee>)_cache.Get(cacheKey);
            }

            var query = _context
                .Employee
                .AsNoTracking()
                .AsQueryable();

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

            var result = await query.ToListAsync();

            // Store in cache
            _cache.Set(cacheKey, result, DateTimeOffset.Now.Add(_cacheDuration));

            //return await query.ToListAsync();
            return result;
        }
    }
}

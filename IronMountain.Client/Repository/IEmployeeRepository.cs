using Iron_Mountain_Coding_Challenge.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Iron_Mountain_Coding_Challenge.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task AddAsync(Employee employee);
        void Save();
        Task<IEnumerable<Employee>> SearchByNlp(dynamic filters);
    }
}

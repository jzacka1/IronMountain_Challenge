using System;
using System.Data.Common;
using System.Data.Entity;

namespace Iron_Mountain_Coding_Challenge.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("name=EmployeeDBConnection") { }

        // This constructor allows in-memory testing with Effort
        public EmployeeContext(DbConnection connection) : base(connection, true) { }

        public DbSet<Employee> Employee { get; set; }

    }
}

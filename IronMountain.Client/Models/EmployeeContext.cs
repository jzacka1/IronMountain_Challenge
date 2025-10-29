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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeID)
                .HasMaxLength(8)
                .IsRequired()
                .IsUnicode(false); // saves space in SQL (uses varchar(8))
        }

    }
}

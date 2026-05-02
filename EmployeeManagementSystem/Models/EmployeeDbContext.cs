using System.Data.Entity;

namespace EmployeeManagementSystem.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext() : base("EmployeeDBConnection")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

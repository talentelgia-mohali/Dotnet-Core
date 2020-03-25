using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreExample.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { EmployeeId = 1, Name = "John", Designation = "Developer", Address = "New York", CompanyName = "XYZ Inc", Salary = 30000 },
                new Employee() { EmployeeId = 2, Name = "Chris", Designation = "Manager", Address = "New York", CompanyName = "ABC Inc", Salary = 50000 },
                new Employee() { EmployeeId = 3, Name = "Mukesh", Designation = "Consultant", Address = "New Delhi", CompanyName = "XYZ Inc", Salary = 20000 });
        }
    }
}

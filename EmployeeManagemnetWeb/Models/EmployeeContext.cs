using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EmployeeManagemnetWeb.Models
{
    public partial class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=EmployeeContext")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeID)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.MobileNo)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .IsFixedLength();
        }
    }
}

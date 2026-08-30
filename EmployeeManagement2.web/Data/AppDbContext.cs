using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Web.Models;

namespace EmployeeManagement.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // العلاقة One-to-Many بين Department و Employee
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict); // منع حذف قسم فيه موظفين

            // بيانات أولية (Seed Data) - اختياري
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "IT", Location = "Cairo" },
                new Department { Id = 2, Name = "HR", Location = "Mansoura" },
                new Department { Id = 3, Name = "Finance", Location = "Alexandria" }
            );
        }
    }
}
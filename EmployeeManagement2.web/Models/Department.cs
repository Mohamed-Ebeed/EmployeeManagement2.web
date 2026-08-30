using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Web.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Department name is required.")]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Location { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
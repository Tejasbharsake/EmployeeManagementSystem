using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        public virtual ICollection<Designation> Designations { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }

    public class Designation
    {
        public int DesignationId { get; set; }

        [Required]
        public string DesignationName { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}

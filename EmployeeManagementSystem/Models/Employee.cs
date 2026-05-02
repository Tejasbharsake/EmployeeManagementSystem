using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee Name is required.")]
        [MinLength(3, ErrorMessage = "Minimum 3 characters required.")]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone must be exactly 10 digits.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "Salary must be greater than 0.")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Designation is required.")]
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }

        [MaxLength(250, ErrorMessage = "Address cannot exceed 250 characters.")]
        public string Address { get; set; }

        public DateTime CreatedDate { get; set; }

        // Navigation properties
        public virtual Department Department { get; set; }
        public virtual Designation Designation { get; set; }
    }
}

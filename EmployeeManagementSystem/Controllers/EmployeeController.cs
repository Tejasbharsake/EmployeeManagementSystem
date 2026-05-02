using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext db = new EmployeeDbContext();

        // GET: Employee/Index - List all employees
        public ActionResult Index()
        {
            var employees = db.Employees
                .Include("Department")
                .Include("Designation")
                .ToList();
            return View(employees);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.Departments = new SelectList(db.Departments.ToList(), "DepartmentId", "DepartmentName");
            ViewBag.Designations = new SelectList(new List<Designation>(), "DesignationId", "DesignationName");
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    employee.CreatedDate = DateTime.Now;
                    db.Employees.Add(employee);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Employee created successfully!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error saving employee: " + ex.Message);
                }
            }

            ViewBag.Departments = new SelectList(db.Departments.ToList(), "DepartmentId", "DepartmentName", employee.DepartmentId);
            ViewBag.Designations = new SelectList(
                db.Designations.Where(d => d.DepartmentId == employee.DepartmentId).ToList(),
                "DesignationId", "DesignationName", employee.DesignationId);
            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = db.Employees.Find(id);
            if (employee == null)
                return HttpNotFound();

            ViewBag.Departments = new SelectList(db.Departments.ToList(), "DepartmentId", "DepartmentName", employee.DepartmentId);
            ViewBag.Designations = new SelectList(
                db.Designations.Where(d => d.DepartmentId == employee.DepartmentId).ToList(),
                "DesignationId", "DesignationName", employee.DesignationId);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existing = db.Employees.Find(employee.EmployeeId);
                    if (existing == null)
                        return HttpNotFound();

                    existing.EmployeeName = employee.EmployeeName;
                    existing.Email = employee.Email;
                    existing.PhoneNumber = employee.PhoneNumber;
                    existing.Salary = employee.Salary;
                    existing.DepartmentId = employee.DepartmentId;
                    existing.DesignationId = employee.DesignationId;
                    existing.Address = employee.Address;

                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Employee updated successfully!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error updating employee: " + ex.Message);
                }
            }

            ViewBag.Departments = new SelectList(db.Departments.ToList(), "DepartmentId", "DepartmentName", employee.DepartmentId);
            ViewBag.Designations = new SelectList(
                db.Designations.Where(d => d.DepartmentId == employee.DepartmentId).ToList(),
                "DesignationId", "DesignationName", employee.DesignationId);
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var employee = db.Employees.Find(id);
                if (employee == null)
                    return HttpNotFound();

                db.Employees.Remove(employee);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Employee deleted successfully!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error deleting employee: " + ex.Message;
            }
            return RedirectToAction("Index");
        }

        // GET: Employee/GetDesignations?departmentId=1 (AJAX)
        public JsonResult GetDesignations(int departmentId)
        {
            var designations = db.Designations
                .Where(d => d.DepartmentId == departmentId)
                .Select(d => new { d.DesignationId, d.DesignationName })
                .ToList();
            return Json(designations, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}

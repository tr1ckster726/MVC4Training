using eManager.Domain;
using eManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eManager.Web.Controllers
{
    [Authorize(Roles = "Admin")] // This means the user has to be logged in and registered in order to be able to render this action
    public class EmployeeController : Controller
    {
        private readonly IDepartmentDataSource _db;

        public EmployeeController(IDepartmentDataSource db)
        {
            this._db = db;
        }

        // GET: Employee
        [HttpGet]
        public ActionResult Create(int departmentId)  // the MVC runtime will automatically look in the Query String for departmentId      
        {
            var model = new CreateEmployeeViewModel();
            model.DepartmentId = departmentId;

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateEmployeeViewModel viewModel)
        {
            if (ModelState.IsValid) // was viewModel correctly put together?
            {
                // Save a new employee to the database
                var department = _db.Departments.Single(d => d.Id == viewModel.DepartmentId);
                var employee = new Employee();

                employee.Name = viewModel.Name;
                employee.HireDate = viewModel.HireDate;
                department.Employees.Add(employee);    // Entity framework will detect all changes and create an INSERT statement for a new Employee

                _db.Save(); // Don't forget to save to the database!!!

                return RedirectToAction("detail", "department", new { id = viewModel.DepartmentId });
            }

            return View(viewModel);
        }
    }
}
using Aspnet_MVC_Crud.Data;
using Aspnet_MVC_Crud.Models;
using Aspnet_MVC_Crud.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aspnet_MVC_Crud.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MvcDemoDbContext mvcDemoDbContext;

        public EmployeesController(MvcDemoDbContext _mvcDemoDbContext)
        {
            this.mvcDemoDbContext = _mvcDemoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await mvcDemoDbContext.Employees.ToListAsync();
            return View(employees);

            // create view
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                Department = addEmployeeRequest.Department,
                DateOfBirth = addEmployeeRequest.DateOfBirth
            };

            await mvcDemoDbContext.Employees.AddAsync(employee);
            await mvcDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }



    }
}

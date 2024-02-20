using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORM_Database_First.Models;

namespace ORM_Database_First.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EmployeeController : ControllerBase
	{
		private readonly DBFirst_testContext _context;

		public EmployeeController(DBFirst_testContext context)
		{
			_context = context;
		}

		[HttpPost]
		public IActionResult CreateEmployee(Employee employee)
		{
			_context.Employees.Add(employee);
			_context.SaveChanges();
			return Ok(employee);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteEmployee(int id)
		{
			var employee = _context.Employees.Find(id);
			if (employee == null)
			{
				return NotFound();
			}

			_context.Employees.Remove(employee);
			_context.SaveChanges();
			return NoContent();
		}


		[HttpPost("createEmployeeUsingProc")]
		public IActionResult CreateEmployeeUsingProcedures(EmployeeDTO employee)
		{
			var returnList = _context.Database.ExecuteSqlInterpolated($"EXEC CreateEmployee {employee.Name}");


			if (returnList == 0)
			{
				return BadRequest();
			}
			_context.SaveChanges();
			return Ok();

		}

		[HttpGet]
		public IActionResult GetEmployees()
		{
			var employees = _context.Employees;

			if (employees == null)
			{
				return NotFound();
			}
			return Ok(employees);

		}


		[HttpPut("{id}")]
		public IActionResult UpdateEmployee(int id, EmployeeDTO employee)
		{
			var returnList = _context.Database.ExecuteSqlInterpolated($"EXEC UpdateEmployee {employee.Name}, {id}");


			if (returnList == 0)
			{
				return BadRequest();
			}
			_context.SaveChanges();
			return Ok();
		}
	}
}

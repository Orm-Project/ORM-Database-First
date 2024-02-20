using Microsoft.AspNetCore.Mvc;
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
		public IActionResult CreateEmployee([FromBody] Employee employee)
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
	}
}

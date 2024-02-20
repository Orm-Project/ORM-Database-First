using Microsoft.AspNetCore.Mvc;
using ORM_Database_First.Models;

namespace ORM_Database_First.Controllers
{
	public class DepartmentEmployeeController : Controller
	{
		[ApiController]
		[Route("api/[controller]")]
		public class DepartmentEmployeesController : ControllerBase
		{
			private readonly DBFirst_testContext _context;

			public DepartmentEmployeesController(DBFirst_testContext context)
			{
				_context = context;
			}

			[HttpPost]
			public IActionResult CreateDepartmentEmployee(DepartmentEmployee department)
			{
				_context.DepartmentEmployees.Add(department);
				_context.SaveChanges();
				return Ok(department);
			}

			[HttpDelete("{id}")]
			public IActionResult DeleteDepartmentEmployee(int id)
			{
				var department = _context.DepartmentEmployees.Find(id);
				if (department == null)
				{
					return NotFound();
				}

				_context.DepartmentEmployees.Remove(department);
				_context.SaveChanges();
				return NoContent();
			}


			[HttpPost("createDepartmentEmployeeUsingProc")]
			public IActionResult CreateDepartmentEmployeeUsingProcedures(DepartmentEmployeeDTO department)
			{
				var returnList = _context.Database.ExecuteSqlInterpolated($"EXEC CreateDepartmentEmployee {department.Name}");


				if (returnList == 0)
				{
					return BadRequest();
				}
				_context.SaveChanges();
				return Ok();

			}

			[HttpGet]
			public IActionResult GetDepartmentEmployees()
			{
				var departments = _context.DepartmentEmployees;

				if (departments == null)
				{
					return NotFound();
				}
				return Ok(departments);

			}


			[HttpPut("{id}")]
			public IActionResult UpdateDepartmentEmployee(int id, DepartmentEmployeeDTO department)
			{
				var returnList = _context.Database.ExecuteSqlInterpolated($"EXEC UpdateDepartmentEmployee {department.Name}, {id}");


				if (returnList == 0)
				{
					return BadRequest();
				}
				_context.SaveChanges();
				return Ok();
			}
		}
	}
}

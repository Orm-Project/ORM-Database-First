using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORM_Database_First.Models;
using System.Linq;

namespace ORM_Database_First.Controllers
{


	[ApiController]
	[Route("api/[controller]")]
	public class DepartmentsController : ControllerBase
	{
		private readonly DBFirst_testContext _context;

		public DepartmentsController(DBFirst_testContext context)
		{
			_context = context;
		}

		[HttpPost]
		public IActionResult CreateDepartment(Department department)
		{
			_context.Departments.Add(department);
			_context.SaveChanges();
			return Ok(department);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteDepartment(int id)
		{
			var department = _context.Departments.Find(id);
			if (department == null)
			{
				return NotFound();
			}

			_context.Departments.Remove(department);
			_context.SaveChanges();
			return Ok();
		}


		[HttpPost("createDepartmentUsingProc")]
		public IActionResult CreateDepartmentUsingProcedures(DepartmentDTO department)
		{
			var returnList = _context.Database.ExecuteSqlInterpolated($"EXEC CreateDepartment {department.Name}");


			if (returnList == 0)
			{
				return BadRequest();
			}
			_context.SaveChanges();
			return Ok();
			
		}

		[HttpGet]
		public IActionResult GetDepartments()
		{
			var departments = _context.Departments;

			if (departments == null)
			{
				return NotFound();
			}
			return Ok(departments);

		}


		[HttpPut("{id}")] 
		public IActionResult UpdateDepartment(int id, DepartmentDTO department)
		{
			var returnList = _context.Database.ExecuteSqlInterpolated($"EXEC UpdateDepartment {department.Name}, {id}");


			if (returnList == 0)
			{
				return BadRequest();
			}
			_context.SaveChanges();
			return Ok();
		}
	}
}


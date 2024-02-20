using Microsoft.AspNetCore.Mvc;
using ORM_Database_First.Models;

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
		public IActionResult CreateDepartment( Department department)
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
			return NoContent();
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORM_Database_First.Models;

namespace ORM_Database_First.Controllers
{
	public class ManagerController : Controller
	{
		[ApiController]
		[Route("api/[controller]")]
		public class ManagersController : ControllerBase
		{
			private readonly DBFirst_testContext _context;

			public ManagersController(DBFirst_testContext context)
			{
				_context = context;
			}

			[HttpPost]
			public IActionResult CreateManager(Manager Manager)
			{
				_context.Managers.Add(Manager);
				_context.SaveChanges();
				return Ok(Manager);
			}

			[HttpDelete("{id}")]
			public IActionResult DeleteManager(int id)
			{
				var Manager = _context.Managers.Find(id);
				if (Manager == null)
				{
					return NotFound();
				}

				_context.Managers.Remove(Manager);
				_context.SaveChanges();
				return NoContent();
			}


			[HttpPost("createManagerUsingProc")]
			public IActionResult CreateManagerUsingProcedures(ManagerDTO Manager)
			{
				var returnList = _context.Database.ExecuteSqlInterpolated($"EXEC CreateManager {Manager.Name}");


				if (returnList == 0)
				{
					return BadRequest();
				}
				_context.SaveChanges();
				return Ok();

			}

			[HttpGet]
			public IActionResult GetManagers()
			{
				var Managers = _context.Managers;

				if (Managers == null)
				{
					return NotFound();
				}
				return Ok(Managers);

			}


			[HttpPut("{id}")]
			public IActionResult UpdateManager(int id, ManagerDTO Manager)
			{
				var returnList = _context.Database.ExecuteSqlInterpolated($"EXEC UpdateManager {Manager.Name}, {id}");


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

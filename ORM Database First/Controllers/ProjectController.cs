using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORM_Database_First.Models;

namespace ORM_Database_First.Controllers
{
	public class ProjectController : Controller
	{
		[ApiController]
		[Route("api/[controller]")]
		public class ProjectsController : ControllerBase
		{
			private readonly DBFirst_testContext _context;

			public ProjectsController(DBFirst_testContext context)
			{
				_context = context;
			}

			[HttpPost]
			public IActionResult CreateProject(Project Project)
			{
				_context.Projects.Add(Project);
				_context.SaveChanges();
				return Ok(Project);
			}

			[HttpDelete("{id}")]
			public IActionResult DeleteProject(int id)
			{
				var Project = _context.Projects.Find(id);
				if (Project == null)
				{
					return NotFound();
				}

				_context.Projects.Remove(Project);
				_context.SaveChanges();
				return NoContent();
			}


			[HttpPost("createProjectUsingProc")]
			public IActionResult CreateProjectUsingProcedures(ProjectDTO Project)
			{
				var returnList = _context.Database.ExecuteSqlInterpolated($"EXEC CreateProject {Project.Name}");


				if (returnList == 0)
				{
					return BadRequest();
				}
				_context.SaveChanges();
				return Ok();

			}

			[HttpGet]
			public IActionResult GetProjects()
			{
				var Projects = _context.Projects;

				if (Projects == null)
				{
					return NotFound();
				}
				return Ok(Projects);

			}


			[HttpPut("{id}")]
			public IActionResult UpdateProject(int id, ProjectDTO Project)
			{
				var returnList = _context.Database.ExecuteSqlInterpolated($"EXEC UpdateProject {Project.Name}, {id}");


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

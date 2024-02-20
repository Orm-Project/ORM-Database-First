using Microsoft.AspNetCore.Mvc;

namespace ORM_Database_First.Models
{
	public class ProjectDTO : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

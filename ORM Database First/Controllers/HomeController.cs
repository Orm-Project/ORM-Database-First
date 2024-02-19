using Microsoft.AspNetCore.Mvc;

namespace ORM_Database_First.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

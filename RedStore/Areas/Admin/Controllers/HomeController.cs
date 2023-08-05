using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RedStore.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "Admin,DataEntry")]
    public class HomeController : Controller
	{
		public IActionResult AdminPage()
		{
			return View();
		}

		public IActionResult List()
		{
			return View();
		}
		public IActionResult Edit()
		{
			return View();
		}
	}
}

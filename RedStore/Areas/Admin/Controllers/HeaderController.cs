using Bl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedStore.Models;
using RedStore.Utlities;
using System.Data;

namespace RedStore.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "Admin,DataEntry")]
    public class HeaderController : Controller
	{
		IHeader oClsHeader;
        public HeaderController(IHeader ctx)
        {
			oClsHeader = ctx;
		}
        public IActionResult List()
		{
			return View(oClsHeader.GetAll());
		}
		public IActionResult Edit(int? HeaderId)
		{
			var Header=new TbHeader();
			if (HeaderId != null)
			{
				Header = oClsHeader.GetById(Convert.ToInt32(HeaderId));
			}
			return View(Header);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Save(TbHeader Header, List<IFormFile> files)
	{
			
			if (!ModelState.IsValid)
				return View("Edit", Header);
			Header.ImageName = await Helper.UploadImage(files, "Header");
			oClsHeader.Save(Header);
			return RedirectToAction("List");
		}

		public IActionResult Delete(int? HeaderId)
		{
			oClsHeader.Delete(Convert.ToInt32(HeaderId));
			return RedirectToAction("List");
		}





	}
}

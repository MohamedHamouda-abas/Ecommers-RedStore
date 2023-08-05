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
    public class FeaturedController : Controller
	{
		IFeatured OclsFeatured;
        public FeaturedController(IFeatured ctx)
        {
			OclsFeatured = ctx;

		}
        public IActionResult List()
		{
			return View(OclsFeatured.GetAll());
		}
		public IActionResult Edit(int? FeaturedId)
		{
			var Featured=new TbFeatured();
			if (FeaturedId!=null)
			{
				Featured = OclsFeatured.GetById(Convert.ToInt32(FeaturedId));

			}
			return View(Featured);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Save(TbFeatured Featured, List<IFormFile> files)
		{

			if (!ModelState.IsValid)
				return View("Edit", Featured);
			Featured.ImageName = await Helper.UploadImage(files, "MainProducts");
			OclsFeatured.Save(Featured);
			return RedirectToAction("List");
		}

		public IActionResult Delete(int? FeaturedId)
		{OclsFeatured.Delete(Convert.ToInt32(FeaturedId));
			return RedirectToAction("List");
		}




	}
}

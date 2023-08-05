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
    public class MainProductsController : Controller
	{
		IProducts OclsProducts;
        public MainProductsController(IProducts ctx)
        {
			OclsProducts = ctx;
		}

        public IActionResult List()
		{
			return View(OclsProducts.GetAll());
		}
		//this line mean the admin who the onl person can see that action
      
        public IActionResult Edit(int? MainId)
		{
			var products = new TbMainProduct();
			if (MainId != null)
			{
				products=OclsProducts.GetById(Convert.ToInt32(MainId));
			}
			return View(products);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Save(TbMainProduct MainProducts, List<IFormFile> files)
		{
			
			if (!ModelState.IsValid)
			return View("Edit", MainProducts);
			MainProducts.ImageName = await Helper.UploadImage(files, "MainProducts");
			OclsProducts.Save(MainProducts);
			return RedirectToAction("List");
		}
		[Authorize(Roles = "Admin")]
		public IActionResult Delete(int? MainId)
		{
			OclsProducts.Delete(Convert.ToInt32(MainId));
			return RedirectToAction("List");
		}


	}
}

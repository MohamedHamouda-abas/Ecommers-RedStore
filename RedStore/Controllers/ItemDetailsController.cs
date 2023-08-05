using Bl;
using Domains;
using Microsoft.AspNetCore.Mvc;
using RedStore.Models;

namespace RedStore.Controllers
{
	public class ItemDetailsController : Controller
	{
		IFeatured OclsFeatured;
		IProducts OclsProducts;
        public ItemDetailsController(IFeatured featured,IProducts products)
        {
			OclsFeatured = featured;
			OclsProducts= products;
		}
		
		public IActionResult ItemDetails(int? ItemId)
		{
			VwDetailes vmPage = new VwDetailes();
			vmPage.Featured=OclsFeatured.GetById(ItemId);
            vmPage.lstFeatured = OclsFeatured.GetAll();
            return View(vmPage);
		}

		public IActionResult ProductsDetails(int? ProductsId)
		{
			VwDetailes vmPage = new VwDetailes();
			vmPage.Products = OclsProducts.GetById(Convert.ToInt32(ProductsId));
            vmPage.MainProduct= OclsProducts.GetAll().Take(4).ToList();
            return View(vmPage);
		}

	}
}

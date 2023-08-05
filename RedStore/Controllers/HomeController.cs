using Bl;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RedStore.Controllers
{
	public class HomeController : Controller
	{
		IHeader OclsHeader;
		Ioffers OclsOffers;
		IFeatured oCLSFeatured;
		IProducts OclsProducts;
		Itesmoniles OclsTechsmoniles;
        public HomeController(IHeader Header,Ioffers offers,IFeatured featured,IProducts products, Itesmoniles dad)
        {
			OclsHeader= Header;
			OclsOffers = offers;
			oCLSFeatured=featured;
			OclsProducts=products;
			OclsTechsmoniles= dad;

		}
        public IActionResult HomePage()
		{
			VmHomePage vmHomePage = new VmHomePage();
			vmHomePage.LstHeader = OclsHeader.GetAll().ToList();
			vmHomePage.LstoOffers = OclsOffers.GetAll().Take(3).ToList();
			vmHomePage.LstFeatured = oCLSFeatured.GetAll().Take(4).ToList();
			vmHomePage.LstMainProduct = OclsProducts.GetAll().Take(8).ToList();
			vmHomePage.Lsttestimonial = OclsTechsmoniles.GetAll().Take(3).ToList();
			return View(vmHomePage);
		}
		[Authorize]
        public IActionResult CheckOut()
        {
			return View();
           
        }
    }
}

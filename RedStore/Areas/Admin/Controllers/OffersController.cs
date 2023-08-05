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
    public class OffersController : Controller
	{
		Ioffers OclsOffers;
		public OffersController(Ioffers Ctx)
		{
			OclsOffers = Ctx;

		}
		public IActionResult List()
		{
			return View(OclsOffers.GetAll());
		}
		public IActionResult Edit(int? OffersId)
		{
			var Offers = new TbOffer();
			if (OffersId != null)
			{
				Offers = OclsOffers.GetById(Convert.ToInt32(OffersId));
			}
			return View(Offers);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Save(TbOffer Offers, List<IFormFile> files)
		{

			if (!ModelState.IsValid)
				return View("Edit", Offers);
			Offers.ImageName = await Helper.UploadImage(files, "Offer");
			OclsOffers.Save(Offers);
			return RedirectToAction("List");
		}


		public IActionResult Delete(int? OffersId)
		{
			OclsOffers.Delete(Convert.ToInt32(OffersId));
			return RedirectToAction("List");
		}

	}
}

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
    public class TestimonialsController : Controller
	{
		Itesmoniles Oclstesmoniles;
        public TestimonialsController(Itesmoniles ctx)
        {
			Oclstesmoniles=ctx;

		}

        public IActionResult List()
		{
			return View(Oclstesmoniles.GetAll());
		}


		public IActionResult Edit(int? TestimonialsId)
		{
			var Offers = new Tbtestimonial();
			if (TestimonialsId != null)
			{
				Offers = Oclstesmoniles.GetById(Convert.ToInt32(TestimonialsId));
			}
			return View(Offers);
		
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Save(Tbtestimonial Offers, List<IFormFile> files)
		{

			if (!ModelState.IsValid)
				return View("Edit", Offers);
			Offers.ImageName = await Helper.UploadImage(files, "testimonial");
			Oclstesmoniles.Save(Offers);
			return RedirectToAction("List");
		}
	}
}

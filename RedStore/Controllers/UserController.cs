using Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RedStore.Controllers
{
	public class UserController : Controller
	{
		UserManager<IdentityUser> _Usermanager;	
		SignInManager<IdentityUser> _signInManager;
        public UserController(UserManager<IdentityUser> Usermanager, SignInManager<IdentityUser> signInManager	)
        {
			_Usermanager=Usermanager;
			_signInManager=signInManager;

		}
        public IActionResult Login(string ReturnUrl)
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(UserModel model, string ReturnUrl)
		{
			IdentityUser User = new IdentityUser()
			{
				Email = model.Email,				
			};
			var OutoLogin = await _signInManager.PasswordSignInAsync(User.Email, model.Password, true, true);
			if (OutoLogin.Succeeded)
			{
				if (string.IsNullOrEmpty(ReturnUrl))
					return Redirect("~/");
				else
					return Redirect(ReturnUrl);
			}
			return View();
		}


		public IActionResult Register()
		{
			return View(new UserModel());
		}
		[HttpPost]
		public async Task<IActionResult> Register(UserModel model)
		{
			IdentityUser user = new IdentityUser()
			{
				Email=model.Email,
				UserName=model.Email,
			};	
			var Result=await _Usermanager.CreateAsync(user,model.Password);
			if (Result.Succeeded)
			{
				var outoLogin=await _signInManager.PasswordSignInAsync(user,model.Password,true, true);

				if (outoLogin.Succeeded)
				{
					return Redirect("~/");
				}
			}
			else
			{
				return Redirect("/User/Register");
			}
			return View(new UserModel());
		}

		public IActionResult AccessDenied()
		{
			return View();
		}

		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return Redirect("~/");
		}



	}
}

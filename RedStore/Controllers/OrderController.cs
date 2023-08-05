using Bl;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RedStore.Models;
namespace RedStore.Controllers
{
    public class OrderController : Controller
    {
        IFeatured FeaturedService;
        IProducts ProductsService;
        public OrderController(IFeatured featured, IProducts products )
        {
            FeaturedService = featured;
            ProductsService = products;    
        }
        public IActionResult Cart()
        {
            string SessionCart = string.Empty;
            if (HttpContext.Request.Cookies["Cart"] != null)
                SessionCart = HttpContext.Request.Cookies["Cart"];
            var Cart = JsonConvert.DeserializeObject<ShoppingCart>(SessionCart);
            return View(Cart);
        }
        public IActionResult AddToCart(int? FeaturedId)
        {
            ShoppingCart cart;

            if (HttpContext.Request.Cookies["Cart"] != null)
                cart = JsonConvert.DeserializeObject<ShoppingCart>(HttpContext.Request.Cookies["Cart"]);
            else
                cart = new ShoppingCart();

            var item = FeaturedService.GetById(FeaturedId);

            var itemInList = cart.listItems.Where(a => a.FeaturedId == FeaturedId).FirstOrDefault();

            if (itemInList != null)
            {
                itemInList.Qty++;
                itemInList.Subtotal = itemInList.Qty * itemInList.Price;
            }
            else
            {
                 item = FeaturedService.GetById(FeaturedId);

                cart.listItems.Add(new ShoppingCartItem
                {
                    FeaturedId = item.FeaturedId,
                    ItemName = item.ProductName,
                    Price = item.SalesPrice,
                    ImageName= item.ImageName,  
                    Tax= item.Tax,
                    Qty =1,
                    Subtotal = item.SalesPrice
                });;
            }
            cart.AllTax = cart.listItems.Sum(a => a.Tax);
            cart.AllSubTotal = cart.listItems.Sum(a => a.Subtotal);
            cart.Total = cart.listItems.Sum(a => a.Subtotal + item.Tax);

            HttpContext.Response.Cookies.Append("Cart", JsonConvert.SerializeObject(cart));

            return RedirectToAction("Cart");
        }
        public IActionResult AddCart(int? MainId)
        {
            ShoppingCart cart;

            if (HttpContext.Request.Cookies["Cart"] != null)
                cart = JsonConvert.DeserializeObject<ShoppingCart>(HttpContext.Request.Cookies["Cart"]);
            else
                cart = new ShoppingCart();

            var item = ProductsService.GetById(MainId);

            var itemInList = cart.listItems.Where(a => a.MainId == MainId).FirstOrDefault();

            if (itemInList != null)
            {
                itemInList.Qty++;
                itemInList.Subtotal = itemInList.Qty * itemInList.Price;
            }
            else
            {
                item = ProductsService.GetById(MainId);

                cart.listItems.Add(new ShoppingCartItem
                {
                    MainId = item.MainId,
                    ItemName = item.ProductName,
                    Price = item.SalesPrice,
                    ImageName = item.ImageName,
                    Tax = item.Tax,
                    Qty = 1,
                    Subtotal = item.SalesPrice
                }); 
            }
            cart.AllTax = cart.listItems.Sum(a => a.Tax);
            cart.AllSubTotal = cart.listItems.Sum(a => a.Subtotal);
            cart.Total = cart.listItems.Sum(a => a.Subtotal + item.Tax);

            HttpContext.Response.Cookies.Append("Cart", JsonConvert.SerializeObject(cart));

            return RedirectToAction("Cart");
        }
		[Authorize]
		public IActionResult SaveOrder()
        {
            return View();
        }
    }
}

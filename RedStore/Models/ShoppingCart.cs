namespace RedStore.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            listItems=new List<ShoppingCartItem>();
            Featured = new TbFeatured();
            Products = new TbMainProduct();
        }
        public List<ShoppingCartItem> listItems { get; set; }    
        public decimal? Total { get; set; }
		public decimal? AllSubTotal { get; set; }
        public decimal? AllTax { get; set; }
        public TbFeatured Featured { get; set; }
        public TbMainProduct Products { get; set; }
    }
}

namespace RedStore.Models
{
    public class ShoppingCartItem
    {
        public int FeaturedId { get; set; }
        public int MainId { get; set; }
        public string? ItemName { get; set; } 
        public decimal? Price { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Tax { get; set; }
        public int Qty { get; set; }
        public string? ImageName { get; set; }
    }
}

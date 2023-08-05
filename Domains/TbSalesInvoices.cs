namespace Domains
{
    public class TbSalesInvoices
    {
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DelivryDate { get; set; }
        public Guid CustomerId { get; set; }
        public int CurrentState { get; set; }
        public string? ProductName { get; set; }
        public string? Prand { get; set; }
        public string? ImageName { get; set; }
        public decimal? SalesPrice { get; set; }
        public decimal? Total { get; set; }
    }
}

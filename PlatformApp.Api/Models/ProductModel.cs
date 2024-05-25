namespace PlatformApp.Api.Models
{
    public class ProductModel
    {
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? ProductPrice { get; set; }
        public int? CustomerId { get; set; }
    }
}

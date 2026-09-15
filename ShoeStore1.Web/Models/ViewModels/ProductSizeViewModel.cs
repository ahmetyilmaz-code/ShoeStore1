namespace ShoeStore1.Web.Models.ViewModels
{
    public class ProductSizeViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public List<ProductSizeStockViewModel> Sizes { get; set; }
    }

    public class ProductSizeStockViewModel
    {
        public string Size { get; set; }
        public int Stock { get; set; }
    }
}
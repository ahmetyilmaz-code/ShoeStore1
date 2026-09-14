namespace ShoeStore1.Web.Models.ApiModel
{
    public class ProductApiModel
    {
        public List<int> categories { get; set; }
        public decimal? minPrice { get; set; }
        public decimal? maxPrice { get; set; }
    }
}

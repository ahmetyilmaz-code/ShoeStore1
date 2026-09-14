namespace ShoeStore1.Web.Models.ViewModels
{
    
    public class ProductDisplayModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
        public string ImageUrl { get; set; }
        public List<int> Sizes { get; set; }
    }
    public class HomeViewModel
    {
        public List<ProductDisplayModel> FeatureProducts { get; set; }
        public List<ProductDisplayModel> LatestProducts { get; set; }
        public List<CategoryViewModel> Categories { get; set; }


    }
}

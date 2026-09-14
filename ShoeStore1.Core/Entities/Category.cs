namespace ShoeStore1.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
        //bir kategorinin(category) birden fazla ürünü(product) olabilir.

    }
}

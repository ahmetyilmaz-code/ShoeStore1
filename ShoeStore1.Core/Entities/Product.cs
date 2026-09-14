namespace ShoeStore1.Core.Entities
{
    public class Product : BaseEntity 
    //internal class Product olsaydı sadece ShoeStore1.Core da erişilebilirdi.
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public bool Featured { get; set; } = false;
        public Category Category { get; set; }

        // bu kategorinin bilgilerinin dolabilmesi için, ilgili ürünün kategorisinin adının
        // kategorisinin açıklamasını çekmek istenildiğinde o veriye ulaşabilmek için
        
        // Burada Entity Framework Core, Product'in Id'li kategoriye ait. Bu Id'li kategorinin verilerinide Category'nin içine koyacak 

        public ICollection<ProductSize> ProductSizes { get; set; }




    }
}

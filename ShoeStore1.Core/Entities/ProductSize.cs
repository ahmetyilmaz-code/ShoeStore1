namespace ShoeStore1.Core.Entities
{
    public class ProductSize : BaseEntity
    {
        // tabloya Id koymazsak yani Id'si olmazssa yani Primary Key'i olmazssa
        // Entity Framework o tabloyu yapmaz.

        public int ProductId { get; set; }
        public Product Product { get; set; }
        //bu ProductId ait olan Product'ı(ürünü) de çekebilmek için Product nesnesi tanımladık.
        public string Size { get; set; }
        public int Stock { get; set; }



    }
}

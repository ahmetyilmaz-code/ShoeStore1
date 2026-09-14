namespace ShoeStore1.Core.Entities
{
    public class OrderItem : BaseEntity
    // sipariş ve sipariş içindeki ürünleri ayırarak,
    // kullanıcının bir sipariş kaç ürün alacağını bilemediğimiz için bunu yönetebilelim
    // bunun için OrderItem diye bir tablo, sınıf oluşturuldu.
    {
        public int OrderId { get; set; } //hangi fişe ait
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string ProductName { get; set; }
        public string ProductSize { get; set; }
        public decimal ProductUnitPrice { get; set; } //fiş olarak kaydedilen tutar
        public int Quantity { get; set; }


    }
}

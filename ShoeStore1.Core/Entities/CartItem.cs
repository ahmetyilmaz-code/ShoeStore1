namespace ShoeStore1.Core.Entities
{
    public class CartItem : BaseEntity
    // sepet ve sepet içindeki ürünleri ayırarak,
    // kullanıcının kaç tane ürün ekleyeciğini bilemediğimiz için bunu yönetebilelim
    // bunun için CartItem diye bir tablo, sınıf oluşturuldu.
    {
        public int CartId { get; set; } //hangi Cart'a ait
        public Cart Cart { get; set; }       
        public int ProductId { get; set; }//Item hangi ürüne ait
        public Product Product { get; set; }
        public int ProductSizeId { get; set; } //eklenen ürünün size'ı kaç
        public ProductSize ProductSize { get; set; }
        public int Quantity { get; set; }// üründen kaç adet

    }
}

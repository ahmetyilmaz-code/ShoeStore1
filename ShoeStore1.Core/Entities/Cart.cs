namespace ShoeStore1.Core.Entities
{
    public class Cart : BaseEntity
        //sepeti takip edebilmek için Cart isimli sınıf
    {
        // Microsoftun mevcut olan Identity kütüphanesi kullanarak kullanıcı girişi yapılacak.
        // bu kütüphanede app vs olacak
        public string AppUserId { get; set; }

        // sepet ve sepet içindeki ürünleri ayırarak,
        // kullanıcının kaç tane ürün ekleyeciğini bilemediğimiz için bunu yönetebilelim
        // bunun için CartItem diye bir tablo, sınıf oluşturuldu.

        public ICollection<CartItem> CartItems { get; set; }

    }
}

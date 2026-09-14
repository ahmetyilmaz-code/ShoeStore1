using ShoeStore1.Core.Enums;

namespace ShoeStore1.Core.Entities
{
    public class Order : BaseEntity
    //sipariş satış bilgisini tutmak için
    {
        //Yapılabilecekler
        //1-)fiş bilgilerini göster gibi bir ekran yapılırsa ön hazırlık için buradan veriler okunabilir.   
        //2-) ilerlemek icap ederse Supplier, Kargo Şirketleri koymak gerekebilir.

        
        public string OrderNumber { get; set; } // her siparişe özel fiş numarası
        public string AppUserId { get; set; } //hangi kullanıcıya ait       
        public string AppUserPhoneNumber { get; set; }
        public string AppUserFirstName { get; set; }
        public string AppUserLastName { get; set; }
        public string FullAddress { get; set; } //order'in gittiği adres
        public string City { get; set; }
        public string Country { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Received; //sipariş ilk sipariş edilince durumu otomatik alındıya çekildi
        //2-) databaseye atılırken sipariş alındı olarak atıldı. ondan sonra güncellemeler ordan yapılırsa yapılır.
        //ilerlemek icap ederse Supplier, Kargo Şirketleri koymak gerekebilir.
    }
}
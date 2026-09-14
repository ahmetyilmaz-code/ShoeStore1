namespace ShoeStore1.Core.Entities
{
    public class Address : BaseEntity
    {
        // iki adres lazım,
        // birincisi kullanıcının adreslerinin listeleneciği yer (class Address)
        // ikinciside o ürünün gideceği adresin olduğu yer
        // çünkü kullanıcı adresinde değişiklik yapabilir
        // mesela ev adresi diye kaydettiğim adresimi sonradan değiştirebilirim.
        // Ama benim ordera(fişe)a kaydettiğim adresin, eğerki o teslim edilmişşe ve
        // değiştirilmemişşe değişmiyor olması lazım (class OrderAddress)
        public string AppUserId { get; set; } //hangi kullanıcıya ait
        public string Name { get; set; } //bu adres ne Ev,İş?
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string FullAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}

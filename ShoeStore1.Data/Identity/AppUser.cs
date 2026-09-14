using Microsoft.AspNetCore.Identity;

namespace ShoeStore1.Data.Identity
{
    public class AppUser : IdentityUser<int>
        //Identity kütüphanesini için AppUser var zaten, ama bu kütüphanedi User'a biz birşey
        //daha eklemek istersek AppUser'a ihtiyaç var, (firstname lastname vs.)
        //Id normalde string generic int yapıldı
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

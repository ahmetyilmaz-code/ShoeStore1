using Microsoft.AspNetCore.Identity;

namespace ShoeStore1.Data.Identity
{
    public class AppRole : IdentityRole<int>
    //Identity kütüphanesini için AppRole var zaten, ama bu kütüphanede Role'a biz birşey
    //daha eklemek istersek AppRole'a ihtiyaç var, (adminlevel1 adminlevel2 vs.)
    //Role normalde string generic int yapıldı

        //Yapılabilecekler
        //yeni roller eklenebilir.
    {

    }
}

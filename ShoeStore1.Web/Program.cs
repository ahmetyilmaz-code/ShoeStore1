using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShoeStore1.Core.Repositories;
using ShoeStore1.Data.Repositories;
using ShoeStore1.Data;
using ShoeStore1.Data.Identity;
using ShoeStore1.Web.Data;
/*
 * EKLENECEKLER : DETAY SAYFASI İÇİN GEREKENLER
 * 1-) ÜRÜNE TIKLANINCA DETAY SAYFASINA GİDİLECEK, DETAY SAYFASINDA ÜRÜNÜN BİLGİLERİ GÖSTERİLECEK,
 * 2-) DETAY SAYFASINDA ÜRÜNÜN KATEGORİSİNE GÖRE BENZER ÜRÜNLER GÖSTERİLECEK,
 * 3-) DETAY SAYFASINDA ÜRÜNÜN BÜYÜK RESMİ GÖSTERİLECEK, KÜÇÜK RESİMLERİN ÜZERİNE GELİNCE BÜYÜK RESMİN DEĞİŞMESİ SAĞLANACAK,
 * 4-) DETAY SAYFASINDA ÜRÜNÜN FİYATI, AÇIKLAMASI, BÜYÜK RESMİ, KATEGORİSİ GÖSTERİLECEK,
 * 5-) DETAY SAYFASINDA ÜRÜNÜN BÜYÜK RESMİNİN ALTINDA KÜÇÜK RESİMLER GÖSTERİLECEK, KÜÇÜK RESİMLERİN ÜZERİNE GELİNCE BÜYÜK RESMİN DEĞİŞMESİ SAĞLANACAK,
 * 
 * EKLENECEKLER : YÖNETİM PANELİ İÇİN GEREKENLER
 * 1-) YÖNETİM PANELİNE GİRİŞ YAPILABİLMESİ İÇİN KULLANICI GİRİŞ SAYFASI OLUŞTURULACAK,
 * 2-) YÖNETİM PANELİNE GİRİŞ YAPILDIKTAN SONRA KULLANICI ROLÜNE GÖRE YÖNETİM PANELİNDEKİ MENÜLERİN GÖSTERİLMESİ SAĞLANACAK,
 * 3-) YÖNETİM PANELİNDE ÜRÜN EKLEME, SİLME, GÜNCELLEME İŞLEMLERİ YAPILABİLECEK,
 * 4-) YÖNETİM PANELİNDE KATEGORİ EKLEME, SİLME, GÜNCELLEME İŞLEMLERİ YAPILABİLECEK,
 * 5-) YÖNETİM PANELİNDE KULLANICI EKLEME, SİLME, GÜNCELLEME İŞLEMLERİ YAPILABİLECEK,
 * 6-) YÖNETİM PANELİNDE ROL EKLEME, SİLME, GÜNCELLEME İŞLEMLERİ YAPILABİLECEK,
 * 7-) YÖNETİM PANELİNDE SİPARİŞLERİN GÖRÜNTÜLENMESİ, SİLİNMESİ, GÜNCELLENMESİ SAĞLANACAK,
 * 8-) YÖNETİM PANELİNDE ÜRÜN DETAYLARININ GÖRÜNTÜLENMESİ SAĞLANACAK,
 * 9-) YÖNETİM PANELİNDE KATEGORİ DETAYLARININ GÖRÜNTÜLENMESİ SAĞLANACAK,
 * 10-) YÖNETİM PANELİNDE KULLANICI DETAYLARININ GÖRÜNTÜLENMESİ SAĞLANACAK,
 * 11-) YÖNETİM PANELİNDE ROL DETAYLARININ GÖRÜNTÜLENMESİ SAĞLANACAK,
 * 12-) YÖNETİM PANELİNDE SİPARİŞ DETAYLARININ GÖRÜNTÜLENMESİ SAĞLANACAK,
 * 13-) YÖNETİM PANELİNDE ÜRÜN RESİMLERİNİN GÖRÜNTÜLENMESİ, EKLENMESİ, SİLİNMESİ SAĞLANACAK,
 * 
 * EKLENECEKLER : ÜRÜN SEÇİLİRKEN ÜRÜNÜN AYAKKABI NUMARASI İLE SEPETE EKLEMELİ !!
 * EKLENECEKLER : ÜRÜNÜN SEÇİLİRKEN NUMARASI EKLENMİYOR !!
 * * 
 * EKLENECEKLER : ÜRÜN SEÇİLİRKEN ÜRÜNÜN AYAKKABI NUMARASI DATABASEDEN GELMELİ !!
 * EKLENECEKLER : ÜRÜN SEPETİNDE ÜRÜNLER SİLİNEMİYOR !!
 * EKLENECEKLER : KULLANICININ DAHA ÖNCEKİ SİPARİŞLERİ GÖRÜNMÜYOR
 * 
 * 
 * 
 */
/*    WebApplication.CreateBuilder(args) uygulamanın ayarlarını ve servislerini hazırlar, 
    builder.Build() bu ayarlarla çalışabilir bir WebApplication oluşturur ve 
    app.Run() oluşturulan uygulamayı başlatarak gelen HTTP isteklerini dinlemeye ve cevap vermeye başlar.   */


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
//Uygulamanın ayarlarını ve gerekli servislerini hazırlayan builder nesnesini oluşturur.
/* WebApplicationBuilder, uygulamanın yapılandırmasını ve servislerini yönetmek için kullanılan bir sınıftır.
 Bu sınıf, uygulamanın başlatılması sırasında gerekli olan ayarları ve bağımlılıkları yapılandırmak için kullanılır.
 WebApplication.CreateBuilder(args) metodu, uygulamanın yapılandırmasını başlatır ve
 gerekli servisleri ekler. args parametresi, komut satırı argümanlarını temsil eder ve uygulamanın başlatılması sırasında kullanılabilir. */
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    /*     builder.Services.AddDbContext<AddDbContext>() metodu, uygulamanın Entity Framework Core kullanarak bir veritabanına bağlanmasını sağlar. 
    Bu metod, AddDbContext sınıfını kullanarak veritabanı bağlantısını yapılandırır ve gerekli servisleri ekler. 
    options.UseSqlServer() metodu, SQL Server veritabanını kullanmak için gerekli ayarları yapar ve bağlantı dizesini alır. 
    builder.Configuration.GetConnectionString("DefaultConnection") ifadesi,
    appsettings.json dosyasındaki "DefaultConnection" adlı bağlantı dizesini alır ve veritabanı bağlantısı için kullanır.      */
});

builder.Services.AddIdentity<AppUser, AppRole>(options =>
{/* builder.Services.AddIdentity<AppUser, AppRole>() metodu,
  uygulamanın kimlik doğrulama ve yetkilendirme işlemlerini yönetmek için gerekli servisleri ekler. 
  Bu metod, AppUser ve AppRole sınıflarını kullanarak kullanıcı ve rol yönetimini sağlar. 
  options parametresi, kimlik doğrulama ve yetkilendirme ayarlarını yapılandırmak için kullanılır.    */

    options.Password.RequiredLength = 6; // Şifre uzunluğu en az 6 karakter olmalıdır.
    options.Password.RequireNonAlphanumeric = false; // Şifre en az bir özel karakter içermelidir.
    options.Password.RequireDigit = false; // Şifre en az bir rakam içermelidir.
    options.Password.RequireUppercase = false; // Şifre en az bir büyük harf içermelidir.
    options.Password.RequireLowercase = false; // Şifre en az bir küçük harf içermelidir.
    options.User.RequireUniqueEmail = true; // Kullanıcıların benzersiz bir e-posta adresine sahip olması gerekmektedir.
})
.AddEntityFrameworkStores<AppDbContext>() // .AddEntityFrameworkStores<AppDbContext>() metodu, kimlik doğrulama ve yetkilendirme işlemleri için gerekli olan kullanıcı ve rol verilerini Entity Framework Core kullanarak AppDbContext üzerinden yönetir.
.AddDefaultTokenProviders(); // .AddDefaultTokenProviders() metodu, kimlik doğrulama ve yetkilendirme işlemleri için gerekli olan token sağlayıcılarını ekler.

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//Core katmanından IGenericRepository isteyene Data katmanından GenericRepository paylaş
builder.Services.AddScoped<IUnitOfWork,UnitofWork>();
builder.Services.AddScoped<ShoeStore1.Web.Models.Services.ProductService>();
builder.Services.AddScoped<ShoeStore1.Web.Models.Services.ProductSizeService>();
builder.Services.AddControllersWithViews(); // Controller'ları ve Views'ları oluştur.
//builder.Services.AddControllersWithViews(); ASP.NET Core'a MVC yapısını kullanacağını bildirerek
//Controller'ları,Action'ları ve View'ları sisteme ekler ve uygulamanın Controller üzerinden gelen istekleri işleyip
//ilgili .cshtml View dosyalarını kullanıcıya gösterebilmesini sağlar.



WebApplication app = builder.Build();
//Builder'daki ayarları kullanarak çalışmaya hazır WebApplication nesnesini oluşturur.
/* builder.Build() metodu, yapılandırılmış ayarları ve servisleri kullanarak çalışabilir bir WebApplication nesnesi oluşturur.
 Bu nesne, uygulamanın HTTP isteklerini dinlemesini ve yanıtlamasını sağlar.
 app.Run() metodu, uygulamayı başlatır ve gelen HTTP isteklerini dinlemeye başlar.
 Bu metod çağrıldığında, uygulama belirtilen portta çalışmaya başlar ve kullanıcıların isteklerine yanıt vermeye hazır hale gelir. */

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();

    await DbIntializer.SeedData(userManager, roleManager);
    /*
     using (var scope = app.Services.CreateScope()) { ... } uygulama başlatılırken geçici bir Dependency Injection (DI) scope'u oluşturur, 
    scope.ServiceProvider üzerinden kayıtlı UserManager<AppUser> ve RoleManager<AppRole> servislerini GetRequiredService<T>() ile alır ve 
    ardından DbIntializer.SeedData(userManager, roleManager) metoduna göndererek başlangıç verilerinin 
    (örneğin Admin rolü ve Admin kullanıcısının) veritabanında yoksa otomatik olarak oluşturulmasını sağlar; 
    using bloğu sona erdiğinde ise oluşturulan scope ve ona bağlı kaynaklar otomatik olarak temizlenir.
     */
}
app.UseStaticFiles(); //CSS, JavaScript, resim gibi statik dosyaların tarayıcıya sunulmasını //wwwroot klasöründeki dosyaların tarayıcıya sunulmasını sağlar.
app.UseRouting();
/* app.UseRouting() metodu, uygulamanın gelen HTTP isteklerini yönlendirmesini sağlar.
 Bu metod, URL'leri analiz eder ve uygun controller action'ına yönlendirir.
 Yani, kullanıcı bir URL'ye istek gönderdiğinde,
bu metod sayesinde hangi controller ve action'ın çalıştırılacağı belirlenir.    */
app.UseAuthentication(); //giriş yapan kullanıcının kimliğinin doğrulanmasını
app.UseAuthorization(); //doğrulanmış kullanıcının hangi sayfa veya işlemlere erişebileceğinin kontrol edilmesini sağlar.


app.MapControllerRoute(
    name:"default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );
/* app.MapControllerRoute() metodu, uygulamanın URL yönlendirme kurallarını tanımlar.
 Bu örnekte, varsayılan olarak "Home" controller'ı ve "Index" action'ı kullanılacak şekilde bir yönlendirme kuralı oluşturulmuştur.
 Yani, kullanıcı herhangi bir controller veya action belirtmezse, otomatik olarak HomeController'ın Index action'ı çalıştırılacaktır.
 pattern parametresi, URL yapısını belirler. "{controller=Home}/{action=Index}" ifadesi, URL'nin controller ve action adlarını içereceğini belirtir.
 Eğer kullanıcı bu bilgileri sağlamazsa, varsayılan olarak HomeController ve Index action'ı kullanılacaktır.    */

app.Run();
//Web uygulamasını başlatır ve gelen HTTP isteklerini dinlemeye başlar.
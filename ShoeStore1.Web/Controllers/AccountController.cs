using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoeStore1.Data.Identity;
using ShoeStore1.Web.Models.ViewModels;

namespace ShoeStore1.Web.Controllers
{
    public class AccountController : Controller
    {
        /* AccountController oluşturulurken Dependency Injection (DI) aracılığıyla 
        ASP.NET Core Identity'nin SignInManager<AppUser> ve UserManager<AppUser> servisleri Controller'a otomatik olarak verilir; 
        SignInManager kullanıcının giriş/çıkış ve oturum işlemlerini, 
        UserManager ise kullanıcının oluşturulması, bulunması,şifre işlemleri ve kullanıcı bilgilerinin yönetilmesini sağlar ve
        constructor içerisinde gelen bu servisler _signInManager ve _userManager alanlarına 
        atanarak Controller'ın diğer metotlarında kullanılabilir hale getirilir.         */
        private readonly SignInManager<AppUser> _signInManager; // SignInManager ve UserManager servislerini temsil eden alanlar
        private readonly UserManager<AppUser> _userManager; // SignInManager ve UserManager servislerini temsil eden alanlar
        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)  // AccountController constructor, SignInManager ve UserManager servislerini alır
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }



        // [NonAction] attribute, bir controller sınıfındaki bir yöntemin action method olarak kullanılmamasını sağlar.
        // Bu attribute, genellikle controller sınıfında yardımcı yöntemler veya özel işlevler için kullanılır ve
        // bu yöntemlerin HTTP istekleriyle doğrudan çağrılmasını engeller.
        [NonAction]
        public IActionResult Index()
        {
            return View();
        }


        //[HttpGet], bir Controller içindeki Action metodunun
        //HTTP GET istekleriyle çalışacağını belirtir;
        //genellikle bir sayfayı görüntülemek,
        //veri almak veya formu kullanıcıya göstermek için kullanılır.
        [HttpGet] //kullanıcıdan  veya hiçbirşeyden bişi döndürmüyor
        public IActionResult Login()
        {
            return View();
        }

        //[HttpPost], bir Controller içindeki Action metodunun sadece
        //HTTP POST istekleriyle çalışacağını belirtir;
        //genellikle formdan kullanıcı verilerini sunucuya göndermek,
        //kayıt eklemek veya güncellemek için kullanılır.
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel model) // LoginUserViewModel model, kullanıcıdan gelen giriş formu verilerini temsil eder
        {
            if (!ModelState.IsValid) // model doğrulama hataları varsa aynı sayfayı hatalarla birlikte geri döndürür
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email); // _userManager.FindByEmailAsync(model.Email) ile e-posta adresine ait kullanıcıyı veritabanında arar
            if (user != null) // kullanıcı bulunursa _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false) ile girilen şifrenin doğru olup olmadığını kontrol eder
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                if (result.Succeeded) // başarılı girişte RedirectToAction("Index", "Home") ile ana sayfaya yönlendirir
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "E-posta veya şifre hatalı"); // kullanıcı bulunamaz veya şifre yanlışsa ModelState.AddModelError ile “E-posta veya şifre hatalı.” mesajını ekleyerek Login View'ını tekrar gösterir
            return View(model);
            /*
             Login metodu, kullanıcının giriş formundan gönderdiği LoginUserViewModel model bilgilerini önce ModelState.IsValid ile doğrular ve
            bilgiler geçersizse aynı sayfayı hatalarla birlikte geri döndürür;
            bilgiler geçerliyse _userManager.FindByEmailAsync(model.Email) ile e-posta adresine ait kullanıcıyı veritabanında arar, 
            kullanıcı bulunursa _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false) ile girilen şifrenin doğru olup olmadığını kontrol edip
            başarılı girişte RedirectToAction("Index", "Home") ile ana sayfaya yönlendirir, 
            kullanıcı bulunamaz veya şifre yanlışsa ModelState.AddModelError ile “E-posta veya şifre hatalı.” mesajını ekleyerek Login View'ını tekrar gösterir.
             */
        }
        [HttpGet] //
        public async Task<IActionResult> Logout() // Logout metodu, kullanıcının oturumunu sonlandırmak için kullanılır
        {
            await _signInManager.SignOutAsync(); // _signInManager.SignOutAsync() metodu, kullanıcının mevcut oturumunu sonlandırır ve çerezleri temizler.
            return RedirectToAction("Index", "Home");
            /*
             Logout metodu, _signInManager.SignOutAsync() ile
            kullanıcının oturumunu sonlandırır ve 
            ardından RedirectToAction("Index", "Home") ile ana sayfaya yönlendirir.
            */
        }
        [HttpGet]
        public IActionResult Register() 
        {
            return View(); //
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model) // RegisterViewModel model, kullanıcıdan gelen kayıt formu verilerini temsil eder
        {
            if (!ModelState.IsValid) 
            {
                return View(model); // model doğrulama hataları varsa aynı sayfayı hatalarla birlikte geri döndürür
            }
            AppUser user = new AppUser // AppUser sınıfından yeni bir kullanıcı nesnesi oluşturur
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,// IdentityUser sınıfının UserName özelliği, kullanıcı adı olarak e-posta adresini kullanır
                EmailConfirmed = true // çift taraflı doğrulama gerektirmeyen bir senaryo
                                      // için e-posta doğrulamasını atlamak amacıyla
                                      // EmailConfirmed özelliği true olarak ayarlanmıştır.
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            // kullanıcıyı veritabanına ekler ve şifreyi hashleyerek saklar
            if (result.Succeeded) // kullanıcı oluşturma başarılı ise
            {
                await _signInManager.SignInAsync(user, isPersistent: false); 
                // kullanıcıyı otomatik olarak giriş yapmış gibi oturum açtırır
                return RedirectToAction("Index", "Home"); 
                // kullanıcı oluşturma başarılı ise ana sayfaya yönlendirir
            }
            foreach (var error in result.Errors) // kullanıcı oluşturma sırasında oluşan hataları ModelState'e ekler
            {
                ModelState.AddModelError(string.Empty, error.Description);
                // ModelState.AddModelError, model doğrulama hatalarını veya
                // özel hata mesajlarını ModelState'e eklemek için kullanılır.
            } 

            return View(model);
        }
    }
}

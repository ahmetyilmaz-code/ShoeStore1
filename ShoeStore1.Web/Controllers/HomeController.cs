using Microsoft.AspNetCore.Mvc;
using ShoeStore1.Core.Entities;
using ShoeStore1.Core.Repositories;
using ShoeStore1.Web.Models.Services;
using ShoeStore1.Web.Models.ViewModels;

namespace ShoeStore1.Web.Controllers
{
    public class HomeController : Controller  // butun controllerlarin base class'i Controller'dir. Controllerlarin temel amaci, gelen HTTP isteklerini almak ve uygun yanitlari döndürmektir.
                                              // View'da da HomeController'ın gideceği Home dosyası yapıldı.
    {
        readonly ProductService _productService;
        readonly CategoryService _categoryService;
        public HomeController(IGenericRepository<Product> repositoryProduct, IGenericRepository<Category> repositoryCategory, IUnitOfWork unitOfWork)
        {
            _productService = new ProductService(repositoryProduct, repositoryCategory, unitOfWork);
            _categoryService = new CategoryService(repositoryCategory, unitOfWork);
        }
        public IActionResult Index()  // Index action method'u, genellikle uygulamanın ana sayfasını temsil eder. Bu method, HTTP GET isteği alındığında çalışır ve kullanıcıya ana sayfa içeriğini döndürür.
        {
            HomeViewModel model = _productService.GetHomeViewProductModel();
            model.Categories = _categoryService.GetAllCategoryForName();
            return View(model);// View() metodu, varsayılan olarak "Views/Home/Index.cshtml" dosyasını render eder ve kullanıcıya döndürür.
                               // Eğer farklı bir view dosyasını render etmek istiyorsak, View("FarkliViewAdi") şeklinde kullanabiliri  z.
                               // IActionResult, ASP.NET Core MVC'de bir action method'unun döndürebileceği farklı türdeki sonuçları temsil eden bir arayüzdür. Bu, action method'unun HTTP yanıtını nasıl oluşturacağını belirler. Örneğin, bir view döndürmek için ViewResult, JSON döndürmek için JsonResult, yönlendirme yapmak için RedirectResult gibi farklı türler vardır.

            /*
                Bu kod, ASP.NET Core MVC'de HomeController adında bir controller oluşturur ve Index() metodu çağrıldığında Index adlı View'u kullanıcıya gösterir.                
              Kısaca parçalarsak:
                HomeController : Controller → Controller sınıfından miras alır.
                IActionResult Index() → Tarayıcıdan gelen isteği karşılayan action metodudur.
                return View(); → Views/Home/Index.cshtml sayfasını ekrana getirir.
            */
        }


    }
}

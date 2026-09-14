using Microsoft.AspNetCore.Identity;
using ShoeStore1.Data.Identity;

namespace ShoeStore1.Web.Data
{
    public class DbIntializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
            }

            if (await userManager.FindByEmailAsync("admin@admin.com") == null)
            {
                AppUser adminUser = new AppUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    FirstName="Admin",
                    LastName="Sistem Yöneticisi",
                    EmailConfirmed=true
                };

                var result = await userManager.CreateAsync(adminUser,"admin123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
            /*
             Bu DbIntializer sınıfı, uygulama ilk çalıştığında veritabanında gerekli başlangıç kullanıcı ve rollerinin otomatik olarak oluşturulmasını (Seed Data) sağlar.

            1-)RoleExistsAsync("Admin") ile Admin rolünün daha önce oluşturulup oluşturulmadığını kontrol eder; yoksa CreateAsync ile oluşturur.
            2-)FindByEmailAsync("admin@admin.com") ile Admin kullanıcısının mevcut olup olmadığını kontrol eder; 
            yoksa AppUser nesnesi oluştururve CreateAsync ile "admin123" şifresiyle kullanıcıyı kaydeder.
            3-)Kullanıcı başarıyla oluşturulursa (result.Succeeded), AddToRoleAsync ile bu kullanıcıya Admin rolünü atar.

            Özetle: Uygulama her açıldığında kontrol edilir; Admin rolü ve Admin kullanıcısı yoksa oluşturulur, varsa tekrar oluşturulmaz.
             */
        }

    }
}

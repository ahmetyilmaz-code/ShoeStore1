using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoeStore1.Core.Entities;
using ShoeStore1.Data.Identity;

namespace ShoeStore1.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    //DbContext sql ile c#'in birbiri ile konuştuğu kısım.
    //AppDbContext IdentityDbContext'i miras al ve User olarak AppUser kullan
    //Role tablaso olarakta AppRole kullan ve bu ikisinin Id'sinide int yap.
    {
        public AppDbContext(DbContextOptions<AppDbContext> operations) : base(operations)
        {
            //hangi sql servera bağlancam, hangi yol üzerinden bağlancam değerleri alacak
            //AppDbContext DbContextOptions sınıfından nesne alırsın aldığın nesneyide AppDbContext sınıfına setlersin bunlar Optionslardır
            //aldığın bu Options'larıda base'e gönderirisin , IdentityDbContext yapıcı metoduna gönderirsin.
            //kullanılacak Option sql bağlantı cümleciği
        }

        //------- tabloları oluştutuyoruz Db için -----
        //AppDbContext sınıfının içersinde DbSet sınıfının generic yapısını kullanarak bir property(Categories) oluşturmamız
        //SQL Server'a tablo eklemek için yeterli
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Entity<OrderItem>().Property(p => p.ProductUnitPrice).HasColumnType("decimal(18,2)");
            builder.Entity<Order>().Property(p => p.TotalPrice).HasColumnType("decimal(18,2)");
            
            builder.Entity<CartItem>().HasOne(c => c.Product).WithMany().HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.Restrict);
            //CartItem'ın herhangi bir tanesini(HasOne) Product'larının herhangi birisinin(WithMany) ForeingKey'lerinden(HasForeignKey) ProductId'sini silme(OnDelete) işleminde zincileme silmeyi kapat(DeleteBehavior.Restrict)
            builder.Entity<CartItem>().HasOne(c => c.ProductSize).WithMany().HasForeignKey(c => c.ProductSizeId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<OrderItem>().HasOne(c => c.Product).WithMany().HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.Restrict);

        }



    }
}

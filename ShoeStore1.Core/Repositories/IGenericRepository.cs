using ShoeStore1.Core.Entities;
using System.Linq.Expressions;

namespace ShoeStore1.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
        //GenericRepository'e gelecek olan şeyin bir BaseEntity olması gerektiği belirtildi. Çünkü;
        //Eğerki bir Identity BaseEntity'den türememiş ise GenericRepository'e giremez
        //GenericRepository'e giremez ise de Database'ye giremez.

        //Repository'nin aynısı hem Core hemde Data katmanında olacak. Çünkü
        //Data katmanında MSSQL yerine POSTGRESQL kullanılırsa Core'daki Repositories'den gidilerek,
        //içerisinde şu şu özellikler olacak (update delete vs.) ve sen bu özelliklere görede Servis katmanına bağlanacaksın diyebileceğimiz
        //Repositories olur ama sadece Interface olacak, açık metotlar Data katmanında yazılır.
    {
        IEnumerable<T> GetAll(); //SQL'den gelen datalar, Entity Framework Core'in kendi sorgu sonuçlarını getirmek kullandığı bir liste
        IEnumerable<T> GetAllIsActive();//aktif değerleri getir.
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        //T türündeki verileri, verilen koşula (expression) göre filtrele ve sonucu IQueryable<T> olarak döndür.
        //Bana bir filtre şartı ver, T tipindeki o şarta uyan verilerin sorgusunu döndüreyim
        //GetAll().Where(item => item.RecordStatus == "A").ToList(); gibi yazımlarda GetAll yaparak gidiyorduk. bu şekilde gerek yok.
        /*
         IQueryable<T>
             ↓
        Sonuç olarak gelecek veri tipi

        Where(...)
            ↓
        Filtreleme

        Expression<Func<T,bool>>
            ↓
        Filtreleme şartı

        x => x.Id > 10
             ↓
        Örnek filtreleme şartı

          */
    }
}

namespace ShoeStore1.Core.Repositories
{
    public interface IUnitOfWork
        //her işlem sonrasında SaveChange();
        //yapılırsa bir itemda hata olursa Database yazılmadı
        //bu sebepten eksik kalemler fişte olacak bunu önlemek
        //için c# üzerimde bütüm ürünleri ekle
        //bunların hepsini toplu olarak kaydet hata olursa SQL hiçbirini eklemez,
        //her eklemeden sonra yapılsaydı ya hatalı ürün eklenmesi veya
        //ürün eklenemesi olabilirdi bunun önüne geçildi.
    {
        void Commit(); 
    }
}

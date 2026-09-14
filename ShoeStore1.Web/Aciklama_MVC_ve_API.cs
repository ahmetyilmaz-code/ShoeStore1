namespace ShoeStore1.Web
{
    public class Aciklama_MVC_ve_API
    {
        /*
        MVC Model   View    Controller
        API Model           Controller
        Model(data katmanı)   View(ekran kullanıcın gördüğü ekran)   Controller(kontroller)
        
        MVC yaklaşımı
        Kullanıcıdan gelen veri -> View -> Controller -> Databaseye veri göndermeye gerek YOKSA -> Controller -> View -> Kullanıcıya geri dönüş HTML CSS JavaScript olarak
        Kullanıcıdan gelen veri -> View -> Controller -> Databaseye veri göndermeye gerek VARSA -> Model -> Veri oluşturulur -> Controller -> Datadaki bazı bilgiler eklenip çıkarılır -> View -> Kullanıcıya geri dönüş HTML CSS JavaScript olarak
        
        API yaklaşımı
        Kullanıcıdan gelen veri -> Controller -> İstek kontrol ediliyor -> Model -> Veri oluşturuluyor -> Controller -> JSON XML olarak data oluşuturuluyor -> JSON veri istek atan yere geri gidiyor.

        Özetle;
        Eğer HTML CSS JavaScript dönmüyorsa API'dir.
        Eğerki HTML CSS JavaScript dönüyorsa yani View katmanı varsa MVC'dir.


        */
    }
}

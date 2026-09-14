using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore1.Core.Entities
{
    internal class Aciklama
    {
        /*
        Entities Klasörü içinde Db de oluşturulmak istenilen
        tabloların sınıf karşılıları olacak.

        Core katmanı yalın c# kodundan oluşur. Tasarım dizayn yapılmayacak.
        diğer katmanalara yazılacak olan şekiller olcak.

        SQL server ile alakalıysa Data katmanına yazılacak.
        Gelen verileri manüpule etmekse Server Katmanına yazılacak.

        Microsoftun mevcut olan Identity kütüphanesi kullanarak kullanıcı girişi yapılacak.

        public ICollection<Product> Products { get; set; }
        //bir kategorinin(category) birden fazla ürünü(product) olabilir.

        public Category Category { get; set; }
        // bu kategorinin bilgilerinin dolabilmesi için, ilgili ürünün kategorisinin adının
        // kategorisinin açıklamasını çekmek istenildiğinde o veriye ulaşabilmek için        
        // Burada Entity Framework Core, Product'in Id'li kategoriye ait. Bu Id'li kategorinin verilerinide Category'nin içine koyacak 

        public DateTime? UpdateDate { get; set; }
        // DateTime? ile Dbde Allow Nulls kısmında tik var demek, yani boş geçilebilir.

        // sepet ve sepet içindeki ürünleri ayırarak,
        // kullanıcının kaç tane ürün ekleyeciğini bilemediğimiz için bunu yönetebilelim
        // bunun için CartItem diye bir tablo, sınıf oluşturuldu.

        */
    }
}

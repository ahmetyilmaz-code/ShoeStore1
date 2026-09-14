namespace ShoeStore1.Service.Helpers
{
    public static class MappingExtensions
    {
        /*
         Bu sınıf bu şekilde her seferinde Database verisini C# veri tipine çevirmeyi tek şekilde yapabilmek için yapıldı.
          public static implicit operator ProductDTo(Product product)
        {
            return new ProductDTo
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                CategoryDescription = product.Category?.Description,
                CategoryName = product.Category?.Name
            };
        } 
          */
        public static T ToDto<T>(this object source) where T : new()
            // T tip döndüren ToDto(data transfer objete çevir) generic olarak <T> al(dışardan gönderilcek <T> bu T)
            //this object source (this iler Service katmanındaki bütün objectler'i (bütün sınıfları) ToDto metoduna eklemiş oluyoruz)
            // where T : class değilde where T : new() yaparak stringte bir classtır ama new lemez.
            // sadece yapıcı metodu oluşan sınıflar,abstracl filan olamaz, sadece nesnesi oluşan sınıfları al demek.

        {
            if (source == null) throw new ArgumentNullException();
            var dtoModel = new T(); //  <T> nin bir nesnesini oluşturduk.
            var sourceProperties = source.GetType().GetProperties(); //source'un GetType(typını al) sonrada bu typeların GetProperties(property isimlerini al )
            var dtoProperties = dtoModel.GetType().GetProperties();
            foreach (var prop in sourceProperties)
            {
                var modelProp = dtoProperties.FirstOrDefault(p => p.Name == prop.Name &&
                p.PropertyType == prop.PropertyType);
                if (modelProp != null && modelProp.CanWrite)
                {
                    var value = prop.GetValue(source);
                    modelProp.SetValue(dtoModel, value);
                }
            }
            return dtoModel;
        }
        public static IEnumerable<T> ToDtoList<T>(this IEnumerable<object> sourceList) where T : new()
        {
            if (sourceList == null) throw new ArgumentNullException();
            return sourceList.Select(x => x.ToDto<T>()).ToList();
        }

    }
}

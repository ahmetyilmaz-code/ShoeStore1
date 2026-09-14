using ShoeStore1.Core.Entities;
using System.Runtime.InteropServices;

namespace ShoeStore1.Service.DTOs
{
    public class ProductDTo
    //Service katmanında GetById Product'tan geriye direk
    //Product'u döndürmeyeceğiz ProductDTo döndürecez.
    {       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}

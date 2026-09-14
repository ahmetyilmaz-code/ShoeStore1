using System.Reflection.Metadata.Ecma335;

namespace ShoeStore1.Web.Models.ApiModel
{
    public class AddToCartApiModel
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Size { get; set; }
        public string UserId { get; set; }
    }
}

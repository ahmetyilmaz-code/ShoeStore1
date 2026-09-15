using ShoeStore1.Core.Entities;
using ShoeStore1.Core.Repositories;

namespace ShoeStore1.Web.Models.Services
{
    public class CartItemService
    {
        readonly ShoeStore1.Service.Services.CartItemService _cartItemService;

        public CartItemService(IGenericRepository<CartItem> repositoryCarItem, IUnitOfWork unitOfWork)
        {
            _cartItemService = new Service.Services.CartItemService(repositoryCarItem, unitOfWork);
        }






    }
}

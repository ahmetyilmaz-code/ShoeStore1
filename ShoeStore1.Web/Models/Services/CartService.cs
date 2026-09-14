using ShoeStore1.Core.Entities;
using ShoeStore1.Core.Repositories;
using ShoeStore1.Web.Models.ApiModel;

namespace ShoeStore1.Web.Models.Services
{
    public class CartService
    {
        readonly Service.Services.CartService _cartService;
        readonly Service.Services.CartItemService _cartItemService;
        public CartService(IGenericRepository<Cart> repositoryCart, IGenericRepository<CartItem> repositoryCarItem, IUnitOfWork unitOfWork)
        {
            _cartService = new Service.Services.CartService(repositoryCart, unitOfWork);
            _cartItemService = new Service.Services.CartItemService(repositoryCarItem, unitOfWork);

        }

        public void AddCart(AddToCartApiModel model)
        {
            var cart = _cartService.GetCart(model.UserId);
            _cartItemService.AddCartItem(new CartItem
            {
                CartId = cart.Id,
                ProductId = model.ProductId,
                Quantity = 1,
                ProductSizeId = 2
            });
        }

        public List<CartItem> GetCartItemByUserId(int CartId)
        {
            return _cartItemService.GetCartItemsByCartId(CartId);
        }

        public int? GetCartIdByUserId(string userId)
        {
            var cart = _cartService.GetCart(userId);
            return cart.Id;
        }

    }
}

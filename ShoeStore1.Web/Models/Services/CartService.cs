using ShoeStore1.Core.Entities;
using ShoeStore1.Core.Repositories;
using ShoeStore1.Web.Models.ApiModel;

namespace ShoeStore1.Web.Models.Services
{
    public class CartService
    {
        readonly Service.Services.CartService _cartService;
        readonly Service.Services.CartItemService _cartItemService;
        readonly IGenericRepository<ProductSize> _productSizeRepository;
        public CartService(IGenericRepository<Cart> repositoryCart, IGenericRepository<CartItem> repositoryCarItem, IGenericRepository<ProductSize> productSizeRepository, IUnitOfWork unitOfWork)
        {
            _cartService = new Service.Services.CartService(repositoryCart, unitOfWork);
            _cartItemService = new Service.Services.CartItemService(repositoryCarItem, unitOfWork);
            _productSizeRepository = productSizeRepository;
        }

        public void AddCart(AddToCartApiModel model)
        {
            var cart = _cartService.GetCart(model.UserId);

            Console.WriteLine("ProductId: " + model.ProductId);
            Console.WriteLine("Seçilen Size: " + model.Size);

            var productSize = _productSizeRepository.Where(x => x.ProductId == model.ProductId && x.Size == model.Size.ToString() && !x.IsDeleted&& x.Stock > 0).FirstOrDefault();

            var productSizes = _productSizeRepository.Where(x => x.ProductId == model.ProductId).ToList();
            foreach (var item in productSizes)
            {
                Console.WriteLine(
                    $"Id: {item.Id} | ProductId: {item.ProductId} | Size: {item.Size} | Stock: {item.Stock} | IsDeleted: {item.IsDeleted}");
            }


            if (productSize == null)
            {
                throw new Exception("Seçilen beden stokta bulunamadı.");
            }

            _cartItemService.AddCartItem(new CartItem
            {
                CartId = cart.Id,
                ProductId = model.ProductId,
                Quantity = 1,
                ProductSizeId = productSize.Id
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

        public void DeleteCartItem(int id)
        {
            _cartItemService.DeleteCartItem(id);
        }

    }
}

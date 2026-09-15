using Microsoft.AspNetCore.Mvc;
using ShoeStore1.Core.Entities;
using ShoeStore1.Core.Repositories;
using ShoeStore1.Service.DTOs;
using ShoeStore1.Web.Models.ApiModel;
using ShoeStore1.Web.Models.Services;
using ShoeStore1.Web.Models.ViewModels;

namespace ShoeStore1.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartApiController : ControllerBase
    {
        CartService _cartService;
        ProductService _productService;
        IGenericRepository<ProductSize> _productSizeRepository;

        public CartApiController(IGenericRepository<Cart> repositoryCart, IGenericRepository<CartItem> repositoryCarItem, IGenericRepository<Product> repositoryProduct, IGenericRepository<Category> repositoryCategory, IGenericRepository<ProductSize> repositoryProductSize, IUnitOfWork unitOfWork)
        {
            _cartService = new CartService(repositoryCart, repositoryCarItem, repositoryProductSize, unitOfWork);
            ProductSizeService productSizeService = new ProductSizeService(repositoryProductSize, unitOfWork);
            _productService = new ProductService(repositoryProduct, repositoryCategory, unitOfWork, productSizeService);
            _productSizeRepository = repositoryProductSize;
        }
        [HttpGet("GetUserCart")]
        [Route("[action]/{userId}")]
        public IActionResult GetUserCart(string userId)
        {
            var cartId = _cartService.GetCartIdByUserId(userId);
            var cartItems = _cartService.GetCartItemByUserId((int)cartId);
            List<CartItemViewModel> cartItemViewModels = new List<CartItemViewModel>();
            decimal totalPrice = 0;
            if (cartItems != null && cartItems.Count > 0)
            {
                for (int i = 0; i < cartItems.Count; i++)
                {
                    ProductDTo product = _productService.GeyById(cartItems[i].ProductId);
                    totalPrice += product.Price;
                    var productSize = _productSizeRepository.GetById(cartItems[i].ProductSizeId);
                    cartItemViewModels.Add(new CartItemViewModel
                    {
                        Price = product.Price.ToString(),
                        ProductName = product.Name,
                        Quantity = "1",
                        Id = cartItems[i].Id,                      
                        Size = productSize.Size,
                    });

                }
            }

            var item = new
            {
                totalPrice = totalPrice,
                items = cartItemViewModels,
                totalItems = cartItems.Count
            };
            return Ok(item); // OK() Return the data as JSON
        }


        [HttpPost("SetCart")]
        public IActionResult SetCart([FromBody] AddToCartApiModel model)
        {
            _cartService.AddCart(model);
            return Ok();
        }

        [HttpPost("DeleteCartItem")]
        public IActionResult DeleteCartItem([FromBody] int id)
        {
            //Console.WriteLine($"Controller ID: {id}");
            _cartService.DeleteCartItem(id);
            return Ok();
        }



    }
}

using ShoeStore1.Core.Entities;
using ShoeStore1.Core.Repositories;
using ShoeStore1.Service.DTOs;
using ShoeStore1.Service.Helpers;

namespace ShoeStore1.Service.Services
{
    public class CartItemService : GenericService<CartItem>
    {        
        public CartItemService(IGenericRepository<CartItem> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            
        }

        public void AddCartItem(CartItem cart)
        {
            base.Add(cart);
            base.Commit();
        }
        public List<CartItem> GetCartItemsByCartId(int CartId)
        {
            return base.Where(c => c.CartId == CartId && !c.IsDeleted).ToList();
            //return base.Where(c => c.CartId == CartId).ToList();
        }

        public void DeleteCartItem(int id)
        {
            Console.WriteLine($"Service ID: {id}");
            var cartItems = base.GetAll().ToList();

            foreach (var item in cartItems)
            {
                Console.WriteLine($"Item ID: {item.Id}");
                Console.WriteLine($"Karşılaştırma: {item.Id == id}");
            }

            var cartItem = cartItems.FirstOrDefault(x => x.Id == id);

            if (cartItem == null) 
            {
                
                return;
            }

            cartItem.IsDeleted = true;
            base.Update(cartItem);
            base.Commit();
        }



    }
}

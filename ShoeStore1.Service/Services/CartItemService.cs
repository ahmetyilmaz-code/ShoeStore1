using ShoeStore1.Core.Entities;
using ShoeStore1.Core.Repositories;

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





    }
}

using ShoeStore1.Core.Entities;
using ShoeStore1.Core.Repositories;
using ShoeStore1.Service.DTOs;
using ShoeStore1.Service.Helpers;

namespace ShoeStore1.Service.Services
{
    public class CartService : GenericService<Cart>
    {
        public CartService(IGenericRepository<Cart> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {

        }

        public CartDto GetCart(string UserId)
        {
            var cart = base.Where(x => x.AppUserId == UserId && !x.IsDeleted).FirstOrDefault();

            if (cart == null)
            {
                base.Add(new Cart
                {
                    AppUserId = UserId,
                });
                base.Commit();
            }
            cart = base.Where(x => x.AppUserId == UserId && !x.IsDeleted).FirstOrDefault();
            return cart.ToDto<CartDto>();
        }

    }
}

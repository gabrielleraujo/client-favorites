using Newme.ClientFavorites.Domain.Entities.ShoopingCart;

namespace Newme.ClientFavorites.Domain.Repositories
{
    public interface IDiscountCouponRepository
    {
        Task<DiscountCoupon> GetByNameAsync(string name);
        Task AddAsync(DiscountCoupon value);
        Task DeleteByIdAsync(Guid id);
    }
}

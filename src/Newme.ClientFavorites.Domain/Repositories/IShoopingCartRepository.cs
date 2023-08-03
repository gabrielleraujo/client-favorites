using Newme.ClientFavorites.Domain.Entities.ShoopingCart;

namespace Newme.ClientFavorites.Domain.Repositories
{
    public interface IShoopingCartRepository
    {
        Task<ShoopingCart> GetByIdAsync(Guid id);
        Task AddAsync(ShoopingCart value);
        Task UpdateAsync(ShoopingCart value);
        
        Task RemoveProductAsync(Guid productId);
        Task CleanByIdAsync(Guid clientId);
    }
}

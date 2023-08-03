using Newme.ClientFavorites.Domain.Entities.Wishlist;

namespace Newme.ClientFavorites.Domain.Repositories
{
    public interface IWishlistRepository
    {
        Task<Wishlist> GetByIdAsync(Guid id);
        Task<WishlistProduct> GetProductByIdAsync(Guid productId);
        Task<IList<WishlistProduct>> GetProductsByClientIdAsync(Guid clientId);

        Task AddAsync(Wishlist value);
        Task AddProductItemAsync(WishlistProductItem productItem);
        Task AddProductAsync(WishlistProduct product);

        Task UpdateProduct(WishlistProduct wishlistProduct);
        Task RemoveProductAsync(Guid clientId, Guid productId);
    }
}

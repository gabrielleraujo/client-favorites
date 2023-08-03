namespace Newme.ClientFavorites.Domain.Entities.Wishlist
{
    public record class WishlistProductItem(
        Guid ClientId,
        Guid ProductId);
}
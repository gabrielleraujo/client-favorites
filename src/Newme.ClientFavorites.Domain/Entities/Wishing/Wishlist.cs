namespace Newme.ClientFavorites.Domain.Entities.Wishlist
{
    public class Wishlist : Entity
    {
        public Wishlist(
            Guid id,
            Guid clientId, 
            IList<WishlistProductItem> products) : base(id)
        {
            ClientId = clientId;
            _products = products;
        }

        private IList<WishlistProductItem> _products;
        public IReadOnlyCollection<WishlistProductItem> Products => _products.ToList();
        public Guid ClientId { get; private set; }

        public bool HasProduct(Guid productId)
        {
            return _products.Any(x => x.ProductId == productId);
        }
    }
}
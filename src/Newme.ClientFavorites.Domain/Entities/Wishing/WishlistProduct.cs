namespace Newme.ClientFavorites.Domain.Entities.Wishlist
{
    public class WishlistProduct : Entity
    {
        public WishlistProduct(
            Guid id,
            Guid productId,
            string name,
            double unitPrice,
            bool isEmptyStock) : base(id)
        {
            ProductId = productId;
            Name = name;
            UnitPrice = unitPrice;
            IsEmptyStock = isEmptyStock;
        }

        public Guid ProductId { get; private set; }
        public string Name { get; private set;}
        public double UnitPrice { get; private set; }
        public bool IsEmptyStock { get; private set; }

        public void Deativate()
        {
            IsEmptyStock = true;
        }
    }
}
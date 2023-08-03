namespace Newme.ClientFavorites.Application.InputModels.Wishlist
{
    public class ReadWishlistProductItemInputModel
    {
        public ReadWishlistProductItemInputModel(
            Guid productId,
            string name,
            double unitPrice)
        {
            ProductId = productId;
            Name = name;
            UnitPrice = unitPrice;
        }

        public Guid ProductId { get; set; }
        public string Name { get; set;}
        public double UnitPrice { get; set; }
        public bool IsEmptyStock { get; private set; }
    }
}
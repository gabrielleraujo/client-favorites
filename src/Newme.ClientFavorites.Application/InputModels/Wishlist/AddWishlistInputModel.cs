namespace Newme.ClientFavorites.Application.InputModels.Wishlist
{
	public class AddWishlistInputModel
	{
        public AddWishlistInputModel(
            Guid clientId,
            ReadWishlistProductItemInputModel product)
        {
            ClientId = clientId;
            Product = product;
        }

        public Guid ClientId { get; set; }
        public ReadWishlistProductItemInputModel Product { get; set; }
	}
}

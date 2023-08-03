namespace Newme.ClientFavorites.Application.InputModels.Wishlist
{
	public class DeleteWishlistInputModel
	{
        public DeleteWishlistInputModel(
            Guid clientId,
            Guid productId)
        {
            ClientId = clientId;
            ProductId = productId;
        }

        public Guid ClientId { get; set; }
        public Guid ProductId { get; set; }
	}
}

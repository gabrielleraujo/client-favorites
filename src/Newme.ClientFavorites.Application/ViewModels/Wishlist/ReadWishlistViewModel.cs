using Newtonsoft.Json;

namespace Newme.ClientFavorites.Application.ViewModels.Wishlist
{
    public class ReadWishlistViewModel : ReadClientFavoriteViewModel
    {
        public ReadWishlistViewModel(
            Guid id,
            Guid clientId,
            IEnumerable<ReadWishlistProductViewModel> products)
        {
            Id = id;
            ClientId = ClientId;
            Products = products;
        }

        [JsonProperty("products")]
        public IEnumerable<ReadWishlistProductViewModel> Products { get; private set; }
    }
}
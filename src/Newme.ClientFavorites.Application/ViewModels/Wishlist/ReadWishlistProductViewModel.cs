using Newtonsoft.Json;

namespace Newme.ClientFavorites.Application.ViewModels.Wishlist
{
    public class ReadWishlistProductViewModel : ReadClientFavoriteViewModel
    {
        [JsonProperty("id")]
        public Guid ProductId { get; private set; }

        [JsonProperty("quantity")]
        public int Quantity { get; private set;}

        [JsonProperty("unit_price")]
        public double UnitPrice { get; private set; }
    }
}
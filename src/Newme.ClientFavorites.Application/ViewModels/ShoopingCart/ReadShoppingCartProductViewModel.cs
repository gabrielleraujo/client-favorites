using Newtonsoft.Json;

namespace Newme.ClientFavorites.Application.ViewModels.ShoopingCart
{
    public class ReadShoppingCartProductViewModel
    {
        [JsonProperty("id")]
        public Guid ProductId { get; private set; }

        [JsonProperty("quantity")]
        public int Quantity { get; private set;}

        [JsonProperty("unit_price")]
        public double UnitPrice { get; private set; }
    }
}
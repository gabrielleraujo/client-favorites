using Newtonsoft.Json;

namespace Newme.ClientFavorites.Application.Subscribers.Events
{
    public class DeactivatedProductReceivedEvent
    {
        [JsonProperty("id")]
        public Guid Id { get; private set; }

        [JsonProperty("product_id")]
        public Guid ProductId { get; private set; }

        [JsonProperty("success")]
        public bool Success { get; private set; }
    }
}
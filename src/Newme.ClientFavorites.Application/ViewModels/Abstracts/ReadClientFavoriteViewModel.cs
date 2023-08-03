using Newtonsoft.Json;

namespace Newme.ClientFavorites.Application.ViewModels
{
    public abstract class ReadClientFavoriteViewModel
    {
        [JsonProperty("id")]
        public Guid Id { get; protected set; }

        [JsonProperty("client_id")]
        public Guid ClientId { get; protected set; }
    }
}
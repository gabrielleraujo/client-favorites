using MongoDB.Bson.Serialization;
using Newme.ClientFavorites.Domain.Entities.Wishlist;

namespace Newme.ClientFavorites.Infrastructure.Persistence.Mappers
{
    public static class WishlistProductItemMapper
    {
        public static void Map()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(WishlistProductItem)))
            {
                BsonClassMap.RegisterClassMap<WishlistProductItem>(classMap =>
                {
                    classMap.AutoMap();
                    classMap.SetIgnoreExtraElements(true);
                    classMap.MapMember(p => p.ClientId).SetElementName("client_id");
                    classMap.MapMember(p => p.ProductId).SetElementName("product_id");
                });
            }
        }
    }
}
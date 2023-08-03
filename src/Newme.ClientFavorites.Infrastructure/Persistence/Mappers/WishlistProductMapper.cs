using MongoDB.Bson.Serialization;
using Newme.ClientFavorites.Domain.Entities.Wishlist;

namespace Newme.ClientFavorites.Infrastructure.Persistence.Mappers
{
    public static class WishlistProductMapper
    {
        public static void Map()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(WishlistProduct)))
            {
                BsonClassMap.RegisterClassMap<WishlistProduct>(classMap =>
                {
                    classMap.AutoMap();
                    classMap.SetIgnoreExtraElements(false);
                    classMap.MapMember(p => p.ProductId).SetElementName("product_id");
                    classMap.MapMember(p => p.Name).SetElementName("name");
                    classMap.MapMember(p => p.IsEmptyStock).SetElementName("is_empty_stock");
                    classMap.MapCreator(p => new WishlistProduct(
                        p.Id,
                        p.ProductId,
                        p.Name,
                        p.UnitPrice,
                        p.IsEmptyStock));
                });
            }
        }
    }
}
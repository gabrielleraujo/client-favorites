using MongoDB.Bson.Serialization;
using Newme.ClientFavorites.Domain.Entities.Wishlist;

namespace Newme.ClientFavorites.Infrastructure.Persistence.Mappers
{
    public static class WishlistMapper
    {
        public static void Map()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Wishlist)))
            {
                BsonClassMap.RegisterClassMap<Wishlist>(classMap =>
                {
                    classMap.AutoMap();
                    classMap.SetIgnoreExtraElements(false);
                    classMap.MapMember(p => p.Products).SetElementName("products");
                    classMap.MapMember(p => p.ClientId).SetElementName("client_id");
                    classMap.MapCreator(p => new Wishlist(
                        p.Id,
                        p.ClientId,
                        p.Products.ToList()));
                });
            }
        }
    }
}
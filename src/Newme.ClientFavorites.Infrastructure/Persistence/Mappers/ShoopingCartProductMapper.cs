using MongoDB.Bson.Serialization;
using Newme.ClientFavorites.Domain.Entities.ShoopingCart;

namespace Newme.ClientFavorites.Infrastructure.Persistence.Mappers
{
    public static class ShoopingCartProductMapper
    {
        public static void Map()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(ShoopingCartProduct)))
            {
                BsonClassMap.RegisterClassMap<ShoopingCartProduct>(classMap =>
                {
                    classMap.AutoMap();
                    classMap.SetIgnoreExtraElements(true);
                    classMap.MapMember(p => p.ClientId).SetElementName("client_id");
                    classMap.MapMember(p => p.ProductId).SetElementName("product_id");
                    classMap.MapMember(p => p.Quantity).SetElementName("quantity");
                    classMap.MapMember(p => p.UnitPrice).SetElementName("unit_price");
                });
            }
        }
    }
}
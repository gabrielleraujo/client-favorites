using MongoDB.Bson.Serialization;
using Newme.ClientFavorites.Domain.Entities.ShoopingCart;

namespace Newme.ClientFavorites.Infrastructure.Persistence.Mappers
{
    public static class ShoopingCartMapper
    {
        public static void Map()
        {
            BsonClassMap.RegisterClassMap<ShoopingCart>(classMap =>
            {
                classMap.AutoMap();
                classMap.SetIgnoreExtraElements(false);
                classMap.MapMember(p => p.Products).SetElementName("products");
                classMap.MapMember(p => p.ClientId).SetElementName("client_id");
                classMap.MapMember(p => p.CouponId).SetElementName("coupon_id");
                classMap.MapMember(p => p.TotalPrice).SetElementName("total_price");
                classMap.MapCreator(p => new ShoopingCart(
                    p.Id,
                    p.ClientId,
                    p.CouponId,
                    p.TotalPrice,
                    p.Products.ToList()));
            });
        }
    }
}
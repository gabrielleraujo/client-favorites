using MongoDB.Bson.Serialization;
using Newme.ClientFavorites.Domain.Entities.ShoopingCart;

namespace Newme.ClientFavorites.Infrastructure.Persistence.Mappers
{
    public static class DiscountCouponMapper
    {
        public static void Map()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(DiscountCoupon)))
            {
                BsonClassMap.RegisterClassMap<DiscountCoupon>(classMap =>
                {
                    classMap.AutoMap();
                    classMap.SetIgnoreExtraElements(false);
                    classMap.MapMember(p => p.Name).SetElementName("name");
                    classMap.MapMember(p => p.Description).SetElementName("description");
                    classMap.MapMember(p => p.Percentage).SetElementName("percentage");

                    classMap.MapCreator(p => new DiscountCoupon(
                        p.Id,
                        p.Name,
                        p.Percentage,
                        p.Description));
                });
            }
        }
    }
}
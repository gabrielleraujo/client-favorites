namespace Newme.ClientFavorites.Infrastructure.Persistence.Mappers
{
    public static class MongoMapper
    {
        public static void Configure()
        {
            EntityMapper.Map();
            DiscountCouponMapper.Map();
            ShoopingCartMapper.Map();
            ShoopingCartProductMapper.Map();
            WishlistMapper.Map();
            WishlistProductMapper.Map();
            WishlistProductItemMapper.Map();
        }
    }
}
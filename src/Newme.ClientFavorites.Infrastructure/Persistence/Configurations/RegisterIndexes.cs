using MongoDB.Driver;
using Newme.ClientFavorites.Domain.Entities.ShoopingCart;
using Newme.ClientFavorites.Domain.Entities.Wishlist;

namespace Newme.ClientFavorites.Infrastructure.Persistence.Configurations
{
    public static class RegisterIndexes
    {
        public static async Task CreateIndexesAsync(IMongoClient client)
        {
            var database = client.GetDatabase("newme_ms_client_favorites");

            var discountCoupon = database.GetCollection<DiscountCoupon>("discount-coupom");
            var wishlist = database.GetCollection<Wishlist>("wishlist");
            var wishlistProduct = database.GetCollection<WishlistProduct>("wishlist-product");
            var shoopingCart = database.GetCollection<ShoopingCart>("shooping-cart");
            var shoopingCartProduct = database.GetCollection<ShoopingCartProduct>("shooping-cart-product");

            await discountCoupon.Indexes.CreateOneAsync(new CreateIndexModel<DiscountCoupon>(Builders<DiscountCoupon>.IndexKeys.Ascending(x => x.Name)));
            await wishlist.Indexes.CreateOneAsync(new CreateIndexModel<Wishlist>(Builders<Wishlist>.IndexKeys.Ascending(x => x.ClientId)));
            await wishlistProduct.Indexes.CreateOneAsync(new CreateIndexModel<WishlistProduct>(Builders<WishlistProduct>.IndexKeys.Ascending(x => x.ProductId)));
            await shoopingCart.Indexes.CreateOneAsync(new CreateIndexModel<ShoopingCart>(Builders<ShoopingCart>.IndexKeys.Ascending(x => x.ClientId)));
            await shoopingCartProduct.Indexes.CreateOneAsync(new CreateIndexModel<ShoopingCartProduct>(Builders<ShoopingCartProduct>.IndexKeys.Ascending(x => x.ProductId)));
        }
    }
}
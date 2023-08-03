using MongoDB.Driver;
using Newme.ClientFavorites.Domain.Entities.Wishlist;
using Newme.ClientFavorites.Domain.Repositories;

namespace Newme.ClientFavorites.Infrastructure.Persistence.Repositories
{
    public class WishlistRepository : IWishlistRepository
    {
        protected readonly IMongoCollection<Wishlist> _collection;
        protected readonly IMongoCollection<WishlistProduct> _collectionProduct;
        protected readonly IMongoCollection<WishlistProductItem> _collectionProductItem;

        public WishlistRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Wishlist>("wishlist");
            _collectionProduct = database.GetCollection<WishlistProduct>("wishlist_product");
            _collectionProductItem = database.GetCollection<WishlistProductItem>("wishlist_product_item");
        }

        public async Task<Wishlist> GetByIdAsync(Guid id)
        {
            return await _collection.Find(c => c.Id == id).SingleOrDefaultAsync();
        }
        
        public async Task AddAsync(Wishlist value)
        {
            await _collection.InsertOneAsync(value);
        }

        public async Task<WishlistProduct> GetProductByIdAsync(Guid productId)
        {
            return await _collectionProduct.Find(c => c.ProductId == productId).SingleOrDefaultAsync();
        }

        public async Task<IList<WishlistProduct>> GetProductsByClientIdAsync(Guid clientId)
        {
            var response = await _collectionProductItem.Find(c => c.ClientId == clientId).ToListAsync();
            return _collectionProduct.Find(x => response.Select(x => x.ProductId).Contains(x.ProductId)).ToList();
        }

        public async Task AddProductAsync(WishlistProduct product)
        {
            await _collectionProduct.InsertOneAsync(product);
        }

        public async Task UpdateProduct(WishlistProduct product)
        {
            var filter = Builders<WishlistProduct>.Filter
                .Eq(entity => entity.Id, product.ProductId);

            var update = Builders<WishlistProduct>.Update
                .Set(x => x.Name, product.Name)
                .Set(x => x.UnitPrice, product.UnitPrice)
                .Set(x => x.IsEmptyStock, product.IsEmptyStock)
                .Set(x => x.UpdateDate, DateTime.Now);

            var result = await _collectionProduct.UpdateManyAsync(filter, update);
            if (result.MatchedCount == 0) throw new Exception("Error on update.");
        }

        public async Task AddProductItemAsync(WishlistProductItem productItem)
        {
            var filter = Builders<Wishlist>.Filter
                .Eq(x => x.ClientId, productItem.ClientId);

            var update = Builders<Wishlist>.Update
                .AddToSet(x => x.Products, productItem);

            await _collection.UpdateOneAsync(filter, update);
        }
        
        public async Task RemoveProductAsync(Guid clientId, Guid productId)
        {
            var filter = Builders<Wishlist>.Filter
                .ElemMatch(x => x.Products, x => x.ProductId == productId);
            await RemoveProductByFilterAsync(productId, filter);
        }

        private async Task RemoveProductByFilterAsync(Guid productId, FilterDefinition<Wishlist> filter)
        {
            var update = Builders<Wishlist>.Update
                .PullFilter(x => x.Products, Builders<WishlistProductItem>.Filter.Eq(x => x.ProductId, productId));

            await _collection.UpdateManyAsync(filter, update);
        }
    }
}
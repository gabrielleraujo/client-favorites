using MongoDB.Driver;
using Newme.ClientFavorites.Domain.Entities.ShoopingCart;
using Newme.ClientFavorites.Domain.Repositories;

namespace Newme.ClientFavorites.Infrastructure.Persistence.Repositories
{
    public class ShoopingCartRepository : IShoopingCartRepository
    {
        protected readonly IMongoCollection<ShoopingCart> _collection;

        public ShoopingCartRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<ShoopingCart>("shooping_cart");
        }

        public async Task<ShoopingCart> GetByIdAsync(Guid id)
        {
            var item = await _collection.FindAsync(c => c.Id == id);
            return item.FirstOrDefault();
        }
        
        public async Task AddAsync(ShoopingCart value)
        {
            await _collection.InsertOneAsync(value);
        }

        public async Task CleanByIdAsync(Guid clientId)
        {
            var filter = Builders<ShoopingCart>.Filter
                .Eq(x => x.ClientId, clientId);

            var update = Builders<ShoopingCart>.Update
                .Set(x => x.Products, new List<ShoopingCartProduct>())
                .Set(x => x.UpdateDate, DateTime.Now);

            var result = await _collection.UpdateManyAsync(filter, update);
            if (result.MatchedCount == 0) throw new Exception("Error on update.");
        }
        
        public async Task RemoveProductAsync(Guid productId)
        {
            var filter = Builders<ShoopingCart>.Filter
                .ElemMatch(x => x.Products, x => x.ProductId == productId);
            await RemoveProductByFilterAsync(productId, filter);
        }
        
        private async Task RemoveProductByFilterAsync(Guid productId, FilterDefinition<ShoopingCart> filter)
        {
            var update = Builders<ShoopingCart>.Update
                .PullFilter(x => x.Products, Builders<ShoopingCartProduct>.Filter.Eq(x => x.ProductId, productId));

            await _collection.UpdateManyAsync(filter, update);
        }

        public async Task UpdateAsync(ShoopingCart entity)
        {
            var filter = Builders<ShoopingCart>.Filter
                .Eq(x => x.ClientId, entity.ClientId);

            var update = Builders<ShoopingCart>.Update
                .Set(x => x.CouponId, entity.CouponId)
                .Set(x => x.TotalPrice, entity.TotalPrice)
                .Set(x => x.Products, entity.Products)
                .Set(x => x.UpdateDate, DateTime.Now);

            var result = await _collection.UpdateManyAsync(filter, update);
            if (result.MatchedCount == 0) throw new Exception("Error on update.");
        }
    }
}

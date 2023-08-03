using MongoDB.Driver;
using Newme.ClientFavorites.Domain.Entities.ShoopingCart;
using Newme.ClientFavorites.Domain.Repositories;

namespace Newme.ClientFavorites.Infrastructure.Persistence.Repositories
{
    public class DiscountCouponRepository : IDiscountCouponRepository
    {
        protected readonly IMongoCollection<DiscountCoupon> _collection;
        public DiscountCouponRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<DiscountCoupon>("discount_coupon");
        }

        public async Task AddAsync(DiscountCoupon value)
        {
            await _collection.InsertOneAsync(value);
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var filter = Builders<DiscountCoupon>.Filter
                .Eq(entity => entity.Id, id);

            var result = await _collection.DeleteOneAsync(filter);
            if (result.DeletedCount == 0) throw new Exception("Error on delete.");
        }

        public async Task<DiscountCoupon> GetByNameAsync(string name)
        {
            return await _collection.Find(c => c.Name == name).SingleOrDefaultAsync();
        }
    }
}

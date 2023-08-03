using MongoDB.Bson.Serialization;
using Newme.ClientFavorites.Domain.Entities;

namespace Newme.ClientFavorites.Infrastructure.Persistence.Mappers
{
    public static class EntityMapper
    {
        public static void Map()
        {
            BsonClassMap.RegisterClassMap<Entity>(classMap =>
            {
                classMap.AutoMap();
                classMap.SetIgnoreExtraElements(true);
                classMap.MapIdMember(p => p.Id);
                classMap.MapMember(p => p.CreateDate).SetElementName("create_date");
                classMap.MapMember(p => p.UpdateDate).SetElementName("update_date");
            });
        }
    }
}
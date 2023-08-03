using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newme.ClientFavorites.Infrastructure.Persistence.Repositories;
using Newme.ClientFavorites.Infrastructure.Messaging;
using Newme.ClientFavorites.Domain.Repositories;
using MongoDB.Bson.Serialization;
using Newme.ClientFavorites.Infrastructure.Persistence.Mappers;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;
using MongoDB.Driver;
using Newme.ClientFavorites.Infrastructure.Persistence;
using Newme.ClientFavorites.Domain.Messaging;

namespace Newme.ClientFavorites.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
        {            
            services
                .AddMongo()
                .AddRepositories()
                .AddMessageBus();

            return services;
        }

        private static IServiceCollection AddMongo(this IServiceCollection services)
        {
            services.AddSingleton<MongoDbOptions>(sp => {
                var options = new MongoDbOptions();
                var configuration = sp.GetService<IConfiguration>();

                configuration.GetSection("Mongo").Bind(options);

                return options;
            });

            services.AddSingleton<IMongoClient>(sp => {
                var options = sp.GetService<MongoDbOptions>();

                var client = new MongoClient(options.ConnectionString);
                var db = client.GetDatabase(options.Database);

                return client;
            });

            services.AddSingleton(sp => {
                BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
                BsonSerializer.RegisterSerializer(new DateTimeSerializer(BsonType.String));

                MongoMapper.Configure();

                var options = sp.GetService<MongoDbOptions>();
                var mongoClient = sp.GetService<IMongoClient>();

                var db = mongoClient.GetDatabase(options.Database);

                //RegisterIndexes.CreateIndexesAsync(db.Client);

                return db;
            });

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMessageBusServer, RabbitMqService>();
            services.AddScoped<IDiscountCouponRepository, DiscountCouponRepository>();
            services.AddScoped<IWishlistRepository, WishlistRepository>();
            services.AddScoped<IShoopingCartRepository, ShoopingCartRepository>();

            return services;
        }

        private static IServiceCollection AddMessageBus(this IServiceCollection services) {
            services.AddScoped<IMessageBusServer, RabbitMqService>();
            
            return services;
        }
    }
}
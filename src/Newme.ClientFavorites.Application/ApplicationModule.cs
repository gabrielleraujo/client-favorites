using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Newme.ClientFavorites.Application.AutoMapper;
using Newme.ClientFavorites.Application.Services;
using Newme.ClientFavorites.Application.Subscribers;

namespace Newme.ClientFavorites.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services
                .AddSubscribers()
                .AddValidators()
                .AddSMediator()
                .AddApplicationServices()
                .AddAutoMapperConfiguration();

            return services;
        }

        private static IServiceCollection AddSMediator(this IServiceCollection services) 
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            
            return services;
        }

        private static IServiceCollection AddSubscribers(this IServiceCollection services) {
            services.AddHostedService<DeactivatedProductSubscriber>();
            
            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            //services.AddValidatorsFromAssemblyContaining<RegisterPixValidation>(ServiceLifetime.Scoped);

            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IDiscountCouponService, DiscountCouponService>();
            services.AddScoped<IWishlistService, WishlistService>();
            services.AddScoped<IShoopingCartService, ShoopingCartService>();

            return services;
        }

        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(InputModelToCommandMappingProfile),
                typeof(InputModelToDomainMappingProfile)
            );

            return services;
        }
    }
}
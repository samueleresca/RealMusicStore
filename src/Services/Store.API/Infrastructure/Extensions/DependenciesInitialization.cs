using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Store.API.Models;
using Store.API.Repositories;
using Store.API.Requests;

namespace Store.API.Infrastructure.Extensions
{
    public static class DependenciesInitialization
    {
        public static IServiceCollection ServicesInitialization(this IServiceCollection services)
        {
            services.AddTransient<IStoreArtistRepository, StoreArtistRepository>();
            services.AddTransient<IStoreGenreRepository, StoreGenreRepository>();
            services.AddTransient<IStoreViynlRepository, StoreVinylRepository>();
            return services;
        }

        public static IServiceCollection AutomapperInitialization(this IServiceCollection services)
        {

            services.AddAutoMapper();
            return services;
        }

    }
}

using GalleryApi.Application.Common.Interfaces;
using GalleryApi.Application.Common.Interfaces.Repository;
using GalleryPhoto.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GalleryApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPhotoRepository, PhotoRepository>();

        return services;
    }
}
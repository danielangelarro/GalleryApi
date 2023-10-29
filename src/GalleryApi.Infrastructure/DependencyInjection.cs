using GalleryApi.Application.Common.Interfaces;
using GalleryApi.Application.Common.Interfaces.Repository;
using GalleryApi.Infrastructure.Authentication;
using GalleryApi.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GalleryApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        Microsoft.Extensions.Configuration.ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPhotoRepository, PhotoRepository>();

        return services;
    }
}
using GalleryApi.Application.Common.Interfaces;
using GalleryApi.Application.Common.Interfaces.Authentication;
using GalleryApi.Application.Common.Interfaces.Repository;
using GalleryApi.Application.Common.Interfaces.Services;
using GalleryApi.Infrastructure.Authentication;
using GalleryApi.Infrastructure.Repositories;
using GalleryApi.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GalleryApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        Microsoft.Extensions.Configuration.ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddDbContext<GalleryPhotoDBContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
        );

        services.AddSingleton<IJwtTokenGenerator, JwTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPhotoRepository, PhotoRepository>();

        return services;
    }
}
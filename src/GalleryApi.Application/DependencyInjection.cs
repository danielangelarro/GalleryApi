using Microsoft.Extensions.DependencyInjection;
using GalleryApi.Application.Authentication.Queries.Login;
using GalleryApi.Application.Authentication.Commands.Register;
using FluentValidation;

namespace GalleryApi.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        services.AddScoped<IValidator<LoginQuery>, LoginQueryValidator>();
        services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();

        return services;
    }
}
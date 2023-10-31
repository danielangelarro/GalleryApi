using GalleryApi.Application;
using GalleryApi.Infrastructure;
using GalleryApi.API.Authentication;


var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration)

        .ConfigureAutheticationServices(builder.Configuration)
        .SwaggerDocumentatiobService();

    builder.Services.AddControllers();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.MapControllers();
    
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseStatusCodePages();
    
    app.Run();
}
using Bogus;
using GalleryApi.Application.Entities;

namespace GalleryApi.Infrastructure.Repositories;

public class GeneratorFakeData
{
    public User GenerarDatosFalsosDeUser()
    {
        var faker = new Faker<User>()
            //.RuleFor(u => u.Id, f => Guid.NewGuid())
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
            .RuleFor(u => u.Password, f => f.Internet.Password());
            //.RuleFor(u => u.Photos, f => new List<Photo> { GenerarDatosFalsosDePhoto() });

        return faker.Generate();
    }

    public Photo GenerarDatosFalsosDePhoto(int cant = 1)
    {
        var faker = new Faker<Photo>()
            //.RuleFor(p => p.Id, f => Guid.NewGuid())
            .RuleFor(p => p.FileName, f => f.System.FileName())
            .RuleFor(p => p.FileDescription, f => f.Lorem.Sentence())
            .RuleFor(p => p.Auth, GenerarDatosFalsosDeUser)
            .RuleFor(p => p.Contenido, GenerarContenidoDeFoto);

        return faker.Generate();
    }

    public byte[] GenerarContenidoDeFoto()
    {
        return File.ReadAllBytes("../../Image/test_image.jpg");
    }
}
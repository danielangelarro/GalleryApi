using System.Linq;

namespace Tests;

public class PhotoRepositoryTests
{
    private readonly PhotoRepository _photoRepo;
    private readonly Faker<Photo> _faker;

    public PhotoRepositoryTests()
    {
        _photoRepo = new PhotoRepository();
        _faker = new Faker<Photo>()
            .RuleFor(p => p.Id, f => Guid.NewGuid())
            .RuleFor(p => p.FileName, f => f.System.FileName())
            .RuleFor(p => p.FileDescription, f => f.Lorem.Sentence())
            .RuleFor(p => p.Auth, f => new User { /* generar datos falsos para el usuario */ })
            .RuleFor(p => p.Contenido, GenerarContenidoDeFoto);
    }

    [Fact]
    public void Add_ShouldAddPhoto()
    {
        // Preparar: generar una foto falsa
        var fakePhoto = _faker.Generate();

        // Actuar: agregar la foto al repositorio
        _photoRepo.Add(fakePhoto);

        // Afirmar: la foto debería estar en el repositorio
        var photoInRepo = _photoRepo.GetPhotoById(fakePhoto.Id);
        Assert.Equal(fakePhoto, photoInRepo);
    }

    // Y así sucesivamente para los otros métodos (Delete, Put, GetPhotoById, GetPhotos, GetPhotosByUser)
}
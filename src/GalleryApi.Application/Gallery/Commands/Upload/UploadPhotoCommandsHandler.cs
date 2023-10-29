using ErrorOr;
using GalleryApi.Application.Common.Interfaces;
using GalleryApi.Application.DTO.Gallery;
using GalleryApi.Application.Entities;
using MediatR;

namespace GalleryApi.Application.Gallery.Commands.Upload;

public class UploadPhotoCommandsHandler : IRequestHandler<UploadPhotoCommands, ErrorOr<GalleryResult>>
{
    private readonly IPhotoRepository _photoRepository;

    public UploadPhotoCommandsHandler(IPhotoRepository photoRepository)
    {
        _photoRepository = photoRepository;
    }

    public async Task<ErrorOr<GalleryResult>> Handle(UploadPhotoCommands command, CancellationToken cancellationToken)
    {
        var photo = new Photo();
        
        if (command.file.Length > 0)
        {
            using (var ms = new MemoryStream())
            {
                await command.file.CopyToAsync(ms);
                photo.Contenido = ms.ToArray();
            }

            photo.Id = Guid.NewGuid();
            photo.FileName = command.file.FileName;
            photo.Auth = command.Auth;
        }

        _photoRepository.Add(photo);
        
        return new GalleryResult(photo);
    }
}
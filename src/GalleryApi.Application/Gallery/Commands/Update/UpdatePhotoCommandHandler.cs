using GalleryApi.Application.Common.Interfaces;
using GalleryApi.Application.DTO.Gallery;
using GalleryApi.Application.Entities;
using GalleryApi.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GalleryApi.Application.Gallery.Commands.Update;

public class UpdatePhotoCommandsHandler : IRequestHandler<UpdatePhotoCommands, ErrorOr<GalleryResult>>
{
    private readonly IPhotoRepository _photoRepository;

    public UpdatePhotoCommandsHandler(IPhotoRepository photoRepository)
    {
        _photoRepository = photoRepository;
    }

    public async Task<ErrorOr<GalleryResult>> Handle(UpdatePhotoCommands command, CancellationToken cancellationToken)
    {
        if (_photoRepository.GetPhotoById(command.FileId) is not Photo photo)
        {
            return Errors.File.FileNotFound;
        }

        photo.FileName = command.FileName;
        photo.FileDescription = command.FileDescription;
        
        _photoRepository.Put(photo);
        
        return new GalleryResult(photo);
    }
}
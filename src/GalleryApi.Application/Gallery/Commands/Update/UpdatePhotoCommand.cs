using GalleryApi.Application.DTO.Gallery;
using MediatR;
using ErrorOr;

namespace GalleryApi.Application.Gallery.Commands.Update;

public record UpdatePhotoCommands(
    Guid FileId,
    string FileName,
    string FileDescription
) : IRequest<ErrorOr<GalleryResult>>;
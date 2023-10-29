using GalleryApi.Application.DTO.Gallery;
using ErrorOr;
using MediatR;

namespace GalleryApi.Application.Gallery.Commands.Delete;

public record DeletePhotoCommands(
    Guid FileId
) : IRequest<ErrorOr<GalleryResult>>;
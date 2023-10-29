using ErrorOr;
using GalleryApi.Application.DTO.Gallery;
using MediatR;

namespace GalleryApi.Application.Gallery.Query.GetPhotoUser;

public record GetByUserPhotoQuery(
    Guid UserId
) : IRequest<ErrorOr<GalleryResultList>>;
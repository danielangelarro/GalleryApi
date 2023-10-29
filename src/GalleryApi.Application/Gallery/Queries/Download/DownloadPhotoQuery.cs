using ErrorOr;
using GalleryApi.Application.DTO.Gallery;
using MediatR;

namespace GalleryApi.Application.Gallery.Query.Download;

public record DownloadPhotoQuery(
    Guid FileId
) : IRequest<ErrorOr<GalleryResult>>;
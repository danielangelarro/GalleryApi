using ErrorOr;
using GalleryApi.Application.DTO.Gallery;
using MediatR;

namespace GalleryApi.Application.Gallery.Query.GetPhotos;

public record GetPhotosQuery() : IRequest<ErrorOr<GalleryResultList>>;
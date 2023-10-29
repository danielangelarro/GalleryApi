using ErrorOr;
using GalleryApi.Application.Common.Interfaces;
using GalleryApi.Application.DTO.Gallery;
using MediatR;

namespace GalleryApi.Application.Gallery.Query.GetPhotos;

public class GetPhotosQueryHandler : IRequestHandler<GetPhotosQuery, ErrorOr<GalleryResultList>>
{
    private readonly IPhotoRepository _photoRepository;

    public GetPhotosQueryHandler(IPhotoRepository photoRepository)
    {
        _photoRepository = photoRepository;
    }

    public async Task<ErrorOr<GalleryResultList>> Handle(GetPhotosQuery query, CancellationToken cancellationToken)
    {
        return new GalleryResultList(_photoRepository.GetPhotos());
    }
}
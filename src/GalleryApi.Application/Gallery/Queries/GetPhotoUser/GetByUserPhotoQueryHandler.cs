using ErrorOr;
using GalleryApi.Application.Common.Interfaces;
using GalleryApi.Application.DTO.Gallery;
using GalleryApi.Application.Entities;
using MediatR;

namespace GalleryApi.Application.Gallery.Query.GetPhotoUser;

public class GetByUserPhotoQueryHandler : IRequestHandler<GetByUserPhotoQuery, ErrorOr<GalleryResultList>>
{
    private readonly IPhotoRepository _photoRepository;

    public GetByUserPhotoQueryHandler(IPhotoRepository photoRepository)
    {
        _photoRepository = photoRepository;
    }

    public async Task<ErrorOr<GalleryResultList>> Handle(GetByUserPhotoQuery query, CancellationToken cancellationToken)
    {
        List<Photo>? photos = _photoRepository.GetPhotosByUser(query.UserId);

        return new GalleryResultList(photos);
    }
}
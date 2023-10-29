using ErrorOr;
using GalleryApi.Application.Common.Interfaces;
using GalleryApi.Application.DTO.Gallery;
using GalleryApi.Application.Entities;
using GalleryApi.Domain.Common.Errors;
using MediatR;

namespace GalleryApi.Application.Gallery.Query.Download;

public class DownloadPhotoQueryHandler : IRequestHandler<DownloadPhotoQuery, ErrorOr<GalleryResult>>
{
    private readonly IPhotoRepository _photoRepository;

    public DownloadPhotoQueryHandler(IPhotoRepository photoRepository)
    {
        _photoRepository = photoRepository;
    }

    public async Task<ErrorOr<GalleryResult>> Handle(DownloadPhotoQuery query, CancellationToken cancellationToken)
    {
        if (_photoRepository.GetPhotoById(query.FileId) is not Photo photo)
        {
            return Errors.File.FileNotFound;
        }

        return new GalleryResult(photo);
    }
}
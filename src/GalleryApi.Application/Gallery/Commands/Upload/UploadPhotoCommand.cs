using GalleryApi.Application.DTO.Gallery;
using GalleryApi.Application.Entities;
using Microsoft.AspNetCore.Http;
using MediatR;
using ErrorOr;

namespace GalleryApi.Application.Gallery.Commands.Upload;

public record UploadPhotoCommands(
    IFormFile file,
    string FileName,
    string FileDescription,
    User Auth
) : IRequest<ErrorOr<GalleryResult>>;
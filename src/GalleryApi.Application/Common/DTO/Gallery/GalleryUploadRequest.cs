using GalleryApi.Application.Entities;
using Microsoft.AspNetCore.Http;

namespace GalleryApi.Application.DTO.Gallery;

public record GalleryUploadRequest(
    IFormFile File,
    string FileName,
    string FileDescription,
    string Email
);
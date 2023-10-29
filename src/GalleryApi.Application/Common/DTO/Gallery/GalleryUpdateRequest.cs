namespace GalleryApi.Application.DTO.Gallery;

public record GalleryUpdateRequest(
    Guid FileId,
    string FileName,
    string FileDescription
);
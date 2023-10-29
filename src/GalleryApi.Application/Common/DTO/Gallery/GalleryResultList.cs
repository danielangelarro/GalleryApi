using GalleryApi.Application.Entities;
namespace GalleryApi.Application.DTO.Gallery;

public record GalleryResultList(ICollection<Photo> photo);
using GalleryApi.Application.Common.Interfaces.Services;

namespace GalleryApi.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
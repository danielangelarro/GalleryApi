using ErrorOr;

namespace GalleryApi.Domain.Common.Errors;

public static partial class Errors
{
    public static class File
    {
        public static Error FileNotFound => Error.Conflict(
            code: "File.NotFound",
            description: "File Not Found."
        );
    }
}
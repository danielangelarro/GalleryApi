using ErrorOr;

namespace GalleryApi.Domain.Common.Errors;

public static partial class Errors
{
    public static class Model
    {
        public static Error ModelsInvalid => Error.Conflict(
            code: "Model.Invalid",
            description: "Model invalid."
        );
    }
}
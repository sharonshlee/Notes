using ErrorOr;
using Notes.Models;

namespace Notes.ServiceErrors;
public static class Errors
{
    public static class Notes
    {
        public static Error NotFound => Error.NotFound(
            code: "Note.NotFound",
            description: "Note not found."
        );
    }
}
using ErrorOr;
using Notes.Models;

namespace Notes.ServiceErrors;
public static class Errors
{
    public static class Notes
    {
        public static Error InvalidTitle => Error.Validation(
            code: "Note.InvalidTitle",
            description: $"Note title must be at least {Models.Note.MinTitleLength}" +
                         $" characters long and at most {Models.Note.MaxTitleLength} characters long."
        );

        public static Error InvalidDescription => Error.Validation(
            code: "Note.InvalidDescription",
            description: $"Note description must be at least {Models.Note.MinDescriptionLength}" +
                         $" characters long and at most {Models.Note.MaxDescriptionLength} characters long."
        );

        public static Error NotFound => Error.NotFound(
            code: "Note.NotFound",
            description: "Note not found."
        );
    }
}
using ErrorOr;
using Notes.Contracts.Note;
using Notes.ServiceErrors;

namespace Notes.Models;

public class Note
{
    public const int MinTitleLength = 3;
    public const int MaxTitleLength = 50;
    public const int MinDescriptionLength = 10;
    public const int MaxDescriptionLength = 500;

    public Guid Id { get; }
    public string Title { get; }
    public string Description { get; }
    public DateTime CreatedDate { get; }
    public DateTime ModifiedDate { get; }

    private Note(
        Guid id,
        string title,
        string description,
        DateTime createdDate,
        DateTime modifiedDate)
    {
        Id = id;
        Title = title;
        Description = description;
        CreatedDate = createdDate;
        ModifiedDate = modifiedDate;
    }

    public static ErrorOr<Note> Create(
        string title,
        string description,
        Guid? id = null,
        DateTime? createdDate = null,
        DateTime? modifiedDate = null)
    {
        List<Error> errors = new();

        if (title.Length is < MinTitleLength or > MaxTitleLength)
        {
            errors.Add(Errors.Notes.InvalidTitle);
        }

        if (description.Length is < MinDescriptionLength or > MaxDescriptionLength)
        {
            errors.Add(Errors.Notes.InvalidDescription);
        }

        if (errors.Count > 0)
        {
            return errors;
        }

        return new Note(
            id ?? Guid.NewGuid(),
            title,
            description,
            createdDate ?? DateTime.UtcNow,
            modifiedDate ?? DateTime.UtcNow
        );
    }
}
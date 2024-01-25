namespace Notes.Contracts.Note;

public record NoteResponse(
    Guid Id,
    string Title,
    string Description,
    DateTime CreatedDate,
    DateTime ModifiedDate
);

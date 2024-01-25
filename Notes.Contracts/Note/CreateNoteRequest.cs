namespace Notes.Contracts.Note;

public record CreateNoteRequest(
    string Title,
    string Description
);

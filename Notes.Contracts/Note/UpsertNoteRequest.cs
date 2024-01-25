namespace Notes.Contracts.Note;

public record UpsertNoteRequest(
    string Title,
    string Description
);

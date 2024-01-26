using ErrorOr;
using Notes.Models;
using Notes.ServiceErrors;

namespace Notes.Services.Notes;

public class NoteService : INoteService
{
    private static readonly Dictionary<Guid, Note> _notes = new();
    public ErrorOr<Created> CreateNote(Note note)
    {
        _notes.Add(note.Id, note);

        return Result.Created;
    }

    public ErrorOr<Note> GetNote(Guid id)
    {
        if (_notes.TryGetValue(id, out var note))
        {
            return note;
        }

        return Errors.Notes.NotFound;
    }

    public ErrorOr<Updated> UpsertNote(Note note)
    {
        _notes[note.Id] = note;

        return Result.Updated;
    }

    public ErrorOr<Deleted> DeleteNote(Guid id)
    {
        _notes.Remove(id);

        return Result.Deleted;
    }
}
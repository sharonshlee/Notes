using Notes.Models;

namespace Notes.Services.Notes;

public class NoteService : INoteService
{
    private static readonly Dictionary<Guid, Note> _notes = new();
    public void CreateNote(Note note)
    {
        _notes.Add(note.Id, note);
    }

    public void DeleteNote(Guid id)
    {
        _notes.Remove(id);
    }

    public Note GetNote(Guid id)
    {
        return _notes[id];
    }

    public void UpsertNote(Note note)
    {
        _notes[note.Id] = note;
    }
}
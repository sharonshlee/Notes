using Notes.Models;
namespace Notes.Services.Notes;

public interface INoteService
{
    void CreateNote(Note note);
    void DeleteNote(Guid id);
    Note GetNote(Guid id);
    void UpsertNote(Note note);
}

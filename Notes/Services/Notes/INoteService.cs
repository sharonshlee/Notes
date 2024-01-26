using ErrorOr;
using Notes.Models;
namespace Notes.Services.Notes;

public interface INoteService
{
    ErrorOr<Created> CreateNote(Note note);
    ErrorOr<Note> GetNote(Guid id);
    ErrorOr<Updated> UpsertNote(Note note);
    ErrorOr<Deleted> DeleteNote(Guid id);
}

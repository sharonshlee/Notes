using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Notes.Contracts.Note;
using Notes.Models;
using Notes.ServiceErrors;
using Notes.Services.Notes;

namespace Notes.Controllers;


public class NotesController : ApiController
{
    private readonly INoteService _noteService;

    public NotesController(INoteService noteService)
    {
        _noteService = noteService;
    }

    [HttpPost]
    public IActionResult CreateNote(CreateNoteRequest request)
    {
        var note = new Note(
            Guid.NewGuid(),
            request.Title,
            request.Description,
            DateTime.UtcNow,
            DateTime.UtcNow);

        ErrorOr<Created> createNoteResult = _noteService.CreateNote(note);

        if (createNoteResult.IsError)
        {
            return Problem(createNoteResult.Errors);
        }

        return CreatedAtAction(
            actionName: nameof(GetNote),
            routeValues: new { id = note.Id },
            value: MapNoteResponse(note)
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetNote(Guid id)
    {
        ErrorOr<Note> getNoteResult = _noteService.GetNote(id);

        return getNoteResult.Match(
            note => Ok(MapNoteResponse(note)),
            errors => Problem(errors)
        );
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertNote(Guid id, UpsertNoteRequest request)
    {
        ErrorOr<Note> getNoteResult = _noteService.GetNote(id);

        if (getNoteResult.IsError)
        {
            return Problem(getNoteResult.Errors);
        }

        var updatedNote = new Note(
            id,
            request.Title,
            request.Description,
            getNoteResult.Value.CreatedDate,
            DateTime.UtcNow
        );

        ErrorOr<Updated> updatedResult = _noteService.UpsertNote(updatedNote);

        return updatedResult.Match(
            updated => NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteNote(Guid id)
    {
        ErrorOr<Deleted> deletedResult = _noteService.DeleteNote(id);

        return deletedResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }

    private static NoteResponse MapNoteResponse(Note note)
    {
        return new NoteResponse(
            note.Id,
            note.Title,
            note.Description,
            note.CreatedDate,
            note.ModifiedDate
        );
    }

}
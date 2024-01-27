using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Notes.Contracts.Note;
using Notes.Models;
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
        ErrorOr<Note> requestToNoteResult = Note.Create(
            request.Title,
            request.Description);

        if (requestToNoteResult.IsError)
        {
            return Problem(requestToNoteResult.Errors);
        }

        var note = requestToNoteResult.Value;
        ErrorOr<Created> createNoteResult = _noteService.CreateNote(note);

        return createNoteResult.Match(
            created => CreatedAtGetNote(note),
            Problem
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetNote(Guid id)
    {
        ErrorOr<Note> getNoteResult = _noteService.GetNote(id);

        return getNoteResult.Match(
            note => Ok(MapNoteResponse(note)),
            Problem
        );
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertNote(Guid id, UpsertNoteRequest request)
    {
        ErrorOr<Note> getNoteResult = _noteService.GetNote(id);

        ErrorOr<Note> requestToNoteResult = Note.Create(
            request.Title,
            request.Description,
            id,
            getNoteResult.Value?.CreatedDate
            );

        if (requestToNoteResult.IsError)
        {
            return Problem(requestToNoteResult.Errors);
        }

        var upsertedNote = requestToNoteResult.Value;
        ErrorOr<UpsertedNote> upsertNoteResult = _noteService.UpsertNote(upsertedNote);

        return upsertNoteResult.Match(
            upserted => upserted.IsNewlyCreated ? CreatedAtGetNote(upsertedNote) : NoContent(),
            Problem
        );
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteNote(Guid id)
    {
        ErrorOr<Deleted> deleteNoteResult = _noteService.DeleteNote(id);

        return deleteNoteResult.Match(
            deleted => NoContent(),
            // errors => Problem(errors)
            Problem
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

    private CreatedAtActionResult CreatedAtGetNote(Note note)
    {
        return CreatedAtAction(
                    actionName: nameof(GetNote),
                    routeValues: new { id = note.Id },
                    value: MapNoteResponse(note)
                );
    }
}
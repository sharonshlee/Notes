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
        var note = new Note(
            Guid.NewGuid(),
            request.Title,
            request.Description,
            DateTime.UtcNow,
            DateTime.UtcNow);

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
            // errors => Problem(errors)
            Problem
        );
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertNote(Guid id, UpsertNoteRequest request)
    {
        var modifiedDate = DateTime.UtcNow;

        ErrorOr<Note> getNoteResult = _noteService.GetNote(id);

        var upsertedNote = new Note(
            id,
            request.Title,
            request.Description,
            getNoteResult.IsError ? DateTime.UtcNow : getNoteResult.Value.CreatedDate,
            modifiedDate
            );

        ErrorOr<UpsertedNote> upsertNoteResult = _noteService.UpsertNote(upsertedNote);

        return upsertNoteResult.Match(
            upserted => upserted.IsNewlyCreated ? CreatedAtGetNote(upsertedNote) : NoContent(),
            // errors => Problem(errors)
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
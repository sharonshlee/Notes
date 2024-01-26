using Microsoft.AspNetCore.Mvc;
using Notes.Contracts.Note;
using Notes.Models;
using Notes.Services.Notes;

namespace Notes.Controllers;

[ApiController]
[Route("[controller]")]
public class NotesController : ControllerBase
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

        _noteService.CreateNote(note);

        var response = new NoteResponse(
            note.Id,
            note.Title,
            note.Description,
            note.CreatedDate,
            note.ModifiedDate
        );

        return CreatedAtAction(
            actionName: nameof(GetNote),
            routeValues: new { id = note.Id },
            value: response
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetNote(Guid id)
    {
        Note note = _noteService.GetNote(id);

        var response = new NoteResponse(
            note.Id,
            note.Title,
            note.Description,
            note.CreatedDate,
            note.ModifiedDate
        );

        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertNote(Guid id, UpsertNoteRequest request)
    {
        var note = _noteService.GetNote(id);

        var updatedNote = new Note(
            id,
            request.Title,
            request.Description,
            note.CreatedDate,
            DateTime.UtcNow
        );

        _noteService.UpsertNote(updatedNote);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteNote(Guid id)
    {
        _noteService.DeleteNote(id);

        return NoContent();
    }
}
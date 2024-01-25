using Microsoft.AspNetCore.Mvc;
using Notes.Contracts.Note;

namespace Notes.Controllers;

[ApiController]
public class NotesController : ControllerBase
{
    [HttpPost("/notes")]
    public IActionResult CreateNote(CreateNoteRequest request)
    {
        return Ok(request);
    }

    [HttpGet("/notes/{id:guid}")]
    public IActionResult GetNote(Guid id)
    {
        return Ok(id);
    }

    [HttpPut("/notes/{id:guid}")]
    public IActionResult UpsertNote(Guid id, UpsertNoteRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("/notes/{id:guid}")]
    public IActionResult DeleteNote(Guid id)
    {
        return Ok(id);
    }
}
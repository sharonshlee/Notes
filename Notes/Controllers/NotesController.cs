using Microsoft.AspNetCore.Mvc;
using Notes.Contracts.Note;

namespace Notes.Controllers;

[ApiController]
[Route("[controller]")]
public class NotesController : ControllerBase
{
    [HttpPost()]
    public IActionResult CreateNote(CreateNoteRequest request)
    {
        return Ok(request);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetNote(Guid id)
    {
        return Ok(id);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertNote(Guid id, UpsertNoteRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteNote(Guid id)
    {
        return Ok(id);
    }
}
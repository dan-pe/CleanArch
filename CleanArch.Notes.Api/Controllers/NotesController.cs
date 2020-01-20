using CleanArch.Notes.Application.Interfaces;
using CleanArch.Notes.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Notes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INotesService notesService;

        public NotesController(INotesService notesService)
        {
            this.notesService = notesService;
        }

        [HttpGet]
        public IActionResult GetNotes()
        {
            return Ok(notesService.GetNotes());
        }

        [HttpPost]
        public IActionResult AddNote([FromBody]Note note)
        {
            notesService.StashNote(note);
            return Ok(note);
        }
    }
}

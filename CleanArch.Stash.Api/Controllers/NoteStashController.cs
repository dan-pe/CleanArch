using System.Collections.Generic;
using CleanArch.Stash.Application.Interfaces;
using CleanArch.Stash.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Stash.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteStashController : ControllerBase
    {
        private readonly INoteStashService noteStashService;

        public NoteStashController(INoteStashService noteStashService)
        {
            this.noteStashService = noteStashService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StashNote>> Get()
        {
            return Ok(noteStashService.GetStashNotes());
        }
    }
}
